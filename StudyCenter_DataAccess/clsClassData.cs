using System;
using System.Data;
using System.Data.SqlClient;

namespace StudyCenter_DataAccess
{
public class clsClassData
{
public static bool GetInfoByID(int? classID, ref string className, ref byte capacity, ref string description)
{
    bool isFound = false;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand("SP_GetClassInfoByID", connection))
            {
command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ClassID", (object)classID ?? DBNull.Value);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // The record was found
                        isFound = true;

className = (string)reader["ClassName"];
capacity = (byte)reader["Capacity"];
description = (reader["Description"] != DBNull.Value) ? (string)reader["Description"] : null;
                    }
                    else
                    {
                        // The record was not found
                        isFound = false;
                    }
                }
            }
        }
    }
catch (SqlException ex)
            {
                isFound = false;

                clsErrorLogger loggerToEventViewer = new clsErrorLogger(clsLogHandler.LogToEventViewer);
                loggerToEventViewer.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                isFound = false;

                clsErrorLogger loggerToEventViewer = new clsErrorLogger(clsLogHandler.LogToEventViewer);
                loggerToEventViewer.LogError("General Exception", ex);
            }

    return isFound;
}

public static int? Add(string className, byte capacity, string description)
{
// This function will return the new person id if succeeded and null if not
    int? classID = null;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand("SP_AddNewClass", connection))
            {
command.CommandType = CommandType.StoredProcedure;

command.Parameters.AddWithValue("@ClassName", className);
command.Parameters.AddWithValue("@Capacity", capacity);
command.Parameters.AddWithValue("@Description", (object)description ?? DBNull.Value);

SqlParameter outputIdParam = new SqlParameter("@NewClassID", SqlDbType.Int)
{
Direction = ParameterDirection.Output
};
command.Parameters.Add(outputIdParam);

command.ExecuteNonQuery();

classID = (int?)outputIdParam.Value;
            }
        }
    }
catch (SqlException ex)
            {
                clsErrorLogger loggerToEventViewer = new clsErrorLogger(clsLogHandler.LogToEventViewer);
                loggerToEventViewer.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                clsErrorLogger loggerToEventViewer = new clsErrorLogger(clsLogHandler.LogToEventViewer);
                loggerToEventViewer.LogError("General Exception", ex);
            }

    return classID;
}

public static bool Update(int? classID, string className, byte capacity, string description)
{
    int rowAffected = 0;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand("SP_UpdateClass", connection))
            {
command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ClassID", (object)classID ?? DBNull.Value);
command.Parameters.AddWithValue("@ClassName", className);
command.Parameters.AddWithValue("@Capacity", capacity);
command.Parameters.AddWithValue("@Description", (object)description ?? DBNull.Value);

                rowAffected = command.ExecuteNonQuery();
            }
        }
    }
catch (SqlException ex)
            {
                clsErrorLogger loggerToEventViewer = new clsErrorLogger(clsLogHandler.LogToEventViewer);
                loggerToEventViewer.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                clsErrorLogger loggerToEventViewer = new clsErrorLogger(clsLogHandler.LogToEventViewer);
                loggerToEventViewer.LogError("General Exception", ex);
            }

    return (rowAffected > 0);
}

public static bool Delete(int? classID)
{
    int rowAffected = 0;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand("SP_DeleteClass", connection))
            {
command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ClassID", (object)classID ?? DBNull.Value);

                rowAffected = command.ExecuteNonQuery();
            }
        }
    }
catch (SqlException ex)
            {
                clsErrorLogger loggerToEventViewer = new clsErrorLogger(clsLogHandler.LogToEventViewer);
                loggerToEventViewer.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                clsErrorLogger loggerToEventViewer = new clsErrorLogger(clsLogHandler.LogToEventViewer);
                loggerToEventViewer.LogError("General Exception", ex);
            }

    return (rowAffected > 0);
}

public static bool Exists(int? classID)
{
    bool isFound = false;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand("SP_DoesClassExist", connection))
            {
command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@ClassID", (object)classID ?? DBNull.Value);

// @ReturnVal could be any name, and we don't need to add it to the SP, just use it here in the code.
SqlParameter returnParameter = new SqlParameter("@ReturnVal", SqlDbType.Int)
{
Direction = ParameterDirection.ReturnValue
};
command.Parameters.Add(returnParameter);

command.ExecuteNonQuery();

isFound = (int)returnParameter.Value == 1;
            }
        }
    }
catch (SqlException ex)
            {
                isFound = false;

                clsErrorLogger loggerToEventViewer = new clsErrorLogger(clsLogHandler.LogToEventViewer);
                loggerToEventViewer.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                isFound = false;

                clsErrorLogger loggerToEventViewer = new clsErrorLogger(clsLogHandler.LogToEventViewer);
                loggerToEventViewer.LogError("General Exception", ex);
            }

    return isFound;
}

public static DataTable All()
{
return clsDataAccessHelper.All("SP_GetAllClasses");
}
}
}
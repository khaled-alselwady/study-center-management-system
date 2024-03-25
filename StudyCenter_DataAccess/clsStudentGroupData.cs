using System;
using System.Data;
using System.Data.SqlClient;

namespace StudyCenter_DataAccess
{
public class clsStudentGroupData
{
public static bool GetStudentGroupInfoByID(int? studentGroupID, ref int studentID, ref int groupID, ref DateTime enrollmentDate, ref bool isActive)
{
    bool isFound = false;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand("SP_GetStudentGroupInfoByID", connection))
            {
command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@StudentGroupID", (object)studentGroupID ?? DBNull.Value);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // The record was found
                        isFound = true;

studentID = (int)reader["StudentID"];
groupID = (int)reader["GroupID"];
enrollmentDate = (DateTime)reader["EnrollmentDate"];
isActive = (bool)reader["IsActive"];
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

public static int? AddNewStudentGroup(int studentID, int groupID, DateTime enrollmentDate, bool isActive)
{
// This function will return the new person id if succeeded and null if not
    int? studentGroupID = null;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand("SP_AddNewStudentGroup", connection))
            {
command.CommandType = CommandType.StoredProcedure;

command.Parameters.AddWithValue("@StudentID", studentID);
command.Parameters.AddWithValue("@GroupID", groupID);
command.Parameters.AddWithValue("@EnrollmentDate", enrollmentDate);
command.Parameters.AddWithValue("@IsActive", isActive);

SqlParameter outputIdParam = new SqlParameter("@NewStudentGroupID", SqlDbType.Int)
{
Direction = ParameterDirection.Output
};
command.Parameters.Add(outputIdParam);

command.ExecuteNonQuery();

studentGroupID = (int?)outputIdParam.Value;
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

    return studentGroupID;
}

public static bool UpdateStudentGroup(int? studentGroupID, int studentID, int groupID, DateTime enrollmentDate, bool isActive)
{
    int rowAffected = 0;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand("SP_UpdateStudentGroup", connection))
            {
command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@StudentGroupID", (object)studentGroupID ?? DBNull.Value);
command.Parameters.AddWithValue("@StudentID", studentID);
command.Parameters.AddWithValue("@GroupID", groupID);
command.Parameters.AddWithValue("@EnrollmentDate", enrollmentDate);
command.Parameters.AddWithValue("@IsActive", isActive);

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

public static bool DeleteStudentGroup(int? studentGroupID)
{
    int rowAffected = 0;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand("SP_DeleteStudentGroup", connection))
            {
command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@StudentGroupID", (object)studentGroupID ?? DBNull.Value);

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

public static bool DoesStudentGroupExist(int? studentGroupID)
{
    bool isFound = false;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand("SP_DoesStudentGroupExist", connection))
            {
command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@StudentGroupID", (object)studentGroupID ?? DBNull.Value);

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

public static DataTable GetAllStudentsGroups()
{
return clsDataAccessHelper.GetAll("SP_GetAllStudentsGroups");
}
}
}
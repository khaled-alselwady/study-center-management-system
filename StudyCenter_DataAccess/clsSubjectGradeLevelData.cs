using System;
using System.Data;
using System.Data.SqlClient;

namespace StudyCenter_DataAccess
{
public class clsSubjectGradeLevelData
{
public static bool GetSubjectGradeLevelInfoByID(int? subjectGradeLevelID, ref int subjectID, ref int gradeLevelID, ref decimal fees, ref string description)
{
    bool isFound = false;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand("SP_GetSubjectGradeLevelInfoByID", connection))
            {
command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@SubjectGradeLevelID", (object)subjectGradeLevelID ?? DBNull.Value);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // The record was found
                        isFound = true;

subjectID = (int)reader["SubjectID"];
gradeLevelID = (int)reader["GradeLevelID"];
fees = (decimal)reader["Fees"];
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

public static int? AddNewSubjectGradeLevel(int subjectID, int gradeLevelID, decimal fees, string description)
{
// This function will return the new person id if succeeded and null if not
    int? subjectGradeLevelID = null;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand("SP_AddNewSubjectGradeLevel", connection))
            {
command.CommandType = CommandType.StoredProcedure;

command.Parameters.AddWithValue("@SubjectID", subjectID);
command.Parameters.AddWithValue("@GradeLevelID", gradeLevelID);
command.Parameters.AddWithValue("@Fees", fees);
command.Parameters.AddWithValue("@Description", (object)description ?? DBNull.Value);

SqlParameter outputIdParam = new SqlParameter("@NewSubjectGradeLevelID", SqlDbType.Int)
{
Direction = ParameterDirection.Output
};
command.Parameters.Add(outputIdParam);

command.ExecuteNonQuery();

subjectGradeLevelID = (int?)outputIdParam.Value;
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

    return subjectGradeLevelID;
}

public static bool UpdateSubjectGradeLevel(int? subjectGradeLevelID, int subjectID, int gradeLevelID, decimal fees, string description)
{
    int rowAffected = 0;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand("SP_UpdateSubjectGradeLevel", connection))
            {
command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@SubjectGradeLevelID", (object)subjectGradeLevelID ?? DBNull.Value);
command.Parameters.AddWithValue("@SubjectID", subjectID);
command.Parameters.AddWithValue("@GradeLevelID", gradeLevelID);
command.Parameters.AddWithValue("@Fees", fees);
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

public static bool DeleteSubjectGradeLevel(int? subjectGradeLevelID)
{
    int rowAffected = 0;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand("SP_DeleteSubjectGradeLevel", connection))
            {
command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@SubjectGradeLevelID", (object)subjectGradeLevelID ?? DBNull.Value);

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

public static bool DoesSubjectGradeLevelExist(int? subjectGradeLevelID)
{
    bool isFound = false;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand("SP_DoesSubjectGradeLevelExist", connection))
            {
command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@SubjectGradeLevelID", (object)subjectGradeLevelID ?? DBNull.Value);

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

public static DataTable GetAllSubjectsGradeLevels()
{
return clsDataAccessHelper.GetAll("SP_GetAllSubjectsGradeLevels");
}
}
}
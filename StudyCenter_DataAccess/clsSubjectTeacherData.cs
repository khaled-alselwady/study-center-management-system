using System;
using System.Data;
using System.Data.SqlClient;

namespace StudyCenter_DataAccess
{
public class clsSubjectTeacherData
{
public static bool GetSubjectTeacherInfoByID(int? subjectTeacherID, ref int subjectGradeLevelID, ref int teacherID, ref DateTime assignmentDate, ref bool isActive)
{
    bool isFound = false;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand("SP_GetSubjectTeacherInfoByID", connection))
            {
command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@SubjectTeacherID", (object)subjectTeacherID ?? DBNull.Value);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // The record was found
                        isFound = true;

subjectGradeLevelID = (int)reader["SubjectGradeLevelID"];
teacherID = (int)reader["TeacherID"];
assignmentDate = (DateTime)reader["AssignmentDate"];
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

public static int? AddNewSubjectTeacher(int subjectGradeLevelID, int teacherID, DateTime assignmentDate, bool isActive)
{
// This function will return the new person id if succeeded and null if not
    int? subjectTeacherID = null;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand("SP_AddNewSubjectTeacher", connection))
            {
command.CommandType = CommandType.StoredProcedure;

command.Parameters.AddWithValue("@SubjectGradeLevelID", subjectGradeLevelID);
command.Parameters.AddWithValue("@TeacherID", teacherID);
command.Parameters.AddWithValue("@AssignmentDate", assignmentDate);
command.Parameters.AddWithValue("@IsActive", isActive);

SqlParameter outputIdParam = new SqlParameter("@NewSubjectTeacherID", SqlDbType.Int)
{
Direction = ParameterDirection.Output
};
command.Parameters.Add(outputIdParam);

command.ExecuteNonQuery();

subjectTeacherID = (int?)outputIdParam.Value;
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

    return subjectTeacherID;
}

public static bool UpdateSubjectTeacher(int? subjectTeacherID, int subjectGradeLevelID, int teacherID, DateTime assignmentDate, bool isActive)
{
    int rowAffected = 0;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand("SP_UpdateSubjectTeacher", connection))
            {
command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@SubjectTeacherID", (object)subjectTeacherID ?? DBNull.Value);
command.Parameters.AddWithValue("@SubjectGradeLevelID", subjectGradeLevelID);
command.Parameters.AddWithValue("@TeacherID", teacherID);
command.Parameters.AddWithValue("@AssignmentDate", assignmentDate);
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

public static bool DeleteSubjectTeacher(int? subjectTeacherID)
{
    int rowAffected = 0;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand("SP_DeleteSubjectTeacher", connection))
            {
command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@SubjectTeacherID", (object)subjectTeacherID ?? DBNull.Value);

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

public static bool DoesSubjectTeacherExist(int? subjectTeacherID)
{
    bool isFound = false;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand("SP_DoesSubjectTeacherExist", connection))
            {
command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@SubjectTeacherID", (object)subjectTeacherID ?? DBNull.Value);

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

public static DataTable GetAllSubjectsTeachers()
{
return clsDataAccessHelper.GetAll("SP_GetAllSubjectsTeachers");
}
}
}
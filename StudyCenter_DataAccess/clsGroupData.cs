using System;
using System.Data;
using System.Data.SqlClient;

namespace StudyCenter_DataAccess
{
public class clsGroupData
{
public static bool GetInfoByID(int? groupID, ref string groupName, ref int classID, ref int teacherID, ref int subjectGradeLevelID, ref int meetingTimeID, ref byte studentCount, ref DateTime creationDate, ref DateTime? lastModifiedDate, ref bool isActive)
{
    bool isFound = false;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand("SP_GetGroupInfoByID", connection))
            {
command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@GroupID", (object)groupID ?? DBNull.Value);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // The record was found
                        isFound = true;

groupName = (string)reader["GroupName"];
classID = (int)reader["ClassID"];
teacherID = (int)reader["TeacherID"];
subjectGradeLevelID = (int)reader["SubjectGradeLevelID"];
meetingTimeID = (int)reader["MeetingTimeID"];
studentCount = (byte)reader["StudentCount"];
creationDate = (DateTime)reader["CreationDate"];
lastModifiedDate = (reader["LastModifiedDate"] != DBNull.Value) ? (DateTime?)reader["LastModifiedDate"] : null;
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

public static int? Add(string groupName, int classID, int teacherID, int subjectGradeLevelID, int meetingTimeID, byte studentCount, DateTime creationDate, DateTime? lastModifiedDate, bool isActive)
{
// This function will return the new person id if succeeded and null if not
    int? groupID = null;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand("SP_AddNewGroup", connection))
            {
command.CommandType = CommandType.StoredProcedure;

command.Parameters.AddWithValue("@GroupName", groupName);
command.Parameters.AddWithValue("@ClassID", classID);
command.Parameters.AddWithValue("@TeacherID", teacherID);
command.Parameters.AddWithValue("@SubjectGradeLevelID", subjectGradeLevelID);
command.Parameters.AddWithValue("@MeetingTimeID", meetingTimeID);
command.Parameters.AddWithValue("@StudentCount", studentCount);
command.Parameters.AddWithValue("@CreationDate", creationDate);
command.Parameters.AddWithValue("@LastModifiedDate", (object)lastModifiedDate ?? DBNull.Value);
command.Parameters.AddWithValue("@IsActive", isActive);

SqlParameter outputIdParam = new SqlParameter("@NewGroupID", SqlDbType.Int)
{
Direction = ParameterDirection.Output
};
command.Parameters.Add(outputIdParam);

command.ExecuteNonQuery();

groupID = (int?)outputIdParam.Value;
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

    return groupID;
}

public static bool Update(int? groupID, string groupName, int classID, int teacherID, int subjectGradeLevelID, int meetingTimeID, byte studentCount, DateTime creationDate, DateTime? lastModifiedDate, bool isActive)
{
    int rowAffected = 0;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand("SP_UpdateGroup", connection))
            {
command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@GroupID", (object)groupID ?? DBNull.Value);
command.Parameters.AddWithValue("@GroupName", groupName);
command.Parameters.AddWithValue("@ClassID", classID);
command.Parameters.AddWithValue("@TeacherID", teacherID);
command.Parameters.AddWithValue("@SubjectGradeLevelID", subjectGradeLevelID);
command.Parameters.AddWithValue("@MeetingTimeID", meetingTimeID);
command.Parameters.AddWithValue("@StudentCount", studentCount);
command.Parameters.AddWithValue("@CreationDate", creationDate);
command.Parameters.AddWithValue("@LastModifiedDate", (object)lastModifiedDate ?? DBNull.Value);
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

public static bool Delete(int? groupID)
{
    int rowAffected = 0;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand("SP_DeleteGroup", connection))
            {
command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@GroupID", (object)groupID ?? DBNull.Value);

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

public static bool Exists(int? groupID)
{
    bool isFound = false;

    try
    {
        using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand("SP_DoesGroupExist", connection))
            {
command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@GroupID", (object)groupID ?? DBNull.Value);

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
return clsDataAccessHelper.All("SP_GetAllGroups");
}
}
}
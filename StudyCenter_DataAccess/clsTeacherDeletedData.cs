using System;
using System.Data;
using System.Data.SqlClient;

namespace StudyCenter_DataAccess
{
    public class clsTeacherDeletedData
    {
        public static bool GetInfoByID(int? logID, ref int teacherID,
            ref string teacherName, ref int educationLevelID,
            ref int createdByUserID, ref int deletedByUserID,
            ref DateTime creationDate, ref DateTime deletionDate)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetTeacherDeletedLogInfoByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@LogID", (object)logID ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                isFound = true;

                                teacherID = (int)reader["TeacherID"];
                                teacherName = (string)reader["TeacherName"];
                                educationLevelID = (int)reader["EducationLevelID"];
                                createdByUserID = (int)reader["CreatedByUserID"];
                                deletedByUserID = (int)reader["DeletedByUserID"];
                                creationDate = (DateTime)reader["CreationDate"];
                                deletionDate = (DateTime)reader["DeletionDate"];
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

        public static int? Add(int teacherID, string teacherName,
            int educationLevelID, int createdByUserID, int deletedByUserID,
            DateTime creationDate)
        {
            // This function will return the new person id if succeeded and null if not
            int? logID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_AddNewTeacherDeletedLog", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@TeacherID", teacherID);
                        command.Parameters.AddWithValue("@TeacherName", teacherName);
                        command.Parameters.AddWithValue("@EducationLevelID", educationLevelID);
                        command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);
                        command.Parameters.AddWithValue("@DeletedByUserID", deletedByUserID);
                        command.Parameters.AddWithValue("@CreationDate", creationDate);

                        SqlParameter outputIdParam = new SqlParameter("@NewLogID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        command.ExecuteNonQuery();

                        logID = (int?)outputIdParam.Value;
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

            return logID;
        }

        public static bool Update(int? logID, int teacherID, string teacherName,
            int educationLevelID, int createdByUserID, int deletedByUserID,
            DateTime creationDate)
        {
            int rowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_UpdateTeacherDeletedLog", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@LogID", (object)logID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@TeacherID", teacherID);
                        command.Parameters.AddWithValue("@TeacherName", teacherName);
                        command.Parameters.AddWithValue("@EducationLevelID", educationLevelID);
                        command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);
                        command.Parameters.AddWithValue("@DeletedByUserID", deletedByUserID);
                        command.Parameters.AddWithValue("@CreationDate", creationDate);

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

        public static bool Delete(int? logID)
        {
            int rowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_DeleteTeacherDeletedLog", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@LogID", (object)logID ?? DBNull.Value);

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

        public static bool Exists(int? logID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_DoesTeacherDeletedLogExist", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@LogID", (object)logID ?? DBNull.Value);

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

        public static DataTable All() => clsDataAccessHelper.All("SP_GetAllTeacherDeletedLog");
    }
}

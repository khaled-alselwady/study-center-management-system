using System;
using System.Data;
using System.Data.SqlClient;

namespace StudyCenter_DataAccess
{
    public class clsTeacherData
    {
        public static bool GetInfoByTeacherID(int? teacherID, ref int? personID, ref string educationLevel,
            ref byte? teachingExperience, ref string certifications,
            ref int? createdByUserID, ref DateTime creationDate)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetTeacherInfoByTeacherID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@TeacherID", (object)teacherID ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                isFound = true;

                                personID = (reader["PersonID"] != DBNull.Value) ? (int?)reader["PersonID"] : null;
                                educationLevel = (string)reader["EducationLevel"];
                                teachingExperience = (reader["TeachingExperience"] != DBNull.Value) ? (byte?)reader["TeachingExperience"] : null;
                                certifications = (reader["Certifications"] != DBNull.Value) ? (string)reader["Certifications"] : null;
                                createdByUserID = (reader["CreatedByUserID"] != DBNull.Value) ? (int?)reader["CreatedByUserID"] : null;
                                creationDate = (DateTime)reader["CreationDate"];
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

        public static bool GetInfoByPersonID(int? personID, ref int? teacherID, ref string educationLevel,
            ref byte? teachingExperience, ref string certifications,
            ref int? createdByUserID, ref DateTime creationDate)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetTeacherInfoByPersonID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PersonID", (object)personID ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                isFound = true;

                                teacherID = (reader["teacherID"] != DBNull.Value) ? (int?)reader["teacherID"] : null;
                                educationLevel = (string)reader["EducationLevel"];
                                teachingExperience = (reader["TeachingExperience"] != DBNull.Value) ? (byte?)reader["TeachingExperience"] : null;
                                certifications = (reader["Certifications"] != DBNull.Value) ? (string)reader["Certifications"] : null;
                                createdByUserID = (reader["CreatedByUserID"] != DBNull.Value) ? (int?)reader["CreatedByUserID"] : null;
                                creationDate = (DateTime)reader["CreationDate"];
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

        public static int? Add(int? personID, string educationLevel, byte? teachingExperience,
            string certifications, int? createdByUserID)
        {
            // This function will return the new person id if succeeded and null if not
            int? teacherID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_AddNewTeacher", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PersonID", (object)personID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@EducationLevel", educationLevel);
                        command.Parameters.AddWithValue("@TeachingExperience", (object)teachingExperience ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Certifications", (object)certifications ?? DBNull.Value);
                        command.Parameters.AddWithValue("@CreatedByUserID", (object)createdByUserID ?? DBNull.Value);

                        SqlParameter outputIdParam = new SqlParameter("@NewTeacherID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        command.ExecuteNonQuery();

                        teacherID = (int?)outputIdParam.Value;
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

            return teacherID;
        }

        public static bool Update(int? teacherID, int? personID, string educationLevel,
            byte? teachingExperience, string certifications,
            int? createdByUserID)
        {
            int rowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_UpdateTeacher", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@TeacherID", (object)teacherID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@PersonID", (object)personID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@EducationLevel", educationLevel);
                        command.Parameters.AddWithValue("@TeachingExperience", (object)teachingExperience ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Certifications", (object)certifications ?? DBNull.Value);
                        command.Parameters.AddWithValue("@CreatedByUserID", (object)createdByUserID ?? DBNull.Value);

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

        public static bool Delete(int? teacherID)
        {
            int rowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_DeleteTeacher", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@TeacherID", (object)teacherID ?? DBNull.Value);

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

        public static bool Exists(int? teacherID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_DoesTeacherExist", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@TeacherID", (object)teacherID ?? DBNull.Value);

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

        public static DataTable All() => clsDataAccessHelper.All("SP_GetAllTeachers");

        public static int Count() => clsDataAccessHelper.Count("SP_GetAllTeachersCount");
    }
}
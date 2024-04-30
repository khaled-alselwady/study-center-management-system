using System;
using System.Data;
using System.Data.SqlClient;

namespace StudyCenterDataAccess
{
    public class clsTeacherData
    {
        public static bool GetInfoByTeacherID(int? teacherID, ref int? personID, ref byte? educationLevelID,
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
                                educationLevelID = (reader["EducationLevelID"] != DBNull.Value) ? (byte?)Convert.ToByte(reader["EducationLevelID"]) : null;
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
            catch (Exception ex)
            {
                isFound = false;
                clsDataAccessHelper.HandleException(ex);
            }

            return isFound;
        }

        public static bool GetInfoByPersonID(int? personID, ref int? teacherID, ref byte? educationLevelID,
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
                                educationLevelID = (reader["EducationLevelID"] != DBNull.Value) ? (byte?)Convert.ToByte(reader["EducationLevelID"]) : null;
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
            catch (Exception ex)
            {
                isFound = false;
                clsDataAccessHelper.HandleException(ex);
            }

            return isFound;
        }

        public static int? Add(int? personID, byte? educationLevelID, byte? teachingExperience,
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
                        command.Parameters.AddWithValue("@EducationLevelID", (object)educationLevelID ?? DBNull.Value);
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
            catch (Exception ex)
            {
                clsDataAccessHelper.HandleException(ex);
            }

            return teacherID;
        }

        public static bool Update(int? teacherID, int? personID, byte? educationLevelID,
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
                        command.Parameters.AddWithValue("@EducationLevelID", (object)educationLevelID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@TeachingExperience", (object)teachingExperience ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Certifications", (object)certifications ?? DBNull.Value);
                        command.Parameters.AddWithValue("@CreatedByUserID", (object)createdByUserID ?? DBNull.Value);

                        rowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessHelper.HandleException(ex);
            }

            return (rowAffected > 0);
        }

        public static bool Delete(int? teacherID, int? deletedByUserID)
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
                        command.Parameters.AddWithValue("@DeletedByUserID", (object)deletedByUserID ?? DBNull.Value);

                        rowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessHelper.HandleException(ex);
            }

            return (rowAffected > 0);
        }

        public static bool Exists(int? teacherID)
            => clsDataAccessHelper.Exists("SP_DoesTeacherExist", "TeacherID", teacherID);

        public static DataTable All()
            => clsDataAccessHelper.All("SP_GetAllTeachers");

        public static int Count()
            => clsDataAccessHelper.Count("SP_GetAllTeachersCount");

        public static bool IsTeacher(int? personID)
            => clsDataAccessHelper.Exists("SP_IsTeacher", "PersonID", personID);

        public static DataTable AllInPages(short PageNumber, int RowsPerPage)
            => clsDataAccessHelper.AllInPages(PageNumber, RowsPerPage, "SP_GetAllTeachersInPages");

        public static string GetFullName(int? teacherID)
        {
            // This function will return the new person id if succeeded and null if not
            string fullName = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetFullTeacherName", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@TeacherID", teacherID);

                        SqlParameter outputIdParam = new SqlParameter("@FullName", SqlDbType.NVarChar, 255)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        command.ExecuteNonQuery();

                        fullName = outputIdParam.Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessHelper.HandleException(ex);
            }

            return fullName;
        }
    }
}
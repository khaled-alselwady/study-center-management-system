using System;
using System.Data;
using System.Data.SqlClient;

namespace StudyCenterDataAccess
{
    public class clsSubjectData
    {
        public static bool GetInfoByID(int? subjectID, ref string subjectName)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetSubjectInfoByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@SubjectID", (object)subjectID ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                isFound = true;

                                subjectName = (string)reader["SubjectName"];
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

        public static int? Add(string subjectName)
        {
            // This function will return the new person id if succeeded and null if not
            int? subjectID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_AddNewSubject", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@SubjectName", subjectName);

                        SqlParameter outputIdParam = new SqlParameter("@NewSubjectID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        command.ExecuteNonQuery();

                        subjectID = (int?)outputIdParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessHelper.HandleException(ex);
            }

            return subjectID;
        }

        public static bool Update(int subjectID, string subjectName)
        {
            int rowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_UpdateSubject", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@SubjectID", subjectID);
                        command.Parameters.AddWithValue("@SubjectName", subjectName);

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

        public static bool Delete(int? subjectID)
            => clsDataAccessHelper.Delete("SP_DeleteSubject", "SubjectID", subjectID);

        public static bool Exists(int? subjectID)
            => clsDataAccessHelper.Exists("SP_DoesSubjectExistBySubjectID", "SubjectID", subjectID);

        public static bool Exists(string subjectName)
            => clsDataAccessHelper.Exists("SP_DoesSubjectExistBySubjectName", "SubjectName", subjectName);

        public static DataTable All()
            => clsDataAccessHelper.All("SP_GetAllSubjects");

        public static DataTable AllOnlyNames()
            => clsDataAccessHelper.All("SP_GetAllSubjectsName");

        public static string GetSubjectNameBySubjectID(int? subjectID)
        {
            string subjectName = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetSubjectNameBySubjectID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@SubjectID", subjectID);

                        SqlParameter outputIdParam = new SqlParameter("@SubjectName", SqlDbType.NVarChar, 100)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        command.ExecuteNonQuery();

                        subjectName = outputIdParam.Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessHelper.HandleException(ex);
            }

            return subjectName;
        }

        public static string GetSubjectNameBySubjectGradeLevelID(int? subjectGradeLevelID)
        {
            string subjectName = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetSubjectNameBySubjectGradeLevelID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@SubjectGradeLevelID", subjectGradeLevelID);

                        SqlParameter outputIdParam = new SqlParameter("@SubjectName", SqlDbType.NVarChar, 100)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        command.ExecuteNonQuery();

                        subjectName = outputIdParam.Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessHelper.HandleException(ex);
            }

            return subjectName;
        }

        public static byte? GetSubjectID(string subjectName)
        {
            byte? subjectID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetSubjectID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@SubjectName", subjectName);

                        SqlParameter outputIdParam = new SqlParameter("@SubjectID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        command.ExecuteNonQuery();

                        subjectID = (byte?)(int)outputIdParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessHelper.HandleException(ex);
            }

            return subjectID;
        }
    }
}
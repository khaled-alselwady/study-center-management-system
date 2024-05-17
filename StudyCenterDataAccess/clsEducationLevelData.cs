using System;
using System.Data;
using System.Data.SqlClient;

namespace StudyCenterDataAccess
{
    public class clsEducationLevelData
    {
        public static bool GetInfoByID(byte? educationLevelID, ref string levelName)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetEducationLevelInfoByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@EducationLevelID", (object)educationLevelID ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                isFound = true;

                                levelName = (string)reader["LevelName"];
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

        public static byte? Add(string levelName)
        {
            // This function will return the new person id if succeeded and null if not
            byte? educationLevelID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_AddNewEducationLevel", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@LevelName", levelName);

                        SqlParameter outputIdParam = new SqlParameter("@NewEducationLevelID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        command.ExecuteNonQuery();

                        educationLevelID = (byte?)(int)outputIdParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessHelper.HandleException(ex);
            }

            return educationLevelID;
        }

        public static bool Update(byte educationLevelID, string levelName)
        {
            int rowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_UpdateEducationLevel", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@EducationLevelID", educationLevelID);
                        command.Parameters.AddWithValue("@LevelName", levelName);

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

        public static bool Delete(byte? educationLevelID)
            => clsDataAccessHelper.Delete("SP_DeleteEducationLevel", "EducationLevelID", educationLevelID);

        public static bool Exists(byte? educationLevelID)
            => clsDataAccessHelper.Exists("SP_DoesEducationLevelExistByEducationLevelID", "EducationLevelID", educationLevelID);

        public static bool Exists(string levelName)
            => clsDataAccessHelper.Exists("SP_DoesEducationLevelExistByEducationLevelName", "EducationLevelName", levelName);

        public static DataTable All()
            => clsDataAccessHelper.All("SP_GetAllEducationLevels");

        public static DataTable AllOnlyNames()
            => clsDataAccessHelper.All("SP_GetAllEducationLevelsName");

        public static string GetEducationLevelName(byte? educationLevelID)
        {
            string levelName = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetEducationLevelName", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@EducationLevelID", educationLevelID);

                        SqlParameter outputIdParam = new SqlParameter("@LevelName", SqlDbType.NVarChar, 50)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        command.ExecuteNonQuery();

                        levelName = outputIdParam.Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessHelper.HandleException(ex);
            }

            return levelName;
        }

        public static byte? GetEducationLevelID(string educationLevelName)
        {
            // This function will return the new person id if succeeded and null if not
            byte? educationLevelID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetEducationLevelID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@LevelName", educationLevelName);

                        SqlParameter outputIdParam = new SqlParameter("@EducationLevelID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        command.ExecuteNonQuery();

                        educationLevelID = (byte?)(int)outputIdParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessHelper.HandleException(ex);
            }

            return educationLevelID;
        }
    }
}

using System;
using System.Data;
using System.Data.SqlClient;

namespace StudyCenterDataAccess
{
    public class clsUserData
    {
        public static bool GetUserInfoByUserID(int? userID, ref int? personID, ref string username,
            ref string password, ref int permissions, ref bool isActive)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetUserInfoByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserID", (object)userID ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                isFound = true;

                                personID = (reader["PersonID"] != DBNull.Value) ? (int?)reader["PersonID"] : null;
                                username = (string)reader["Username"];
                                password = (string)reader["Password"];
                                permissions = (int)reader["Permissions"];
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
            catch (Exception ex)
            {
                isFound = false;
                clsDataAccessHelper.HandleException(ex);
            }

            return isFound;
        }

        public static bool GetUserInfoByPersonID(int? personID, ref int? userID, ref string username,
            ref string password, ref int permissions, ref bool isActive)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetUserInfoByPersonID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PersonID", (object)personID ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                isFound = true;

                                userID = (reader["UserID"] != DBNull.Value) ? (int?)reader["UserID"] : null;
                                username = (string)reader["Username"];
                                password = (string)reader["Password"];
                                permissions = (int)reader["Permissions"];
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
            catch (Exception ex)
            {
                isFound = false;
                clsDataAccessHelper.HandleException(ex);
            }

            return isFound;
        }

        public static bool GetUserInfoByUsername(ref int? userID, ref int? personID, string username,
            ref string password, ref int permissions, ref bool isActive)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetUserInfoByUsername", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Username", username);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                isFound = true;
                                userID = (reader["UserID"] != DBNull.Value) ? (int?)reader["UserID"] : null;
                                personID = (reader["PersonID"] != DBNull.Value) ? (int?)reader["PersonID"] : null;
                                password = (string)reader["Password"];
                                permissions = (int)reader["Permissions"];
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
            catch (Exception ex)
            {
                isFound = false;
                clsDataAccessHelper.HandleException(ex);
            }

            return isFound;
        }

        public static bool GetUserInfoByUsernameAndPassword(ref int? userID, ref int? personID,
            string username, string password, ref int permissions, ref bool isActive)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetUserInfoByUsernameAndPassword", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                isFound = true;
                                userID = (reader["UserID"] != DBNull.Value) ? (int?)reader["UserID"] : null;
                                personID = (reader["PersonID"] != DBNull.Value) ? (int?)reader["PersonID"] : null;
                                permissions = (int)reader["Permissions"];
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
            catch (Exception ex)
            {
                isFound = false;
                clsDataAccessHelper.HandleException(ex);
            }

            return isFound;
        }

        public static int? Add(int personID, string username, string password, int permissions,
            bool isActive)
        {
            // This function will return the new person id if succeeded and null if not
            int? userID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_AddNewUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PersonID", personID);
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);
                        command.Parameters.AddWithValue("@Permissions", permissions);
                        command.Parameters.AddWithValue("@IsActive", isActive);

                        SqlParameter outputIdParam = new SqlParameter("@NewUserID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        command.ExecuteNonQuery();

                        userID = (int?)outputIdParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessHelper.HandleException(ex);
            }

            return userID;
        }

        public static bool Update(int userID, int personID, string username, string password,
            int permissions, bool isActive)
        {
            int rowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_UpdateUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserID", userID);
                        command.Parameters.AddWithValue("@PersonID", personID);
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);
                        command.Parameters.AddWithValue("@Permissions", permissions);
                        command.Parameters.AddWithValue("@IsActive", isActive);

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

        public static bool Delete(int? userID)
            => clsDataAccessHelper.Delete("SP_DeleteUser", "UserID", userID);

        public static bool ExistsByUserID(int? userID)
            => clsDataAccessHelper.Exists("SP_DoesUserExistByUserID", "UserID", userID);

        public static bool ExistsByPersonID(int? personID)
            => clsDataAccessHelper.Exists("SP_DoesUserExistByPersonID", "PersonID", personID);

        public static bool ExistsByUsername(string username)
            => clsDataAccessHelper.Exists("SP_DoesUserExistByUsername", "Username", username);

        public static bool ExistsByUsernameAndPassword(string username, string password)
            => clsDataAccessHelper.Exists("SP_DoesUserExistByUsernameAndPassword", "Username", username, "Password", password);

        public static DataTable All()
            => clsDataAccessHelper.All("SP_GetAllUsers");

        public static int Count()
            => clsDataAccessHelper.Count("SP_GetAllUsersCount");

        public static bool ChangePassword(int? UserID, string NewPassword)
        {
            int RowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_ChangePassword", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserID", (object)UserID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@NewPassword", NewPassword);

                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessHelper.HandleException(ex);
            }

            return (RowAffected > 0);
        }
    }
}
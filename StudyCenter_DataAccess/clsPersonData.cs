using System;
using System.Data;
using System.Data.SqlClient;

namespace StudyCenter_DataAccess
{
    public class clsPersonData
    {
        public static bool GetInfoByID(int? personID, ref string firstName, ref string secondName, ref string thirdName, ref string lastName, ref byte gender, ref DateTime dateOfBirth, ref string phoneNumber, ref string email, ref string address)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetPersonInfoByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PersonID", (object)personID ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                isFound = true;

                                firstName = (string)reader["FirstName"];
                                secondName = (string)reader["SecondName"];
                                thirdName = (reader["ThirdName"] != DBNull.Value) ? (string)reader["ThirdName"] : null;
                                lastName = (string)reader["LastName"];
                                gender = (byte)reader["Gender"];
                                dateOfBirth = (DateTime)reader["DateOfBirth"];
                                phoneNumber = (string)reader["PhoneNumber"];
                                email = (reader["Email"] != DBNull.Value) ? (string)reader["Email"] : null;
                                address = (reader["Address"] != DBNull.Value) ? (string)reader["Address"] : null;
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

        public static int? Add(string firstName, string secondName, string thirdName, string lastName, byte gender, DateTime dateOfBirth, string phoneNumber, string email, string address)
        {
            // This function will return the new person id if succeeded and null if not
            int? personID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_AddNewPerson", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@SecondName", secondName);
                        command.Parameters.AddWithValue("@ThirdName", (object)thirdName ?? DBNull.Value);
                        command.Parameters.AddWithValue("@LastName", lastName);
                        command.Parameters.AddWithValue("@Gender", gender);
                        command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                        command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        command.Parameters.AddWithValue("@Email", (object)email ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Address", (object)address ?? DBNull.Value);

                        SqlParameter outputIdParam = new SqlParameter("@NewPersonID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        command.ExecuteNonQuery();

                        personID = (int?)outputIdParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessHelper.HandleException(ex);
            }

            return personID;
        }

        public static bool Update(int? personID, string firstName, string secondName, string thirdName, string lastName, byte gender, DateTime dateOfBirth, string phoneNumber, string email, string address)
        {
            int rowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_UpdatePerson", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PersonID", (object)personID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@SecondName", secondName);
                        command.Parameters.AddWithValue("@ThirdName", (object)thirdName ?? DBNull.Value);
                        command.Parameters.AddWithValue("@LastName", lastName);
                        command.Parameters.AddWithValue("@Gender", gender);
                        command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                        command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        command.Parameters.AddWithValue("@Email", (object)email ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Address", (object)address ?? DBNull.Value);

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

        public static bool Delete(int? personID)
            => clsDataAccessHelper.Delete("SP_DeletePerson", "PersonID", personID);

        public static bool Exists(int? personID)
            => clsDataAccessHelper.Exists("SP_DoesPersonExist", "PersonID", personID);

        public static DataTable All()
            => clsDataAccessHelper.All("SP_GetAllPeople");
    }
}
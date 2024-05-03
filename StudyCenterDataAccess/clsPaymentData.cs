using System;
using System.Data;
using System.Data.SqlClient;

namespace StudyCenterDataAccess
{
    public class clsPaymentData
    {
        public static bool GetInfoByID(int? paymentID, ref int? studentGroupID,
            ref int? subjectGradeLevelID, ref decimal paymentAmount,
            ref DateTime paymentDate, ref int? createdByUserID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetPaymentInfoByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PaymentID", (object)paymentID ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                isFound = true;

                                studentGroupID = (reader["StudentGroupID"] != DBNull.Value) ? (int?)reader["StudentGroupID"] : null;
                                subjectGradeLevelID = (reader["SubjectGradeLevelID"] != DBNull.Value) ? (int?)reader["SubjectGradeLevelID"] : null;
                                paymentAmount = (decimal)reader["PaymentAmount"];
                                paymentDate = (DateTime)reader["PaymentDate"];
                                createdByUserID = (reader["CreatedByUserID"] != DBNull.Value) ? (int?)reader["CreatedByUserID"] : null;
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

        public static int? Add(int? studentGroupID, int? subjectGradeLevelID,
            decimal paymentAmount, int? createdByUserID)
        {
            // This function will return the new person id if succeeded and null if not
            int? paymentID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_AddNewPayment", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@StudentGroupID", (object)studentGroupID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@SubjectGradeLevelID", (object)subjectGradeLevelID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@PaymentAmount", paymentAmount);
                        command.Parameters.AddWithValue("@CreatedByUserID", (object)createdByUserID ?? DBNull.Value);

                        SqlParameter outputIdParam = new SqlParameter("@NewPaymentID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        command.ExecuteNonQuery();

                        paymentID = (int?)outputIdParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessHelper.HandleException(ex);
            }

            return paymentID;
        }

        public static bool Update(int? paymentID, int? studentGroupID,
            int? subjectGradeLevelID, decimal paymentAmount, int? createdByUserID)
        {
            int rowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_UpdatePayment", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@PaymentID", (object)paymentID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@StudentGroupID", studentGroupID);
                        command.Parameters.AddWithValue("@SubjectGradeLevelID", subjectGradeLevelID);
                        command.Parameters.AddWithValue("@PaymentAmount", paymentAmount);
                        command.Parameters.AddWithValue("@CreatedByUserID", createdByUserID);

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

        public static bool Delete(int? paymentID)
        => clsDataAccessHelper.Delete("SP_DeletePayment", "PaymentID", paymentID);

        public static bool Exists(int? paymentID)
        => clsDataAccessHelper.Exists("SP_DoesPaymentExist", "PaymentID", paymentID);

        public static DataTable All()
        => clsDataAccessHelper.All("SP_GetAllPayments");

        public static DataTable AllInPages(short PageNumber, int RowsPerPage)
           => clsDataAccessHelper.AllInPages(PageNumber, RowsPerPage, "SP_GetAllPaymentsInPages");

        public static int Count()
            => clsDataAccessHelper.Count("SP_GetAllPaymentsCount");
    }
}
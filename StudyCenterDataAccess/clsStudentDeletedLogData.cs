using System;
using System.Data;
using System.Data.SqlClient;

namespace StudyCenterDataAccess
{
    public class clsStudentDeletedLogData
    {
        public static bool GetInfoByID(int? logID, ref int studentID,
            ref string studentName, ref int gradeLevelID,
            ref int createdByUserID, ref int deletedByUserID,
            ref DateTime creationDate, ref DateTime deletionDate)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetStudentDeletedLogInfoByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@LogID", (object)logID ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                isFound = true;

                                studentID = (int)reader["StudentID"];
                                studentName = (string)reader["StudentName"];
                                gradeLevelID = (int)reader["GradeLevelID"];
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
            catch (Exception ex)
            {
                isFound = false;
                clsDataAccessHelper.HandleException(ex);
            }

            return isFound;
        }

        public static DataTable All()
            => clsDataAccessHelper.All("SP_GetAllStudentDeletedLog");
    }
}

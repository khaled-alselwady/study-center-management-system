using System;
using System.Data;
using System.Data.SqlClient;

namespace StudyCenterDataAccess
{
    public class clsStudentGroupData
    {
        public static bool GetInfoByID(int? studentGroupID, ref int? studentID,
            ref int? groupID, ref DateTime startDate,
            ref DateTime? endDate, ref bool isActive, ref int? CreatedByUserID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetStudentGroupInfoByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@StudentGroupID", (object)studentGroupID ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                isFound = true;

                                studentID = (reader["StudentID"] != DBNull.Value) ? (int?)reader["StudentID"] : null;
                                groupID = (reader["GroupID"] != DBNull.Value) ? (int?)reader["GroupID"] : null;
                                startDate = (DateTime)reader["StartDate"];
                                endDate = (reader["EndDate"] != DBNull.Value) ? (DateTime?)reader["EndDate"] : null;
                                isActive = (bool)reader["IsActive"];
                                CreatedByUserID = (reader["CreatedByUserID"] != DBNull.Value) ? (int?)reader["CreatedByUserID"] : null;
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

        public static int? Add(int studentID, int groupID, int CreatedByUserID)
        {
            // This function will return the new person id if succeeded and null if not
            int? studentGroupID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_AddNewStudentGroup", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@StudentID", studentID);
                        command.Parameters.AddWithValue("@GroupID", groupID);
                        command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


                        SqlParameter outputIdParam = new SqlParameter("@NewStudentGroupID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        command.ExecuteNonQuery();

                        studentGroupID = (int?)outputIdParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessHelper.HandleException(ex);
            }

            return studentGroupID;
        }

        public static bool Update(int studentGroupID, int studentID, int groupID,
            DateTime? endDate, bool isActive)
        {
            int rowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_UpdateStudentGroup", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@StudentGroupID", studentGroupID);
                        command.Parameters.AddWithValue("@StudentID", studentID);
                        command.Parameters.AddWithValue("@GroupID", groupID);
                        command.Parameters.AddWithValue("@EndDate", (object)endDate ?? DBNull.Value);
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

        public static bool Delete(int? studentGroupID)
            => clsDataAccessHelper.Delete("SP_DeleteStudentGroupByStudentGroupID", "StudentGroupID", studentGroupID);

        public static bool Delete(int? studentID, int? groupID)
        {
            int rowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_DeleteStudentGroupByStudentIDAndGroupID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue($"@StudentID", (object)studentID ?? DBNull.Value);
                        command.Parameters.AddWithValue($"@GroupID", (object)groupID ?? DBNull.Value);

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

        public static bool Exists(int? studentGroupID)
            => clsDataAccessHelper.Exists("SP_DoesStudentGroupExist", "StudentGroupID", studentGroupID);

        public static bool IsStudentAssignedToGroup(int? studentID, int? groupID)
            => clsDataAccessHelper.Exists("SP_IsStudentAssignedToGroup",
                "StudentID", studentID, "GroupID", groupID);

        public static DataTable All()
            => clsDataAccessHelper.All("SP_GetAllStudentsGroups");

        public static DataTable AllAvailableGroupsForStudent(int? studentID)
            => clsDataAccessHelper.All("SP_GetAvailableGroupsForStudent", "StudentID", studentID);
    }
}
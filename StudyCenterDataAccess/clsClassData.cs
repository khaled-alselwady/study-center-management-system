using System;
using System.Data;
using System.Data.SqlClient;

namespace StudyCenterDataAccess
{
    public class clsClassData
    {
        public static bool GetInfoByID(int? classID, ref string className, ref byte capacity, ref string description)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetClassInfoByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ClassID", (object)classID ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                isFound = true;

                                className = (string)reader["ClassName"];
                                capacity = (byte)reader["Capacity"];
                                description = (reader["Description"] != DBNull.Value) ? (string)reader["Description"] : null;
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

        public static int? Add(string className, byte capacity, string description)
        {
            // This function will return the new person id if succeeded and null if not
            int? classID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_AddNewClass", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ClassName", className);
                        command.Parameters.AddWithValue("@Capacity", capacity);
                        command.Parameters.AddWithValue("@Description", (object)description ?? DBNull.Value);

                        SqlParameter outputIdParam = new SqlParameter("@NewClassID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        command.ExecuteNonQuery();

                        classID = (int?)outputIdParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessHelper.HandleException(ex);
            }

            return classID;
        }

        public static bool Update(int? classID, string className, byte capacity, string description)
        {
            int rowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_UpdateClass", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ClassID", (object)classID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ClassName", className);
                        command.Parameters.AddWithValue("@Capacity", capacity);
                        command.Parameters.AddWithValue("@Description", (object)description ?? DBNull.Value);

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

        public static bool Delete(int? classID)
            => clsDataAccessHelper.Delete("SP_DeleteClass", "ClassID", classID);

        public static bool Exists(int? classID)
            => clsDataAccessHelper.Exists("SP_DoesClassExistByClassID", "ClassID", classID);

        public static bool Exists(string className)
            => clsDataAccessHelper.Exists("SP_DoesClassExistByClassName", "ClassName", className);

        public static DataTable All()
            => clsDataAccessHelper.All("SP_GetAllClasses");

        public static int Count()
            => clsDataAccessHelper.Count("SP_GetAllClassesCount");

        public static DataTable AllInPages(short PageNumber, int RowsPerPage)
            => clsDataAccessHelper.AllInPages(PageNumber, RowsPerPage, "SP_GetAllClassesInPages");

        public static DataTable AllTeachersTeachInClass(int? classID)
            => clsDataAccessHelper.All("SP_TeachersTeachInClass", "ClassID", classID);

        public static DataTable AllClassesAreTaughtByTeacher(int? teacherID)
            => clsDataAccessHelper.All("SP_ClassesAreTaughtByTeacher", "TeacherID", teacherID);

        public static DataTable AllActiveGroupsInClass(int? classID)
            => clsDataAccessHelper.All("SP_GetAllActiveGroupsInClass", "ClassID", classID);

        public static bool DoesGroupNameExistInClass(int? classID, string groupName)
            => clsDataAccessHelper.Exists("SP_DoesGroupNameExistInClass", "ClassID", classID, "GroupName", groupName);
    }
}
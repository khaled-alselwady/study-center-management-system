using System;
using System.Data;
using System.Data.SqlClient;

namespace StudyCenterDataAccess
{
    public class clsSubjectGradeLevelData
    {
        public static bool GetInfoByID(int? subjectGradeLevelID, ref int? subjectID,
            ref byte? gradeLevelID, ref decimal fees, ref string description)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetSubjectGradeLevelInfoByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@SubjectGradeLevelID", (object)subjectGradeLevelID ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                isFound = true;

                                subjectID = (reader["SubjectID"] != DBNull.Value) ? (int?)reader["SubjectID"] : null;
                                gradeLevelID = (reader["GradeLevelID"] != DBNull.Value) ? (byte?)Convert.ToByte(reader["GradeLevelID"]) : null;
                                fees = (decimal)reader["Fees"];
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

        public static int? Add(int? subjectID, byte? gradeLevelID, decimal fees, string description)
        {
            // This function will return the new person id if succeeded and null if not
            int? subjectGradeLevelID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_AddNewSubjectGradeLevel", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@SubjectID", (object)subjectID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@GradeLevelID", (object)gradeLevelID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Fees", fees);
                        command.Parameters.AddWithValue("@Description", (object)description ?? DBNull.Value);

                        SqlParameter outputIdParam = new SqlParameter("@NewSubjectGradeLevelID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        command.ExecuteNonQuery();

                        subjectGradeLevelID = (int?)outputIdParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessHelper.HandleException(ex);
            }

            return subjectGradeLevelID;
        }

        public static bool Update(int? subjectGradeLevelID, int? subjectID, byte? gradeLevelID,
            decimal fees, string description)
        {
            int rowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_UpdateSubjectGradeLevel", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@SubjectGradeLevelID", (object)subjectGradeLevelID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@SubjectID", (object)subjectID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@GradeLevelID", (object)gradeLevelID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Fees", fees);
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

        public static bool Delete(int? subjectGradeLevelID)
            => clsDataAccessHelper.Delete("SP_DeleteSubjectGradeLevel", "SubjectGradeLevelID", subjectGradeLevelID);

        public static bool Exists(int? subjectGradeLevelID)
            => clsDataAccessHelper.Exists("SP_DoesSubjectGradeLevelExistBySubjectGradeLevelID",
                                          "SubjectGradeLevelID", subjectGradeLevelID);

        public static bool Exists(int? subjectID, int? gradeLevelID)
            => clsDataAccessHelper.Exists("SP_DoesSubjectGradeLevelExistBySubjectIDAndGradeLevelID",
                                          "SubjectID", subjectID, "GradeLevelID", gradeLevelID);

        public static DataTable AllInPages(short pageNumber, int rowsPerPage)
            => clsDataAccessHelper.AllInPages(pageNumber, rowsPerPage, "SP_GetAllSubjectsGradeLevelsInPages");

        public static DataTable AllUntaughtSubjectsByTeacher(int? teacherID)
            => clsDataAccessHelper.All("SP_GetUntaughtSubjectsByTeacher", "TeacherID", teacherID);

        public static DataTable AllTeachersTeachSubject(int? subjectGradeLevelID)
            => clsDataAccessHelper.All("SP_GetAllTeachersTeachSubject", "SubjectGradeLevelID", subjectGradeLevelID);

        public static int Count()
            => clsDataAccessHelper.Count("[SP_GetAllSubjectsGradeLevelsCount]");
    }
}
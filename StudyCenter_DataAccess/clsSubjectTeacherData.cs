using System;
using System.Data;
using System.Data.SqlClient;

namespace StudyCenter_DataAccess
{
    public class clsSubjectTeacherData
    {
        public static bool GetInfoByID(int? subjectTeacherID, ref int? subjectGradeLevelID,
            ref int? teacherID, ref DateTime assignmentDate,
            ref DateTime? lastModifiedDate, ref bool isActive)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetSubjectTeacherInfoByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@SubjectTeacherID", (object)subjectTeacherID ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                isFound = true;

                                subjectGradeLevelID = (reader["SubjectGradeLevelID"] != DBNull.Value) ? (int?)reader["SubjectGradeLevelID"] : null;
                                teacherID = (reader["TeacherID"] != DBNull.Value) ? (int?)reader["TeacherID"] : null;
                                assignmentDate = (DateTime)reader["AssignmentDate"];
                                lastModifiedDate = (reader["LastModifiedDate"] != DBNull.Value) ? (DateTime?)reader["LastModifiedDate"] : null;
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

        public static int? Add(int? subjectGradeLevelID, int? teacherID)
        {
            // This function will return the new person id if succeeded and null if not
            int? subjectTeacherID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_AddNewSubjectTeacher", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@SubjectGradeLevelID", (object)subjectGradeLevelID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@TeacherID", (object)teacherID ?? DBNull.Value);

                        SqlParameter outputIdParam = new SqlParameter("@NewSubjectTeacherID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        command.ExecuteNonQuery();

                        subjectTeacherID = (int?)outputIdParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessHelper.HandleException(ex);
            }

            return subjectTeacherID;
        }

        public static bool Update(int? subjectTeacherID, int? subjectGradeLevelID,
            int? teacherID, bool isActive)
        {
            int rowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_UpdateSubjectTeacher", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@SubjectTeacherID", (object)subjectTeacherID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@SubjectGradeLevelID", (object)subjectGradeLevelID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@TeacherID", (object)teacherID ?? DBNull.Value);
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

        public static bool Delete(int? subjectTeacherID)
            => clsDataAccessHelper.Delete("SP_DeleteSubjectTeacher", "SubjectTeacherID", subjectTeacherID);

        public static bool Exists(int? subjectTeacherID)
            => clsDataAccessHelper.Exists("SP_DoesSubjectTeacherExist", "SubjectTeacherID", subjectTeacherID);

        public static DataTable All()
            => clsDataAccessHelper.All("SP_GetAllSubjectsTeachers");

        public static bool IsTeachingSubject(int? teacherID, int? subjectGradeLevelID)
            => clsDataAccessHelper.Exists("SP_IsTeachingSubject", "TeacherID", teacherID, "SubjectGradeLevelID", subjectGradeLevelID);
    }
}
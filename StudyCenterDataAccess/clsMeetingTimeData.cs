using System;
using System.Data;
using System.Data.SqlClient;

namespace StudyCenterDataAccess
{
    public class clsMeetingTimeData
    {
        public static bool GetInfoByID(int? meetingTimeID, ref TimeSpan startTime, ref TimeSpan endTime, ref byte meetingDays)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetMeetingTimeInfoByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@MeetingTimeID", (object)meetingTimeID ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                isFound = true;

                                startTime = (TimeSpan)reader["StartTime"];
                                endTime = (TimeSpan)reader["EndTime"];
                                meetingDays = (byte)reader["MeetingDays"];
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

        public static int? Add(TimeSpan startTime, TimeSpan endTime, byte meetingDays)
        {
            // This function will return the new person id if succeeded and null if not
            int? meetingTimeID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_AddNewMeetingTime", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@StartTime", startTime);
                        command.Parameters.AddWithValue("@EndTime", endTime);
                        command.Parameters.AddWithValue("@MeetingDays", meetingDays);

                        SqlParameter outputIdParam = new SqlParameter("@NewMeetingTimeID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        command.ExecuteNonQuery();

                        meetingTimeID = (int?)outputIdParam.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessHelper.HandleException(ex);
            }

            return meetingTimeID;
        }

        public static bool Update(int meetingTimeID, TimeSpan startTime, TimeSpan endTime, byte meetingDays)
        {
            int rowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_UpdateMeetingTime", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@MeetingTimeID", meetingTimeID);
                        command.Parameters.AddWithValue("@StartTime", startTime);
                        command.Parameters.AddWithValue("@EndTime", endTime);
                        command.Parameters.AddWithValue("@MeetingDays", meetingDays);

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

        public static bool Delete(int? meetingTimeID)
            => clsDataAccessHelper.Delete("SP_DeleteMeetingTime", "MeetingTimeID", meetingTimeID);

        public static bool Exists(int? meetingTimeID)
            => clsDataAccessHelper.Exists("SP_DoesMeetingTimeExistByMeetingTimeID", "MeetingTimeID", meetingTimeID);

        public static bool Exists(TimeSpan startTime, byte meetingDays)
            => clsDataAccessHelper.Exists("SP_DoesMeetingTimeExistByStartTimeAndMeetingDays", "StartTime", startTime, "MeetingDays", meetingDays);

        public static DataTable All()
            => clsDataAccessHelper.All("SP_GetAllMeetingTimes");

        public static DataTable AllWithoutTeacherOrClass(int? teacherID, int? classID)
            => clsDataAccessHelper.All("SP_GetMeetingTimesWithoutTeacherOrClass",
                                       "TeacherID", teacherID, "ClassID", classID);
    }
}
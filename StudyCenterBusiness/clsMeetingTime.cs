using StudyCenterDataAccess;
using System;
using System.Data;

namespace StudyCenterBusiness
{
    public class clsMeetingTime
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? MeetingTimeID { get; set; }

        private TimeSpan _oldStartTime = TimeSpan.Zero;
        private TimeSpan _startTime = TimeSpan.Zero;
        public TimeSpan StartTime
        {
            get => _startTime;

            set
            {
                if (_oldStartTime != TimeSpan.Zero)
                {
                    _oldStartTime = _startTime;
                }

                _startTime = value;
            }
        }

        public TimeSpan EndTime { get; set; }

        private byte? _oldMeetingDays = null;
        private byte? _meetingDays = null;
        public byte MeetingDays
        {
            get => _meetingDays ?? 0;

            set
            {
                if (!_oldMeetingDays.HasValue)
                {
                    _oldMeetingDays = _meetingDays;
                }

                _meetingDays = value;
            }
        }

        public clsMeetingTime()
        {
            MeetingTimeID = null;
            StartTime = DateTime.Now.TimeOfDay;
            EndTime = DateTime.Now.TimeOfDay;
            MeetingDays = 0;

            Mode = enMode.AddNew;
        }

        private clsMeetingTime(int? meetingTimeID, TimeSpan startTime, TimeSpan endTime, byte meetingDays)
        {
            MeetingTimeID = meetingTimeID;
            StartTime = startTime;
            EndTime = endTime;
            MeetingDays = meetingDays;

            Mode = enMode.Update;
        }

        private bool _Validate()
        {
            if (Mode == enMode.Update && !MeetingTimeID.HasValue)
            {
                return false;
            }

            if (StartTime >= EndTime)
            {
                return false;
            }

            if (MeetingDays < 0 || MeetingDays > 2) //  (0 => Daily)    (1 => STT)   (2 => MW)
            {
                return false;
            }

            if ((Mode == enMode.AddNew) || (_oldStartTime != _startTime || _oldMeetingDays != _meetingDays))
            {
                if (Exists(_startTime, MeetingDays))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Validates the current instance of <see cref="clsMeetingTime"/> using the <see cref="clsValidationHelper"/>.
        /// </summary>
        /// <returns>
        /// Returns true if the current instance passes all validation checks; otherwise, false.
        /// </returns>
        private bool _ValidateUsingHelperClass()
        {
            return clsValidationHelper.Validate
            (
            this,

            // ID Check: Ensure MeetingTimeID is valid if in Update mode
            idCheck: mt => (mt.Mode != enMode.Update) || clsValidationHelper.HasValue(mt.MeetingTimeID),

            // Value Check: Ensure StartTime is before EndTime and MeetingDays is within valid range
            valueCheck: mt => mt.StartTime < mt.EndTime && (mt.MeetingDays >= 0 && mt.MeetingDays <= 2),

            // Additional Checks: Ensure the meeting time does not already exist in the database
            additionalChecks: new (Func<clsMeetingTime, bool>, string)[]
            {
                (mt => (mt.Mode != enMode.AddNew && _oldStartTime == mt.StartTime && _oldMeetingDays == mt.MeetingDays) ||
                       !clsValidationHelper.ExistsInDatabase(() => Exists(mt.StartTime, mt.MeetingDays)),
                       "Meeting time already exists.")
            }
            );
        }

        private bool _Add()
        {
            MeetingTimeID = clsMeetingTimeData.Add(StartTime, EndTime, MeetingDays);

            return (MeetingTimeID.HasValue);
        }

        private bool _Update()
        {
            return clsMeetingTimeData.Update(MeetingTimeID.Value, StartTime, EndTime, MeetingDays);
        }

        public bool Save()
        {
            if (!_ValidateUsingHelperClass())
            {
                return false;
            }

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_Add())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _Update();
            }

            return false;
        }

        public static clsMeetingTime Find(int? meetingTimeID)
        {
            TimeSpan startTime = DateTime.Now.TimeOfDay;
            TimeSpan endTime = DateTime.Now.TimeOfDay;
            byte meetingDays = 0;

            bool isFound = clsMeetingTimeData.GetInfoByID(meetingTimeID, ref startTime, ref endTime, ref meetingDays);

            return (isFound) ? (new clsMeetingTime(meetingTimeID, startTime, endTime, meetingDays)) : null;
        }

        public static bool Delete(int? meetingTimeID)
            => clsMeetingTimeData.Delete(meetingTimeID);

        public static bool Exists(int? meetingTimeID)
            => clsMeetingTimeData.Exists(meetingTimeID);

        public static bool Exists(TimeSpan startTime, byte meetingDays)
            => clsMeetingTimeData.Exists(startTime, meetingDays);

        public static DataTable All()
            => clsMeetingTimeData.All();

        public static DataTable AllWithoutTeacherOrClass(int? teacherID, int? classID)
            => clsMeetingTimeData.AllWithoutTeacherOrClass(teacherID, classID);

        public static string MeetingDayText(byte meetingDayIndex)
        {
            switch (meetingDayIndex)
            {
                case 0:
                    return "Daily";
                case 1:
                    return "STT";
                case 2:
                    return "MW";
                default:
                    return "Unknown";
            }
        }

        public static byte MeetingDayIndex(string meetingDayName)
        {
            switch (meetingDayName.ToUpper())
            {
                case "DAILY":
                    return 0;
                case "STT":
                    return 1;
                case "MW":
                    return 2;
                default:
                    return 0;
            }
        }

        public string MeetingTimeText()
            => $"{StartTime.Hours.ToString("00")}:{StartTime.Minutes.ToString("00")} - " +
               $"{EndTime.Hours.ToString("00")}:{EndTime.Minutes.ToString("00")}   " +
               $"{MeetingDayText(MeetingDays)}";
    }

}
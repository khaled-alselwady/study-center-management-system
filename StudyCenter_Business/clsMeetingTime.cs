using StudyCenter_DataAccess;
using System;
using System.Data;

namespace StudyCenter_Business
{
public class clsMeetingTime
{
public enum enMode { AddNew = 0, Update = 1 };
public enMode Mode = enMode.AddNew;

public int? MeetingTimeID { get; set; }
public TimeSpan StartTime { get; set; }
public TimeSpan EndTime { get; set; }
public byte MeetingDays { get; set; }

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

private bool _Add()
{
    MeetingTimeID = clsMeetingTimeData.Add(StartTime, EndTime, MeetingDays);

    return (MeetingTimeID.HasValue);
}

private bool _Update()
{
return clsMeetingTimeData.Update(MeetingTimeID, StartTime, EndTime, MeetingDays);
}

public bool Save()
{
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
{
return clsMeetingTimeData.Delete(meetingTimeID);
}

public static bool Exists(int? meetingTimeID)
{
return clsMeetingTimeData.Exists(meetingTimeID);
}

public static DataTable All()
{
return clsMeetingTimeData.All();
}

}

}
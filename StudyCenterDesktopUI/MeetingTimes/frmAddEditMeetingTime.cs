using StudyCenterBusiness;
using StudyCenterDesktopUI.GlobalClasses;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace StudyCenterDesktopUI.MeetingTimes
{
    public partial class frmAddEditMeetingTime : Form
    {
        public Action<int?> MeetingTimeIDBack;

        private const string DAILYLectureDurationInHour = "DailyLectureDurationInHour";
        private const string STTLectureDurationInHour = "STTLectureDurationInHour";
        private const string MWLectureDurationInHour = "MWLectureDurationInHour";

        private enum _enMode { Add, Update };
        private _enMode _mode = _enMode.Add;

        private int? _meetingTimeID = null;
        private clsMeetingTime _meetingTime = null;

        public frmAddEditMeetingTime()
        {
            InitializeComponent();

            _mode = _enMode.Add;
        }

        public frmAddEditMeetingTime(int? meetingTimeID)
        {
            InitializeComponent();

            _meetingTimeID = meetingTimeID;
            _mode = _enMode.Update;
        }

        private DateTime _ConvertStringToDateTime(string stringDate)
        {
            return DateTime.ParseExact(stringDate, "hh:mm tt", null);
        }

        private void _ResetFields()
        {
            cbMeetingDays.SelectedIndex = 0;
            lblMeetingTimeID.Text = "N/A";

            dtpStartTime.MinDate = _ConvertStringToDateTime(ConfigurationManager.AppSettings["StudyCenterOpeningTime"]);

            // Subtract the longest lecture duration from the closing time
            DateTime closingDateTime = _ConvertStringToDateTime(ConfigurationManager.AppSettings["StudyCenterClosingTime"]);
            dtpStartTime.MaxDate = closingDateTime.AddHours(-Math.Ceiling(_GetLectureDuration(MWLectureDurationInHour)));
        }

        private void _ResetDefaultValues()
        {
            if (_mode == _enMode.Add)
            {
                lblTitle.Text = "Add New MeetingTime";
                _meetingTime = new clsMeetingTime();

                _ResetFields();
                _UpdateEndTimeValue();
            }
            else
            {
                lblTitle.Text = "Update MeetingTime";
            }

            Text = lblTitle.Text;
        }

        private void _FillFieldsWithMeetingTimeInfo()
        {
            lblMeetingTimeID.Text = _meetingTime.MeetingTimeID.ToString();
            cbMeetingDays.SelectedIndex = cbMeetingDays.FindString(clsMeetingTime.MeetingDayText(_meetingTime.MeetingDays));
            dtpStartTime.Value = (DateTime.Now + _meetingTime.StartTime);
            lblEndTime.Text = _meetingTime.EndTime.ToString();
        }

        private void _LoadData()
        {
            _meetingTime = clsMeetingTime.Find(_meetingTimeID);

            if (_meetingTime == null)
            {
                clsStandardMessages.ShowMissingDataMessage("MeetingTime", _meetingTimeID);

                this.Close();
                return;
            }

            _FillFieldsWithMeetingTimeInfo();
        }

        private TimeSpan _GetTimeFromDateTimePickerOfStartingTime()
        {
            int hours = dtpStartTime.Value.Hour;
            int minutes = dtpStartTime.Value.Minute;

            return new TimeSpan(hours, minutes, 0);
        }

        private void _FillMeetingTimeObjectWithFieldsData()
        {
            _meetingTime.MeetingDays = clsMeetingTime.MeetingDayIndex(cbMeetingDays.Text.Trim());
            _meetingTime.StartTime = _GetTimeFromDateTimePickerOfStartingTime();

            _meetingTime.EndTime = _GetEndTimeValue();
        }

        private TimeSpan _GetEndTimeValue()
        {
            if (TimeSpan.TryParse(lblEndTime.Text, out TimeSpan endTime))
            {
                return endTime;
            }
            else
            {
                return _meetingTime.StartTime.Add(new TimeSpan(1, 0, 0)); // add one hour of the start time to the end time
            }
        }

        private void _SaveMeetingTime()
        {
            _FillMeetingTimeObjectWithFieldsData();

            if (_meetingTime.Save())
            {
                lblTitle.Text = "Update MeetingTime";
                this.Text = lblTitle.Text;
                lblMeetingTimeID.Text = _meetingTime.MeetingTimeID.ToString();

                // change form mode to update
                _mode = _enMode.Update;

                clsStandardMessages.ShowSuccess("MeetingTime");

                // Trigger the event to send data back to the caller form
                MeetingTimeIDBack?.Invoke(_meetingTime?.MeetingTimeID);
            }
            else
            {
                clsStandardMessages.ShowError("MeetingTime");
            }
        }

        private void _AddLectureDurationToEndTimeLabel(float lectureDurationInHour)
        {
            TimeSpan startTime = _GetTimeFromDateTimePickerOfStartingTime();
            TimeSpan endTime = new TimeSpan();
            float decimalPart = lectureDurationInHour - (int)lectureDurationInHour;

            if (decimalPart == 0)
            {
                endTime = startTime.Add(new TimeSpan((int)lectureDurationInHour, 0, 0));
            }
            else
            {
                // we have minutes, for example (lectureDurationInHour = 1.5)
                endTime = startTime.Add(new TimeSpan((int)lectureDurationInHour, 30, 0));
            }

            DateTime referenceTime = DateTime.Today.Add(endTime);
            lblEndTime.Text = referenceTime.ToString("hh:mm tt");
        }

        private void _RoundDateTimePickerOfStartingTimeToNearestHalfHour()
        {
            DateTime currentValue = dtpStartTime.Value;

            // Round the minutes to the nearest 30-minute increment
            int minutes = currentValue.Minute;
            int adjustedMinutes = (minutes < 15) ? 0 : ((minutes < 45) ? 30 : 0);

            // If we rolled over to 0 minutes, add an hour if it was 45 or higher
            if (adjustedMinutes == 0 && minutes >= 45)
            {
                currentValue = currentValue.AddHours(1);
            }

            // Create the new DateTime with adjusted minutes
            DateTime newDateTime = new DateTime(
                currentValue.Year,
                currentValue.Month,
                currentValue.Day,
                currentValue.Hour,
                adjustedMinutes,
                0
            );

            dtpStartTime.Value = newDateTime;
        }

        private void _UpdateEndTimeValue()
        {
            switch (cbMeetingDays.Text.ToUpper())
            {
                case "DAILY":
                    _AddLectureDurationToEndTimeLabel(_GetLectureDuration(DAILYLectureDurationInHour));
                    break;

                case "STT":
                    _AddLectureDurationToEndTimeLabel(_GetLectureDuration(STTLectureDurationInHour));
                    break;

                case "MW":
                    _AddLectureDurationToEndTimeLabel(_GetLectureDuration(MWLectureDurationInHour));
                    break;
            }
        }

        private float _GetLectureDuration(string lectureType)
        {
            if (float.TryParse(ConfigurationManager.AppSettings[lectureType], out float lectureDuration))
            {
                return lectureDuration;
            }

            return 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmAddEditMeetingTime_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_mode == _enMode.Update)
                _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            byte meetingTimeIndex = clsMeetingTime.MeetingDayIndex(cbMeetingDays.Text.Trim());

            if (clsMeetingTime.Exists(dtpStartTime.Value.TimeOfDay, meetingTimeIndex))
            {
                MessageBox.Show(
                "A meeting is already scheduled at this time. Please choose a different start time.",
                "Meeting Time Conflict",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
                               );

                return;
            }

            _SaveMeetingTime();
        }

        private void dtpStartTime_ValueChanged(object sender, EventArgs e)
        {
            _RoundDateTimePickerOfStartingTimeToNearestHalfHour();

            _UpdateEndTimeValue();
        }

        private void cbMeetingDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            _UpdateEndTimeValue();
        }
    }
}

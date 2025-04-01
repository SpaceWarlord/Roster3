using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Roster.App.ViewModels;
using Roster.App.ViewModels.Page;
using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Roster.App.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RosterPage : Page
    {
        public RosterPageViewModel ViewModel { get; set; }
        //public SchedulerViewModel ViewModel { get; set; }

        
        public RosterPage()
        {
            this.InitializeComponent();
            ViewModel = new RosterPageViewModel();
            //ViewModel = new SchedulerViewModel();
            //Schedule.ItemsSource = ViewModel.Appointments;
            AppointmentMapping appointmentMapping = new AppointmentMapping();
            appointmentMapping.Subject = "Name";
            appointmentMapping.StartTime = "StartTime";
            appointmentMapping.EndTime = "EndTime";
            appointmentMapping.AppointmentBackground = "BackgroundColor";
            appointmentMapping.Foreground = "ForegroundColor";
            appointmentMapping.IsAllDay = "IsAllDay";
            //appointmentMapping.StartTimeZone = "StartTimeZone";
            //appointmentMapping.EndTimeZone = "EndTimeZone";
            Schedule.AppointmentMapping = appointmentMapping;
            
            Schedule.ItemsSource = ViewModel.Shifts;
            //Schedule.AppointmentEditorOpening += Schedule_AppointmentEditorOpening;
            //Schedule.AppointmentEditorClosing += Schedule_AppointmentEditorClosing;
        }



        private void Schedule_AppointmentEditorOpening(object sender, AppointmentEditorOpeningEventArgs e)
        {
            //To handle the default appointment editor content dialog by setting the e.Cancel value to true.
            //e.Cancel = true;
            Debug.WriteLine("in the appointment editor");
            if (e.Appointment != null)
            {
                Debug.WriteLine("Appointment is null");
                //Display the custom appointment editor content dialog to edit the appointment.
            }
            else
            {
                //Display the custom appointment editor content dialog to add new appointment.
            }
        }

        private void Schedule_AppointmentEditorClosing(object sender, AppointmentEditorClosingEventArgs e)
        {
         //   Schedu
            var appointment = e.Appointment as ScheduleAppointment;
            //e.Handled = true;
            if (appointment != null)
            {
                //ViewModel.Shifts.Add(new ShiftViewModel(Guid.NewGuid().ToString(), appointment.Subject, appointment.StartTime.ToString(), appointment.EndTime.ToString(), 0, 0, null, null, 'a', true, null));
                Debug.WriteLine("Appointment name: " + appointment.Subject);
                /*
                if (appointment.StartTime.Day == DateTime.Now.Day)
                    e.Handled = true;
                */
            }
        }

        
    }
    //[ObservableProperty]


    public partial class Meeting:BaseViewModel
    {
        [ObservableProperty]
        private string _eventName;

        [ObservableProperty]
        private DateTime _from;

        [ObservableProperty]
        private DateTime _to;

        [ObservableProperty]
        private bool _isAllDay;

        [ObservableProperty]
        private Brush _color;

        [ObservableProperty]
        private Brush _foregroundColor;

        [ObservableProperty]
        private string _startTimeZone;

        [ObservableProperty]
        private string _endTimeZone;
    }

    public class Meeting1()
    {
        public string EventName { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public bool IsAllDay { get; set; }
        public Brush Color { get; set; }
        public Brush ForegroundColor { get; set; }
        public string StartTimeZone { get; set; }
        public string EndTimeZone { get; set; }
    }

    public class SchedulerViewModel
    {
        /// <summary>
        /// current day meetings 
        /// </summary>
        private List<string> currentDayMeetings;

        /// <summary>
        /// minimum time meetings
        /// </summary>
        private List<string> minTimeMeetings;

        /// <summary>
        /// color collection
        /// </summary>
        private List<Brush> colorCollection;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleViewModel" /> class.
        /// </summary>

        public SchedulerViewModel()
        {
            this.Appointments = new ObservableCollection<Meeting>();
            this.InitializeDataForBookings();
            this.IntializeAppoitments();
        }

        /// <summary>
        /// Gets or sets appointments.
        /// </summary>
        public ObservableCollection<Meeting> Appointments
        {
            get;
            set;
        }

        /// <summary>
        /// Method for get timing range.
        /// </summary>
        /// <returns>return time collection</returns>
        private List<Point> GettingTimeRanges()
        {
            List<Point> randomTimeCollection = new List<Point>();
            randomTimeCollection.Add(new Point(9, 11));
            randomTimeCollection.Add(new Point(12, 14));
            randomTimeCollection.Add(new Point(15, 17));

            return randomTimeCollection;
        }

        /// <summary>
        /// Method for initialize data bookings.
        /// </summary>
        private void InitializeDataForBookings()
        {
            this.currentDayMeetings = new List<string>();
            this.currentDayMeetings.Add("General Meeting");
            this.currentDayMeetings.Add("Plan Execution");
            this.currentDayMeetings.Add("Project Plan");
            this.currentDayMeetings.Add("Consulting");
            this.currentDayMeetings.Add("Performance Check");
            this.currentDayMeetings.Add("Yoga Therapy");
            this.currentDayMeetings.Add("Plan Execution");
            this.currentDayMeetings.Add("Project Plan");
            this.currentDayMeetings.Add("Consulting");
            this.currentDayMeetings.Add("Performance Check");

            // MinimumHeight Appointment Subjects
            this.minTimeMeetings = new List<string>();
            this.minTimeMeetings.Add("Client Metting");
            this.minTimeMeetings.Add("Birthday wish alert");

            this.colorCollection = new List<Brush>();
            this.colorCollection.Add(new SolidColorBrush(Color.FromArgb(255, 133, 81, 242)));
            this.colorCollection.Add(new SolidColorBrush(Color.FromArgb(255, 140, 245, 219)));
            this.colorCollection.Add(new SolidColorBrush(Color.FromArgb(255, 83, 99, 250)));
            this.colorCollection.Add(new SolidColorBrush(Color.FromArgb(255, 255, 222, 133)));
            this.colorCollection.Add(new SolidColorBrush(Color.FromArgb(255, 45, 153, 255)));
            this.colorCollection.Add(new SolidColorBrush(Color.FromArgb(255, 253, 183, 165)));
            this.colorCollection.Add(new SolidColorBrush(Color.FromArgb(255, 198, 237, 115)));
            this.colorCollection.Add(new SolidColorBrush(Color.FromArgb(255, 253, 185, 222)));
            this.colorCollection.Add(new SolidColorBrush(Color.FromArgb(255, 83, 99, 250)));
        }

        /// <summary>
        /// Initialize appointments.
        /// </summary>
        /// <param name="count">count value</param>
        private void IntializeAppoitments()
        {
            Random randomTime = new Random();
            List<Point> randomTimeCollection = this.GettingTimeRanges();

            DateTime date;
            DateTime dateFrom = DateTime.Now.AddDays(-100);
            DateTime dateTo = DateTime.Now.AddDays(100);
            var random = new Random();
            var dateCount = random.Next(4);
            DateTime dateRangeStart = DateTime.Now.AddDays(0);
            DateTime dateRangeEnd = DateTime.Now.AddDays(1);

            for (date = dateFrom; date < dateTo; date = date.AddDays(1))
            {
                if (date.Day % 7 != 0)
                {
                    for (int additionalAppointmentIndex = 0; additionalAppointmentIndex < 1; additionalAppointmentIndex++)
                    {
                        Meeting meeting = new Meeting();
                        int hour = randomTime.Next((int)randomTimeCollection[additionalAppointmentIndex].X, (int)randomTimeCollection[additionalAppointmentIndex].Y);
                        meeting.From = new DateTime(date.Year, date.Month, date.Day, hour, 0, 0);                        
                        meeting.To = meeting.From.AddHours(1);
                        meeting.EventName = this.currentDayMeetings[randomTime.Next(9)];
                        meeting.Color = this.colorCollection[randomTime.Next(9)];
                        meeting.ForegroundColor = GetAppointmentForeground(meeting.Color);
                        meeting.IsAllDay = false;
                        meeting.StartTimeZone = string.Empty;
                        meeting.EndTimeZone = string.Empty;
                        this.Appointments.Add(meeting);
                    }
                }
                else
                {
                    Meeting meeting = new Meeting();
                    meeting.From = new DateTime(date.Year, date.Month, date.Day, randomTime.Next(9, 11), 0, 0);
                    meeting.To = meeting.From.AddDays(2).AddHours(1);
                    meeting.EventName = this.currentDayMeetings[randomTime.Next(9)];
                    meeting.Color = this.colorCollection[randomTime.Next(9)];
                    meeting.ForegroundColor = GetAppointmentForeground(meeting.Color);
                    meeting.IsAllDay = true;
                    meeting.StartTimeZone = string.Empty;
                    meeting.EndTimeZone = string.Empty;
                    this.Appointments.Add(meeting);
                }
            }

            // Minimum Height Meetings.
            DateTime minDate;
            DateTime minDateFrom = DateTime.Now.AddDays(-2);
            DateTime minDateTo = DateTime.Now.AddDays(2);

            for (minDate = minDateFrom; minDate < minDateTo; minDate = minDate.AddDays(1))
            {
                Meeting meeting = new Meeting();
                meeting.From = new DateTime(minDate.Year, minDate.Month, minDate.Day, randomTime.Next(9, 18), 30, 0);
                meeting.To = meeting.From;
                meeting.EventName = this.minTimeMeetings[randomTime.Next(0, 1)];
                meeting.Color = this.colorCollection[randomTime.Next(0, 2)];
                meeting.ForegroundColor = GetAppointmentForeground(meeting.Color);
                meeting.StartTimeZone = string.Empty;
                meeting.EndTimeZone = string.Empty;

                this.Appointments.Add(meeting);
            }
        }

        /// <summary>
        /// Method to get the foreground color based on background.
        /// </summary>
        /// <param name="backgroundColor"></param>
        /// <returns></returns>
        private Brush GetAppointmentForeground(Brush backgroundColor)
        {
            if ((backgroundColor as SolidColorBrush).Color.ToString().Equals("#FF8551F2") || (backgroundColor as SolidColorBrush).ToString().Equals("#FF5363FA") || (backgroundColor as SolidColorBrush).ToString().Equals("#FF2D99FF"))
                return new SolidColorBrush(Microsoft.UI.Colors.White);
            else
                return new SolidColorBrush(Color.FromArgb(255, 51, 51, 51));
        }
    }
}

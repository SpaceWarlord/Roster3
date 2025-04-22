using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Logging;
using Microsoft.UI.Xaml.Media;
using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace Roster.App.ViewModels.Page
{
    public partial class TestPage1ViewModel:BaseViewModel
    {
        [ObservableProperty]
        private ScheduleAppointmentCollection _events;

        public ObservableCollection<object> Resources;

        public ObservableCollection<SolidColorBrush> Brushes;

        public TestPage1ViewModel()
        {
            GetBrushCollection();
            InitializeResources();
            GenerateRandomAppointments();
            DisplayDate = DateTime.Now.Date.AddHours(9);            
        }

        [ObservableProperty]
        private DateTime _displayDate;
        
        private void InitializeResources()
        {
            Resources = new ObservableCollection<object>();
            var nameCollection = new List<string>()
            {
                "Sophia",
                "Daniel",
                "James William",
                "Kinsley Ruby",
                "Emilia William",
                "Stephen",
                "Zoey Addison",
            };

            for (int i = 0; i < 6; i++)
            {
                SchedulerResource employee = new SchedulerResource();
                employee.Name = nameCollection[i];
                employee.Background = Brushes[i];
                employee.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                employee.Id = i.ToString();
                Resources.Add(employee);
            }
        }

        private void GenerateRandomAppointments()
        {
            var subjectCollection = new List<string>();
            subjectCollection.Add("General Meeting");
            subjectCollection.Add("Plan Execution");
            subjectCollection.Add("Project Plan");
            subjectCollection.Add("Consulting");
            subjectCollection.Add("Performance Check");
            subjectCollection.Add("Yoga Therapy");
            subjectCollection.Add("Plan Execution");
            subjectCollection.Add("General Meeting");
            subjectCollection.Add("Consulting");
            subjectCollection.Add("Performance Check");

            Random randomTime = new Random();
            Events = new ScheduleAppointmentCollection();
            DateTime date;
            DateTime dateFrom = DateTime.Now.AddDays(-80);
            DateTime dateTo = DateTime.Now.AddDays(80);
            DateTime dateRangeStart = DateTime.Now.AddDays(-70);
            DateTime dateRangeEnd = DateTime.Now.AddDays(70);

            for (date = dateFrom; date < dateTo; date = date.AddDays(1))
            {
                if ((DateTime.Compare(date, dateRangeStart) > 0) && (DateTime.Compare(date, dateRangeEnd) < 0))
                {
                    for (int additionalAppointmentIndex = 0; additionalAppointmentIndex < 8; additionalAppointmentIndex++)
                    {
                        ScheduleAppointment meeting = new ScheduleAppointment();
                        meeting.StartTime = new DateTime(date.Year, date.Month, date.Day, randomTime.Next(9, 15), 0, 0);
                        meeting.EndTime = meeting.StartTime.AddHours(randomTime.Next(1, 3));
                        meeting.Subject = subjectCollection[randomTime.Next(9)];
                        meeting.AppointmentBackground = Brushes[randomTime.Next(9)];
                        meeting.IsAllDay = false;

                        var coll = new ObservableCollection<object>
            {
                (Resources[randomTime.Next(Resources.Count)] as SchedulerResource).Id

                            };
                        meeting.ResourceIdCollection = coll;

                        this.Events.Add(meeting);
                    }

                    for (int additionalAppointmentIndex = 0; additionalAppointmentIndex < 8; additionalAppointmentIndex++)
                    {
                        ScheduleAppointment meeting = new ScheduleAppointment();
                        meeting.StartTime = new DateTime(date.Year, date.Month, date.Day, randomTime.Next(10, 12), 0, 0);
                        meeting.EndTime = meeting.StartTime.AddHours(randomTime.Next(1, 3));
                        meeting.Subject = subjectCollection[randomTime.Next(9)];
                        meeting.AppointmentBackground = Brushes[randomTime.Next(9)];
                        meeting.IsAllDay = false;

                        var coll = new ObservableCollection<object>
                            {
                                (Resources[randomTime.Next(Resources.Count)] as SchedulerResource).Id
                            };
                        meeting.ResourceIdCollection = coll;

                        this.Events.Add(meeting);
                    }
                }

                else
                {
                    ScheduleAppointment meeting = new ScheduleAppointment();
                    meeting.StartTime = new DateTime(date.Year, date.Month, date.Day, randomTime.Next(0, 23), 0, 0);
                    meeting.EndTime = meeting.StartTime.AddDays(2).AddHours(1);
                    meeting.Subject = subjectCollection[randomTime.Next(9)];
                    meeting.AppointmentBackground = Brushes[randomTime.Next(9)];
                    meeting.IsAllDay = true;
                    var coll = new ObservableCollection<object>
                            {
                                (Resources[randomTime.Next(Resources.Count)] as SchedulerResource).Id
                            };
                    meeting.ResourceIdCollection = coll;
                    this.Events.Add(meeting);
                }
            }

            ScheduleAppointment meeting2 = new ScheduleAppointment();
            meeting2.StartTime = DateTime.Now.Date.AddHours(10);
            meeting2.EndTime = meeting2.StartTime.AddHours(2);
            meeting2.Subject = subjectCollection[1];
            meeting2.AppointmentBackground = Brushes[1];
            var col2 = new ObservableCollection<object>
                            {
                                "1"
                            };
            meeting2.ResourceIdCollection = col2;
            this.Events.Add(meeting2);

            ScheduleAppointment meeting3 = new ScheduleAppointment();
            meeting3.StartTime = DateTime.Now.Date.AddHours(11);
            meeting3.EndTime = meeting3.StartTime.AddHours(2);
            meeting3.Subject = subjectCollection[2];
            meeting3.AppointmentBackground = Brushes[1];
            var col3 = new ObservableCollection<object>
                            {
                                "1"
                            };
            meeting3.ResourceIdCollection = col3;
            this.Events.Add(meeting3);
        }

        private void GetBrushCollection()
        {
            Brushes = new ObservableCollection<SolidColorBrush>()
            {
            new SolidColorBrush(Color.FromArgb(255, 157, 101, 201)),
            new SolidColorBrush(Color.FromArgb(255, 240, 138, 93)),
            new SolidColorBrush(Color.FromArgb(255, 103, 155, 155)),
            new SolidColorBrush(Color.FromArgb(255, 141,34,45)),
            new SolidColorBrush(Color.FromArgb(255, 22,146,22)),
            new SolidColorBrush(Color.FromArgb(255, 12,22,216)),
            new SolidColorBrush(Color.FromArgb(255, 216,145,12)),
            new SolidColorBrush(Color.FromArgb(255, 177,7,191)),
            new SolidColorBrush(Color.FromArgb(255, 39,170,254)),
            };
        }
    }
}

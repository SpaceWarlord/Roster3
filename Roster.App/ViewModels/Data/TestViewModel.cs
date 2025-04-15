using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Media;
using Roster.App.DTO;
using Roster.App.Services;
using Roster.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.App.ViewModels.Data
{
    public partial class TestViewModel : DataViewModel
    {
        [ObservableProperty]
        private string _id;

        [ObservableProperty]
        private string? _name;

        [ObservableProperty]
        private string? _description;

        [ObservableProperty]
        private DateTimeOffset _startDate;

        [ObservableProperty]
        private DateTimeOffset _endDate;

        [ObservableProperty]
        private DateTimeOffset _startTime;

        [ObservableProperty]
        private DateTimeOffset _endTime;

        [ObservableProperty]
        private Brush? _backgroundColor;

        [ObservableProperty]
        private Brush? _foregroundColor;

        public TestViewModel() //Needed for SyncFusion
        {
            Id = Guid.NewGuid().ToString();
            //Debug.WriteLine("IN BLANK CTOR");
        }
        public TestViewModel(string id, string? name, string? description, DateTimeOffset startDate, DateTimeOffset endDate, DateTimeOffset startTime, DateTimeOffset endTime)
        {
            Id = id;
            Name = name;            
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            StartTime = startTime;
            EndTime = endTime;                     
        }

        public override T ToDTO<T>()
        {
            return (T)Convert.ChangeType(new TestDTO(Id, Name, Description, StartDate, EndDate, StartTime, EndTime), typeof(T));
        }

        public override T ToModel<T>()
        {
            throw new NotImplementedException();
        }

        public async Task AddUpdate(TestService testService)
        {
            Debug.WriteLine("Called Save Async");
            IsModified = false;
            if (IsNew)
            {
                Debug.WriteLine("its new");
                IsNew = false;
                await testService.AddUpdate(ToDTO<TestDTO>());
            }
        }
    }
}

using CommunityToolkit.WinUI;
using Roster.App.Services;
using Roster.App.ViewModels.Data;
using Roster.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roster.App.ViewModels.Page
{
    public partial class TestPageViewModel: BaseViewModel
    {
        private TestService TestService { get; set; }               
        public ObservableCollection<TestViewModel> Tests { get; set; }

        public TestPageViewModel()
        {
            Debug.WriteLine("-- TestPageViewModel Constructor--");
            Tests = new ObservableCollection<TestViewModel>();            
            TestService = new TestService(new RosterDBContext());           
            GetTestsListAsync();            
        }

        /// <summary>
        /// Saves shift template to database 
        /// </summary>
        public async Task AddUpdateTestToDB(TestViewModel test)
        {
            Debug.WriteLine("--AddUpdateTestToDb--");
            await test.AddUpdate(TestService);
        }

        public async Task GetTestsListAsync()
        {
            Debug.WriteLine("-- Get Tests List Async --");
            //(CommunityToolkit.Helpers)
            await dispatcherQueue.EnqueueAsync(() =>
            {
                IsLoading = true;
            });
            var tests = await TestService.GetAll();

            Debug.WriteLine("Total tests: " + tests.Count());

            await dispatcherQueue.EnqueueAsync(() =>
            {
                Tests.Clear();

                foreach (var c in tests)
                {
                    Debug.WriteLine("adding Id: + " + c.Id + " Name: " + c.Name);
                    

                   
                    TestViewModel testViewModel = new TestViewModel(c.Id, c.Name, c.Description, c.StartDate, c.EndDate, c.StartTime, c.EndTime);
                    if (testViewModel.Name != null)
                    {
                        Debug.WriteLine("Not null: Id" + testViewModel.Id);
                        Tests.Add(testViewModel);                        
                    }
                    else
                    {
                        Debug.WriteLine("Was null");
                    }
                }
                Debug.WriteLine("Total tests after: " + tests.Count());
                IsLoading = false;
            });
        }               
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Roster.App.ViewModels.Data;
using Roster.App.ViewModels.Page;
using Syncfusion.UI.Xaml.DataGrid;
using System.Diagnostics;
using Roster.Models;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Roster.App.Views.TestViews
{
    public sealed partial class TestPage : Page
    {
        /// <summary>
        /// An empty page that can be used on its own or navigated to within a Frame.
        /// </summary>
        public TestPageViewModel ViewModel { get; set; }
        public TestPage()
        {
            this.InitializeComponent();
            ViewModel = new TestPageViewModel();
            DataContext = new TestPageViewModel();            
            SfDataGrid TestDataGrid = new SfDataGrid();
            TestDataGrid.CurrentCellValidating += SfDataGrid_CurrentCellValidating;
            TestDataGrid.RowValidating += SfDataGrid_RowValidating;
            TestDataGrid.RowValidated += SfDataGrid_RowValidated;
            //shiftTemplatesDataGrid1.AddNewRowInitiating += SfDataGrid_AddNewRowInitiating;
            TestDataGrid.DataValidationMode = Syncfusion.UI.Xaml.Grids.GridValidationMode.InView;
            TestDataGrid.DataContext = ViewModel.Tests;
            TestDataGrid.Columns.Add(new GridComboBoxColumn() { MappingName = "PriorityRating", DisplayMemberPath="", ItemsSource = Enum.GetValues(typeof(Priority)) });
            RootGrid.Children.Add(TestDataGrid);
            //ComboBox1.ItemsSource = Enum.GetValues(typeof (Priority));
        }

        public async void OnLoad(object sender, RoutedEventArgs e)
        {                
            Debug.WriteLine("Onload - Total tests: " + ViewModel.Tests.Count);            
            TestDataGrid.ItemsSource = ViewModel.Tests;
        }
         
        private void SfDataGrid_CurrentCellValidating(object sender, CurrentCellValidatingEventArgs e)
        {
            Debug.WriteLine("-- Cell Validating --");
            if (e.Column.MappingName == "StartTime")
            {
                Debug.WriteLine("In StartTime");
                DateTime b = DateTime.Now;
                Debug.WriteLine("B IS " + b.ToString());
                Debug.WriteLine("Value is " + e.NewValue.ToString());
                //e.NewValue = new DateTime(e.NewValue);
                /*
                if (e.NewValue.ToString().Equals("1004"))
                {
                    e.IsValid = false;
                    e.ErrorMessage = "EmployeeID 1004 cannot be passed";
                }*/
            }
            
        }


        private void SfDataGrid_RowValidating(object sender, RowValidatingEventArgs e)
        {
            Debug.WriteLine("-- RowValidating --");
            /*
            var data = e.RowData.GetType().GetProperty("Name").GetValue(e.RowData);
            DateTime? startTime = e.RowData.GetType().GetProperty("StartTime").GetValue(e.RowData) as DateTime?;
            DateTime? endTime = e.RowData.GetType().GetProperty("EndTime").GetValue(e.RowData) as DateTime?;

            if (startTime.HasValue && endTime.HasValue)
            {
                Debug.WriteLine("Dates have values");
            }
            else
            {
                Debug.WriteLine("Dates lack values");
                //e.IsValid = false;
                //e.ErrorMessages.Add("Name", "Marvin Allen cannot be passed");
            }     */       
        }

        private async void SfDataGrid_RowValidated(object? sender, RowValidatedEventArgs e)
        {
            Debug.WriteLine("Valid row");
            if (e.RowData == null)
            {
                Debug.WriteLine("Row Data was null");
            }
            TestViewModel? test = e.RowData as TestViewModel;
            if (test != null)
            {
                Debug.WriteLine("zz " + test.Name);
                if (test.Name!= null)
                {
                    Debug.WriteLine("Name is " + test.Name);
                }

                await ViewModel.AddUpdateTestToDB(test);
            }
        }

        private void SfDataGrid_AddNewRowInitiating(object? sender, AddNewRowInitiatingEventArgs e)
        {

            var test = e.NewObject as TestViewModel;
            if (test != null)
            {
                Debug.WriteLine("name is " + test.Name);               
            }
            else
            {
                Debug.WriteLine("name was null");
            }
        }
    }
}

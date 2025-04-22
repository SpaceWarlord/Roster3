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
using System.Security.AccessControl;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Roster.App.Views.ObjectiveViews
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ObjectivePage : Page
    {
        public ObjectivePageViewModel ViewModel { get; set; }
        public ObjectivePage()
        {
            this.InitializeComponent();
            ViewModel = new ObjectivePageViewModel();
            this.DataContext = new ObjectivePageViewModel();
            SfDataGrid ObjectivesDataGrid = new SfDataGrid();
            Grid.SetRow(ObjectivesDataGrid, 1);
            Grid.SetColumnSpan(ObjectivesDataGrid, 2);
            ObjectivesDataGrid.RowValidated += SfDataGrid_RowValidated;
            ObjectivesDataGrid.AllowEditing = true;
            ObjectivesDataGrid.AutoGenerateColumns = false;
            ObjectivesDataGrid.AddNewRowPosition = AddNewRowPosition.Top;            
            ObjectivesDataGrid.DataValidationMode = Syncfusion.UI.Xaml.Grids.GridValidationMode.InView;            
            ObjectivesDataGrid.ItemsSource = ViewModel.Objectives;
            ObjectivesDataGrid.DataContext = ViewModel.Objectives;
            ObjectivesDataGrid.Columns.Add(new GridTextColumn() { HeaderText="Name", MappingName = "Name"});
            ObjectivesDataGrid.Columns.Add(new GridTextColumn() { HeaderText = "Description", MappingName = "Description" });
            ObjectivesDataGrid.Columns.Add(new GridComboBoxColumn() { HeaderText= "Priority", MappingName = "PriorityRating", ItemsSource = Enum.GetValues(typeof(Priority)) });
            ObjectivesDataGrid.Columns.Add(new GridDateColumn() { HeaderText = "Date Added", MappingName = "DateAdded" });
            ObjectivesDataGrid.Columns.Add(new GridDateColumn() { HeaderText = "Complete By", MappingName = "CompleteBy" });
            ObjectivesDataGrid.Columns.Add(new GridComboBoxColumn() { HeaderText = "Worker", MappingName = "Worker", ItemsSource = ViewModel.Workers, DisplayMemberPath="FullName"});
            ObjectivesDataGrid.Columns.Add(new GridComboBoxColumn() { HeaderText = "Client", MappingName = "Client", ItemsSource = ViewModel.Clients, DisplayMemberPath = "FullName"});
            RootGrid.Children.Add(ObjectivesDataGrid);

        }

        public async void OnLoad(object sender, RoutedEventArgs e)
        {
                        
            Debug.WriteLine("Total objectives: " + ViewModel.Objectives.Count);
            
        }

        private async void SfDataGrid_RowValidated(object? sender, RowValidatedEventArgs e)
        {
            Debug.WriteLine("Valid row");
            if (e.RowData == null)
            {
                Debug.WriteLine("Row Data was null");
            }
            ObjectiveViewModel? objective = e.RowData as ObjectiveViewModel;
            if (objective != null)
            {
                Debug.WriteLine("zz " + objective.Name);
                if (objective.Worker != null)
                {
                    Debug.WriteLine("Objective Worker is " + objective.Worker.FullName);
                }

                await ViewModel.AddUpdateObjectiveToDB(objective);
            }
        }

        private void SfDataGrid_AddNewRowInitiating(object? sender, AddNewRowInitiatingEventArgs e)
        {

            var objective = e.NewObject as ObjectiveViewModel;
            if (objective != null)
            {
                Debug.WriteLine("name is " + objective.Worker.FirstName);
                /*
                var firstName = e.NewObject.GetType().GetProperty("Worker.FirstName").GetValue(e.NewObject);
                var lastName = e.NewObject.GetType().GetProperty("Worker.LastName").GetValue(e.NewObject);
                var nickname = e.NewObject.GetType().GetProperty("Worker.Nickname").GetValue(e.NewObject);

                if (string.IsNullOrWhiteSpace(nickname.ToString()))
                {
                    Debug.WriteLine("Error adding - nickname was blank");
                }
                else
                {
                    Debug.WriteLine("Adding. Nickname is " + nickname);
                }
                Debug.WriteLine("name is " + shiftTemplate.Worker.FirstName);
                //await ViewModel.AddClientToDB();
                */
            }
            else
            {
                Debug.WriteLine("worker was null");
            }
        }        
    }
}

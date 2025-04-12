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
using Roster.App.ViewModels;
using Syncfusion.UI.Xaml.DataGrid;
using System.Diagnostics;
using Roster.App.ViewModels.Data;
using Roster.App.ViewModels.Page;
using Roster.App.Services;
using Syncfusion.UI.Xaml.Editors;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Roster.App.Views.ShiftTemplateViews
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ShiftTemplatePage : Page
    {

        public ShiftTemplatePageViewModel ViewModel { get; set; }
        public ShiftTemplatePage()
        {
            this.InitializeComponent();
            ViewModel = new ShiftTemplatePageViewModel();
            this.DataContext = new ShiftTemplatePageViewModel();
            shiftTemplatesDataGrid1.RowValidated += SfDataGrid_RowValidated;
            //shiftTemplatesDataGrid1.AddNewRowInitiating += SfDataGrid_AddNewRowInitiating;
            shiftTemplatesDataGrid1.DataValidationMode = Syncfusion.UI.Xaml.Grids.GridValidationMode.InView;           
        }

        public async void OnLoad(object sender, RoutedEventArgs e)
        {            
            //await ViewModel.GetShiftTemplatesListAsync();
            //await ViewModel.GetWorkersListAsync();            
            //this.DataContext = ViewModel;
            //shiftTemplatesDataGrid.DataContext= new ShiftTemplatePageViewModel();
            //shiftTemplatesDataGrid.ItemsSource = ViewModel.ShiftTemplates;            
            Debug.WriteLine("Total shift templates: " + ViewModel.ShiftTemplates.Count);

            
            //shiftTemplatesDataGrid1.DataContext = new ShiftTemplatePageViewModel();
            shiftTemplatesDataGrid1.ItemsSource = ViewModel.ShiftTemplates;

            autoComplete1.DataContext = new ShiftTemplatePageViewModel();

            //ShiftTemplatePageViewModel socialMediaViewModel = (autoComplete1.DataContext as ShiftTemplatePageViewModel);
            autoComplete1.ItemsSource = ViewModel.Workers;
            

            /*
            GridComboBoxColumn? column = shiftTemplatesDataGrid.Columns["Worker"] as GridComboBoxColumn;
            if (column != null)
            {                
                column.ItemsSource = ViewModel.Workers;
                column.HeaderText = "Worker";
                column.MappingName = "Worker";
                column.DisplayMemberPath = "FullName";
                column.SelectedValuePath = "Id";
            }
            */
        }

        private async void SfDataGrid_RowValidated(object? sender, RowValidatedEventArgs e)
        {
            Debug.WriteLine("Valid row");
            if (e.RowData == null)
            {
                Debug.WriteLine("Row Data was null");
            }
            ShiftTemplateViewModel? shiftTemplate = e.RowData as ShiftTemplateViewModel;
            if (shiftTemplate != null)
            {
                Debug.WriteLine("zz " + shiftTemplate.Name);
                if (shiftTemplate.Worker!=null)
                {
                    Debug.WriteLine("Shift Worker is " + shiftTemplate.Worker.FullName);
                }
               
                //await ViewModel.AddUpdateShiftTemplateToDB(shiftTemplate);
            }
        }

        private void SfDataGrid_AddNewRowInitiating(object? sender, AddNewRowInitiatingEventArgs e)
        {
            
            var shiftTemplate = e.NewObject as ShiftTemplateViewModel;
            if (shiftTemplate != null)
            {
                Debug.WriteLine("name is " + shiftTemplate.Worker.FirstName);
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

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

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Roster.App.Views.WorkerCertificateViews
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WorkerCertificatePage : Page
    {
        public WorkerCertificatePageViewModel ViewModel { get; set; }
        public WorkerCertificatePage()
        {
            this.InitializeComponent();
            ViewModel = new WorkerCertificatePageViewModel();
            this.DataContext = new WorkerCertificatePageViewModel();
            WorkerCertificatesDataGrid.RowValidated += SfDataGrid_RowValidated;
            //shiftTemplatesDataGrid1.AddNewRowInitiating += SfDataGrid_AddNewRowInitiating;
            WorkerCertificatesDataGrid.DataValidationMode = Syncfusion.UI.Xaml.Grids.GridValidationMode.InView;

        }

        public async void OnLoad(object sender, RoutedEventArgs e)
        {
            //await ViewModel.GetShiftTemplatesListAsync();
            //await ViewModel.GetWorkersListAsync();            
            //this.DataContext = ViewModel;
            //shiftTemplatesDataGrid.DataContext= new ShiftTemplatePageViewModel();
            //shiftTemplatesDataGrid.ItemsSource = ViewModel.ShiftTemplates;            
            Debug.WriteLine("Total worker certificates: " + ViewModel.WorkerCertificates.Count);
            WorkerCertificatesDataGrid.ItemsSource = ViewModel.WorkerCertificates;
        }

        private async void SfDataGrid_RowValidated(object? sender, RowValidatedEventArgs e)
        {
            Debug.WriteLine("Valid row");
            if (e.RowData == null)
            {
                Debug.WriteLine("Row Data was null");
            }
            WorkerCertificateViewModel? workerCertificate = e.RowData as WorkerCertificateViewModel;
            if (workerCertificate != null)
            {                
                if (workerCertificate.Worker != null)
                {
                    Debug.WriteLine("zz " + workerCertificate.Worker.FullName);
                }

                await ViewModel.AddUpdateWorkerCertificateToDB(workerCertificate);
            }
        }

        private void SfDataGrid_AddNewRowInitiating(object? sender, AddNewRowInitiatingEventArgs e)
        {

            var shift = e.NewObject as ShiftViewModel;
            if (shift != null)
            {
                Debug.WriteLine("name is " + shift.Worker.FirstName);
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

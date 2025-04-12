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
using System.Diagnostics;
using Roster.App.Views.WorkerViews;
using Syncfusion.UI.Xaml.DataGrid;
using Roster.App.ViewModels.Page;
using Roster.App.ViewModels.Data;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Roster.App.Views.WorkerViews
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WorkerPage : Page
    {
        public WorkerPageViewModel ViewModel { get; set; }
        public WorkerPage()
        {
            this.InitializeComponent();
            ViewModel=new WorkerPageViewModel();
            workersDataGrid.AddNewRowInitiating += SfDataGrid_AddNewRowInitiating;
            workersDataGrid.DataValidationMode = Syncfusion.UI.Xaml.Grids.GridValidationMode.InView;
            workersDataGrid.RowValidated += SfDataGrid_RowValidated;
        }

        public async void OnLoad(object sender, RoutedEventArgs e)
        {
            await ViewModel.GetWorkersListAsync();
            workersDataGrid.ItemsSource = ViewModel.Workers;
            Debug.WriteLine("Total workers: " + ViewModel.Workers.Count);

            GridComboBoxColumn? column = workersDataGrid.Columns["Gender"] as GridComboBoxColumn;
            if (column != null)
            {
                column.ItemsSource = PersonViewModel.GenderTypes;
            }
        }

        private async void SfDataGrid_RowValidated(object? sender, RowValidatedEventArgs e)
        {
            Debug.WriteLine("Valid row");
            WorkerViewModel? worker = e.RowData as WorkerViewModel;
            if (worker != null)
            {
                Debug.WriteLine("Nickname is " + worker.Nickname);
                await ViewModel.AddUpdateWorkerToDB(worker);
            }
        }

        private void SfDataGrid_AddNewRowInitiating(object? sender, AddNewRowInitiatingEventArgs e)
        {
            var worker = e.NewObject as WorkerViewModel;
            if (worker != null)
            {
                var firstName = e.NewObject.GetType().GetProperty("FirstName").GetValue(e.NewObject);
                var lastName = e.NewObject.GetType().GetProperty("LastName").GetValue(e.NewObject);
                var nickname = e.NewObject.GetType().GetProperty("Nickname").GetValue(e.NewObject);

                if (string.IsNullOrWhiteSpace(nickname.ToString()))
                {
                    Debug.WriteLine("Error adding - nickname was blank");
                }
                else
                {
                    Debug.WriteLine("Adding. Nickname is " + nickname);
                }
                Debug.WriteLine("name is " + worker.FirstName);
                //await ViewModel.AddClientToDB();
            }
            else
            {
                Debug.WriteLine("worker was null");
            }
        }

        private void ShowDialog_Click(object sender, RoutedEventArgs e)
        {
            /*
            AddWorkerDialog dialog = new AddWorkerDialog();            

            // XamlRoot must be set in the case of a ContentDialog running in a Desktop app
            dialog.XamlRoot = this.XamlRoot;
            dialog.Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style;
            dialog.Title = "Add Worker";
            dialog.PrimaryButtonText = "Add";
            //dialog.SecondaryButtonText = "Don't Save";
            dialog.CloseButtonText = "Cancel";
            dialog.DefaultButton = ContentDialogButton.Primary;
            //dialog.Content = new TestDialog();
            dialog.Width = 2000;
            dialog.MinWidth = 2000;
            dialog.Height = 1000;
            //dialog.RequestedTheme = (VisualTreeHelper.GetParent(sender as Button) as StackPanel).ActualTheme;

            var result = await dialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                //DialogResult.Text = "User saved their work";
                if (dialog.Worker != null)
                {
                    Debug.WriteLine("zzName: " + dialog.Worker.FullName);
                    ViewModel.AddWorkerCommand.Execute(dialog.Worker);
                }

            }
            else if (result == ContentDialogResult.Secondary)
            {
                //DialogResult.Text = "User did not save their work";
            }
            else
            {
                //DialogResult.Text = "User cancelled the dialog";
            }
            */
        }
    }
}

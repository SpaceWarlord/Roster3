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
using Roster.App.ViewModels.Page;
using Roster.App.ViewModels.Data;
using Syncfusion.UI.Xaml.DataGrid;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Roster.App.Views.ShiftViews
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ShiftPage : Page
    {
        public ShiftPageViewModel ViewModel { get; set; }
        public ShiftPage()
        {
            this.InitializeComponent();
            ViewModel = new ShiftPageViewModel();
            this.DataContext = new ShiftPageViewModel();
            ShiftsDataGrid.RowValidated += SfDataGrid_RowValidated;
            //shiftTemplatesDataGrid1.AddNewRowInitiating += SfDataGrid_AddNewRowInitiating;
            ShiftsDataGrid.DataValidationMode = Syncfusion.UI.Xaml.Grids.GridValidationMode.InView;

        }               

        public async void OnLoad(object sender, RoutedEventArgs e)
        {
            //await ViewModel.GetShiftTemplatesListAsync();
            //await ViewModel.GetWorkersListAsync();            
            //this.DataContext = ViewModel;
            //shiftTemplatesDataGrid.DataContext= new ShiftTemplatePageViewModel();
            //shiftTemplatesDataGrid.ItemsSource = ViewModel.ShiftTemplates;            
            Debug.WriteLine("Total shift templates: " + ViewModel.Shifts.Count);            
            ShiftsDataGrid.ItemsSource = ViewModel.Shifts;            
        }

        private async void SfDataGrid_RowValidated(object? sender, RowValidatedEventArgs e)
        {
            Debug.WriteLine("Valid row");
            if (e.RowData == null)
            {
                Debug.WriteLine("Row Data was null");
            }
            ShiftViewModel? shift = e.RowData as ShiftViewModel;
            if (shift != null)
            {
                Debug.WriteLine("zz " + shift.Name);
                if (shift.Worker != null)
                {
                    Debug.WriteLine("Shift Worker is " + shift.Worker.FullName);
                }

                await ViewModel.AddUpdateShiftToDB(shift);
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

        private void ShowDialog_Click(object sender, RoutedEventArgs e)
        {
            /*
            AddShiftDialog dialog = new AddShiftDialog();

            // XamlRoot must be set in the case of a ContentDialog running in a Desktop app
            dialog.XamlRoot = this.XamlRoot;
            dialog.Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style;
            dialog.Title = "Add Shift";
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
                if (dialog.Shift != null)
                {
                    // Debug.WriteLine("zzName: " + dialog.Staff.Name);
                    //ViewModel.context.Attach(thisUser).
                    //ViewModel.context.Attach(dialog.currentClients);
                    //ViewModel.context.Attach(dialog.currentStaff);
                    ViewModel.AddShiftCommand.Execute(dialog.Shift);
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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.Loaded();
        }
    }
}

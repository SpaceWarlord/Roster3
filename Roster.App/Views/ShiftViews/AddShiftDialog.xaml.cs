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
using Roster.Models;
using Roster.App.Views.ShiftViews;
using System.Xml.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;
using Roster.App.ViewModels;
using Roster.App.ViewModels.Data;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Roster.App.Views.ShiftViews
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddShiftDialog : ContentDialog
    {
        public RosterDBContext context;
        //public Shift Shift { get; } = new();
        public ShiftViewModel Shift { get; }

        public List<WorkerViewModel> currentWorkers;
        public List<ClientViewModel> currentClients;
        public AddShiftDialog()
        {

            /*
             *  Binding myBinding = new Binding("SomeString");
                myBinding.Source = ViewModel.SomeString;
                myBinding.Mode = BindingMode.TwoWay;
                myBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                BindingOperations.SetBinding(txtText, TextBox.TextProperty, myBinding);
            */

            this.InitializeComponent();
            context = new RosterDBContext();
            /*
            Binding startDateBinding = new Binding();
            startDateBinding.Source = Shift;
            startDateBinding.Path = new PropertyPath("StartDateTemp");
            startDateBinding.Mode = BindingMode.TwoWay;
            startDateBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(StartDatePicker, DatePicker.DateProperty, startDateBinding);

            Binding endDateBinding = new Binding();
            endDateBinding.Source = Shift;
            endDateBinding.Path = new PropertyPath("EndDateTemp");
            endDateBinding.Mode = BindingMode.TwoWay;
            endDateBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(EndDatePicker, DatePicker.DateProperty, endDateBinding);

            Binding startTimeBinding = new Binding();
            startTimeBinding.Source = Shift;
            startTimeBinding.Path = new PropertyPath("StartTimeTemp");
            startTimeBinding.Mode = BindingMode.TwoWay;
            startTimeBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(StartTimePicker, TimePicker.TimeProperty, startTimeBinding);

            Binding endTimeBinding = new Binding();
            endTimeBinding.Source = Shift;
            endTimeBinding.Path = new PropertyPath("EndTimeTemp");
            endTimeBinding.Mode = BindingMode.TwoWay;
            endTimeBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(EndTimePicker, TimePicker.TimeProperty, endTimeBinding);
            */


            //currentClients = new List<ClientViewModel>(context.Clients.ToList());
            //currentWorkers = new List<WorkerViewModel>(context.Workers.ToList());    



            //StaffListView.DataContext = staff;
            //StaffDropDown.
            //Debug.WriteLine("total staff is " + staff.Count);



            /*
            Binding endDateBinding = new Binding();
            endDateBinding.Source = Shift;
            endDateBinding.Path = new PropertyPath("EndDateTemp");
            endDateBinding.Mode = BindingMode.TwoWay;
            endDateBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(EndDatePicker, DatePicker.DateProperty, endDateBinding);
            */


            /*
        var myBinding = new Binding
            {
                Source = Shift,
                Path = new PropertyPath("EndDate")
            };
            EndDatePicker.SetBinding(DatePicker.SelectedDateProperty, myBinding);
            */
        }

        private void ClientListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ClientListView.SelectedItem != null)
            {
                Shift.Client = (ClientViewModel)ClientListView.SelectedItem;
                Debug.WriteLine("selected client is " + Shift.Client.FullName);
                Debug.WriteLine("selected client ID IS " + Shift.Client.Id);
            }
            else
            {
                ClientListView.SelectedItem = null;
            }
        }

        /*
        private void WorkersListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (WorkersListView.SelectedItem != null)
            {
                Shift.Worker = (Worker)WorkersListView.SelectedItem;
                Debug.WriteLine("selected staff is " + Shift.Worker.Name);
            }
            else
            {
                WorkersListView.SelectedItem = null;
            }
        }
        */
    }
}

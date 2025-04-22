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
using Syncfusion.UI.Xaml.Scheduler;
using Roster.App.ViewModels.Page;
using System.Diagnostics;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Roster.App.Views.TestViews
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TestPage1 : Page
    {
        public TestPage1ViewModel ViewModel { get; set; }
        public TestPage1()
        {
            this.InitializeComponent();
            ViewModel = new TestPage1ViewModel();
            Schedule.DataContext = ViewModel;
            viewTypeCombobox.ItemsSource = Enum.GetValues(typeof(SchedulerViewType));
            Debug.WriteLine("HIAFAF");
            Schedule.DisplayDate = ViewModel.DisplayDate;
            Debug.WriteLine("Hgagag");
            Schedule.ItemsSource = ViewModel.Events;
            Debug.WriteLine("IAKFAG");
            Schedule.ResourceCollection = ViewModel.Resources;
            Debug.WriteLine("PPPPPPP");
            //Schedule.ViewType = SchedulerViewType.
        }

        private void autoRowCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked == true)
            {
                this.Schedule.TimelineViewSettings.RowAutoHeight = true;
            }
            else
            {
                this.Schedule.TimelineViewSettings.RowAutoHeight = false;
            }
        }
    }
}

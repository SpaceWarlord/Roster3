using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Roster.App.ViewModels;
using Roster.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Roster.App.Views.ClientViews
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddClientDialog : ContentDialog
    {
        public ClientPageViewModel ClientPageVM { get; set;}
        public AddClientDialog(ClientPageViewModel clientPageVM)
        {
            this.InitializeComponent();

            ClientPageVM = clientPageVM;
            //ClientVM = new ClientViewModel("", "", "", "", "", "", "", "", null, 0, "");
            /*
            ClientVM.FullName = string.Empty;
            ClientVM.Gender = "M";
            ClientVM.GenderPreference = string.Empty;
            ClientVM.Phone = "555555";
            */
        }

        private void gender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Debug.WriteLine("--Gender Selection--");
            RadioButton radioButton = gender.SelectedItem as RadioButton;
            if (radioButton != null)
            {
                Debug.WriteLine("Gender set to: " + radioButton.Content);
            }
        }
    }

    public class GenderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return ((string)parameter == (string)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return (bool)value ? parameter : null;
        }
    }
}

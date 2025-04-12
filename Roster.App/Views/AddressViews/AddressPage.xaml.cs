using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Roster.App.ViewModels;
using Roster.App.ViewModels.Page;
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

namespace Roster.App.Views.AddressViews
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddressPage : Page
    {
        public AddressPageViewModel ViewModel { get; set; }
        public AddressPage()
        {
            this.InitializeComponent();
            ViewModel = new AddressPageViewModel();
        }

        private async void ShowDialog_Click(object sender, RoutedEventArgs e)
        {
            AddAddressDialog dialog = new AddAddressDialog();

            // XamlRoot must be set in the case of a ContentDialog running in a Desktop app
            dialog.XamlRoot = this.XamlRoot;
            dialog.Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style;
            dialog.Title = "Add Address";
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

                if (dialog.AddressVM != null)
                {
                    Debug.WriteLine("zzName: " + dialog.AddressVM.Name);
                    ViewModel.AddAddressCommand.Execute(dialog.AddressVM);
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
        }
    }
}

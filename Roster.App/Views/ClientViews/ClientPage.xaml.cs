using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Roster.App.ViewModels;
using Roster.App.ViewModels.Data;
using Roster.App.ViewModels.Page;
using Syncfusion.UI.Xaml.DataGrid;
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
    public sealed partial class ClientPage : Page
    {
        public ClientPageViewModel ViewModel { get; set; }
        public ClientPage()
        {
            this.InitializeComponent();
            ViewModel = new ClientPageViewModel();
            clientsDataGrid.AddNewRowInitiating += SfDataGrid_AddNewRowInitiating;
            //clientsDataGrid.RowValidating += SfDataGrid_RowValidating;
            //clientsDataGrid.CurrentCellValueChanged += SfDataGrid_CurrentCellValueChanged;
            clientsDataGrid.DataValidationMode = Syncfusion.UI.Xaml.Grids.GridValidationMode.InView;
            clientsDataGrid.RowValidated += SfDataGrid_RowValidated;
        }

        public async void OnLoad(object sender, RoutedEventArgs e)
        {
            await ViewModel.GetClientsListAsync();
            clientsDataGrid.ItemsSource = ViewModel.Clients;
            Debug.WriteLine("total clients: " + ViewModel.Clients.Count);

            GridComboBoxColumn? column = clientsDataGrid.Columns["Gender"] as GridComboBoxColumn;
            if (column != null)
            {
                column.ItemsSource = PersonViewModel.GenderTypes;
            }
        }
        private async void SfDataGrid_RowValidated(object? sender, RowValidatedEventArgs e)
        {
            Debug.WriteLine("Valid row");
            ClientViewModel? client = e.RowData as ClientViewModel;
            if (client != null)
            {
                Debug.WriteLine("Nickname is " + client.Nickname);
                await ViewModel.AddUpdateClientToDB(client);
            }
        }

        private void SfDataGrid_AddNewRowInitiating(object? sender, AddNewRowInitiatingEventArgs e)
        {            
            var client = e.NewObject as ClientViewModel;
            if (client != null)
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
                    Debug.WriteLine("name is " + client.FirstName);
                //await ViewModel.AddClientToDB();
            }
            else
            {
                Debug.WriteLine("client was null");
            }            
        }        

        private void SfDataGrid_RowValidating(object sender, RowValidatingEventArgs e)
        {
            if (this.clientsDataGrid.IsAddNewIndex(e.RowIndex))
            {
                /*
                var data = e.RowData.GetType().GetProperty("Nickname").GetValue(e.RowData);
                
                if (string.IsNullOrWhiteSpace(data.ToString()))
                {
                    Debug.WriteLine("nickname was blank");
                    e.IsValid = false;
                    e.ErrorMessages.Add("Nickname", "Nickname cannot be blank");
                }
                else
                {
                    Debug.WriteLine("nickname is good: " + data.ToString());
                }
                */
                ClientViewModel? client = e.RowData as ClientViewModel;
                if (client != null)
                {
                    if (string.IsNullOrWhiteSpace(client.FirstName) || string.IsNullOrWhiteSpace(client.LastName))
                    {
                        Debug.WriteLine("nickname was blank");
                        e.IsValid = false;
                        e.ErrorMessages.Add("Nickname", "Error: Nickname cannot be blank");
                    }
                    else
                    {
                        Debug.WriteLine("nickname is good: " + client.Nickname);
                    }
                }
                
            }
        }


        
        /*
        private void SfDataGrid_CurrentCellValueChanged(object sender, CurrentCellValueChangedEventArgs e)
        {
            ClientViewModel c = e.Record as ClientViewModel;

            //e.Column.GetValue();
            if (c!=null)
            {
                Debug.WriteLine("val is " + c.FirstName);
                if (string.IsNullOrWhiteSpace(c.Nickname))
                {
                    Debug.WriteLine("Error: Nickname was blank");
                }
                else
                {
                    Debug.WriteLine("Nickname is " + c.Nickname);
                }
            }
        }
        */
        

        private async void ShowDialog_Click(object sender, RoutedEventArgs e)
        {
            AddClientDialog dialog = new AddClientDialog(ViewModel);

            // XamlRoot must be set in the case of a ContentDialog running in a Desktop app
            dialog.XamlRoot = this.XamlRoot;
            dialog.Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style;
            dialog.Title = "Add Client";
            dialog.PrimaryButtonText = "Add";
            //dialog.SecondaryButtonText = "Don't Save";
            dialog.CloseButtonText = "Cancel";
            dialog.DefaultButton = ContentDialogButton.Primary;
            //dialog.Content = new TestDialog();
            dialog.Width = 2000;
            dialog.MinWidth = 2000;
            dialog.Height = 2000;
            dialog.CanBeScrollAnchor = true;
            dialog.CanDrag = true;
            dialog.FullSizeDesired = true;
            //dialog.Scale=
            //dialog.RequestedTheme = (VisualTreeHelper.GetParent(sender as Button) as StackPanel).ActualTheme;

            var result = await dialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                Debug.WriteLine("Primary clicked");
                //DialogResult.Text = "User saved their work";
                //if (dialog.ClientVM != null)
                if(ViewModel.NewClient!=null)
                {                    
                    Debug.WriteLine("zzName: " + ViewModel.NewClient.FirstName);
                    Debug.WriteLine("zzNickname: " + ViewModel.NewClient.Nickname);
                    Debug.WriteLine("Selected gender: " + ViewModel.NewClient.Gender);
                    ViewModel.NewClient.Id = Guid.NewGuid().ToString();
                    await ViewModel.AddUpdateClientToDB(ViewModel.NewClient);
                    //await ViewModel.AddClientToDB();
                    //ViewModel.AddClientCommand.Execute(dialog.ClientVM);
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

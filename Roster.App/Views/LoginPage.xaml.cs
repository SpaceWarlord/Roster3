
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Roster.App.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Dispatching;
using CommunityToolkit.Helpers;
using CommunityToolkit.Common.Extensions;
using CommunityToolkit.WinUI;
using Roster.App.Helpers;
using System.Diagnostics;
using CommunityToolkit.Mvvm.Input;
using Roster.App.ViewModels.Page;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Roster.App.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        //RosterDBContext context;
        public LoginPageViewModel ViewModel { get; } = new();

        private DispatcherQueue dispatcherQueue = DispatcherQueue.GetForCurrentThread();
        public LoginPage()
        {
            this.InitializeComponent();
            DataContext = ViewModel;
            //context = new RosterDBContext();

        }

        private async void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Grid Loaded");
            await ResetUserList();            
        }

        /// <summary>
        /// Resets the user list.
        /// </summary>        
        private async Task ResetUserList()
        {
            //await ViewModel.GetAll();
            
            await dispatcherQueue.EnqueueAsync(async () =>
                await ViewModel.GetAll());                        
        }      




        
        [RelayCommand]
        public void Test(int id)
        {
            Debug.WriteLine("Called test");
        }                
    }
}

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Roster.Models;
using System.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using System.Reflection;
using Roster.Repository;
using Roster.App.Main;
using Roster.Repository.Sql;
using Windows.Storage;
using Roster.App.ViewModels;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Roster.App
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {       
        public Window LoginWindow;
        public Window MainWindow;
        public UserViewModel CurrentUser { get; set; } = null;

        public static Window Window { get { return m_window; } }
        private static Window m_window;

        Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

        /// <summary>
        /// Pipeline for interacting with backend service or database.
        /// </summary>
        public static IRosterRepository Repository { get; private set; }


        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();                      
        }
        
        /// <summary>
        /// Configures settings for a first time run.        
        /// </summary>
        private void CheckForFirstTimeRun()
        {
            if (localSettings.Values["IsFirstTime"] == null)
            {
                localSettings.Values["IsFirstTime"] = true;
                Debug.WriteLine("Not first time");
            }
            if ((bool)localSettings.Values["IsFirstTime"])
            {
                string path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\suburbs.csv");
                Debug.WriteLine("path is " + path);

                using (var reader = new StreamReader(path))
                {
                    List<Suburb> suburbs = new List<Suburb>();
                    /*
                    RosterDBContext context = new RosterDBContext();
                    using (context)
                    {
                        DbSet<Suburb> c = context.Set<Suburb>();
                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            var values = line.Split(',');

                            suburbs.Add(new Suburb(values[1], values[0]));

                            c.Add(new Suburb(values[1], values[0]));
                        }
                        context.SaveChanges();
                        
                    }
                    */
                    /*
                        foreach (Suburb suburb in suburbs)
                        {
                            Debug.WriteLine($"{suburb.Name}");
                        }
                        */
                }
            }
        }

        /// <summary>
        /// Configures the app to use the Sqlite data source. If no existing Sqlite database exists,         
        /// </summary>
        public static void UseSqlite()
        {
            string demoDatabasePath = Package.Current.InstalledLocation.Path + @"\Data\Roster.db";
            string databasePath = ApplicationData.Current.LocalFolder.Path + @"\Roster.db";                        

            
            if (!File.Exists(databasePath))
            {
                //File.Copy(demoDatabasePath, databasePath);
            }
            //var dbOptions = new DbContextOptionsBuilder<RosterContext>().UseSqlite("Data Source=" + databasePath);
            var dbOptions = new DbContextOptionsBuilder<RosterContext>().UseSqlite("Data Source=" + "database27.db"); 
            Repository = new SqlRosterRepository(dbOptions);
        }

        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            Application.Current.DispatcherShutdownMode = DispatcherShutdownMode.OnLastWindowClose;


            //string path = AppDomain.CurrentDomain.BaseDirectory;
            UseSqlite();
            CheckForFirstTimeRun();
            LoginWindow = new LoginWindow();
            LoginWindow.Activate();
            //MainWindow = new Shell();
        }        
    }
}

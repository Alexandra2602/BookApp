using BookApp.Data;
using BookApp.Pages;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookApp
{
    public partial class App : Application
    {
        static BooksListDatabase database;
        public static BooksListDatabase Database
        {
            get
            {
                if(database==null)
                {
                    database = new BooksListDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BooksList.db3"));
                }
                return database;
            }
        }
       
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

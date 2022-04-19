﻿using BookApp.Data;
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
        static UsersListDatabase database2;
        public static UsersListDatabase Database2
        {
            get
            {
                if (database2 == null)
                {
                    database2 = new UsersListDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BooksList.db3"));
                }
                return database2;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ListEntryPage());
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
﻿using BookApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            EntryUser.Text = Preferences.Get("EntryUser", string.Empty);
            EntryPassword.Text = Preferences.Get("EntryPassword", string.Empty);
        }
        async void Login_Clicked(object sender, EventArgs e)
        {
            string email = EntryUser.Text;
            string pass = EntryPassword.Text;
            await App.Database2.LoginUser(email, pass);
            await Navigation.PushAsync(new BooksPage());
        }
        async void Register_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage
            {
                BindingContext = new User()
            });
        }
       
        private void checkbox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (checkbox.IsChecked == true)
            {
                Preferences.Set("EntryUser", EntryUser.Text);
                Preferences.Set("EntryPassword", EntryPassword.Text);
            }
            checkbox2.IsEnabled = false;

        }
        private void checkbox2_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            Preferences.Clear();
            checkbox.IsEnabled = false;

        }
    }

}
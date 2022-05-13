using BookApp.Data;
using BookApp.Models;
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
            if(EntryUser.Text=="admin" && EntryPassword.Text=="admin")
            {
                await Navigation.PushAsync(new AdminMainPage());
                   
            }
            else if (string.IsNullOrEmpty(EntryUser.Text) || string.IsNullOrWhiteSpace(EntryUser.Text) || string.IsNullOrEmpty(EntryPassword.Text) || string.IsNullOrWhiteSpace(EntryPassword.Text))
            {
                await DisplayAlert("Error", "Email or password is empty", "ok");
                return;
            }
            else
            {
                var result2 = App.Database.LoginUser(EntryUser.Text, EntryPassword.Text);
                if (result2 != null)
                {
                    await Navigation.PushAsync(new BooksPage((User)
                        this.BindingContext)
                    {
                        BindingContext = new Book()
                    });
                    //await Navigation.PushAsync(new BooksPage());
                }

                else
                {
                    await DisplayAlert("Error", "Email or password is incorect", "Ok", "Cancel");
                    return;
                }
            }



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
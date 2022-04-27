using BookApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsersPage : ContentPage
    {
        public UsersPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            userslistview.ItemsSource = await App.Database.GetUserListsAsync();
        }
        async void AddUserClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage
                {
                BindingContext = new User()
            });
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem !=null)
            {
                await Navigation.PushAsync(new RegistrationPage
                {
                    BindingContext = e.SelectedItem as User
                });
            }
        }


        
    }
}
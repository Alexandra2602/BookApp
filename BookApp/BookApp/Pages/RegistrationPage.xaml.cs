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
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var ulist = (User)BindingContext;
            await App.Database.SaveUserListAsync(ulist);
            await Navigation.PushAsync(new UsersPage());  
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var ulist = (User)BindingContext;
            await App.Database.DeleteUserListAsync(ulist);
            await Navigation.PushAsync(new UsersPage());

        }
    }
}
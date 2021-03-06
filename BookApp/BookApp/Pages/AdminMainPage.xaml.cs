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
    public partial class AdminMainPage : ContentPage
    {
        public AdminMainPage()
        {
            InitializeComponent();
            
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetBookListsAsync();
        }
        async void OnShopListAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListPage
            {
                BindingContext = new Book()
            });
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ListPage
                {
                    BindingContext = e.SelectedItem as Book
                });
            }
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdminMembersPage());
            
        }

        async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdminMainPage());
        }

        async void Button_Clicked_2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdminRatingPage());
        }

        async void Button_Clicked_3(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdminReviewPage());

        }
    }
}
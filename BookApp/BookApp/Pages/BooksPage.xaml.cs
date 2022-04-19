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
    public partial class BooksPage : ContentPage
    {
        public BooksPage()
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
        async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var search = Search1.Text.ToLower();
            //var searchresult= App.Database.SearchBookAsync(search);
            //listView.ItemsSource = await App.Database.SearchBookAsync(search);

        }
        async void Top_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TopPage());
        }
        async void Home_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BooksPage());
        }
        async void New_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewsPage());
        }
        async void Calendar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CalendarPage());
        }
        async void Profile_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
        }
        async void Members_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UsersPage());
        }

    }
}
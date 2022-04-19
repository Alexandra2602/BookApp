using BookApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReviewPage : ContentPage
    {
        Book bl;
        public ReviewPage(Book blist)
        {
            InitializeComponent();
            bl = blist;
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var review = (Review)BindingContext;
            await App.Database.SaveReviewAsync(review);
            listView.ItemsSource = await App.Database.GetReviewsAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var review = (Review)BindingContext;
            await App.Database.DeleteReviewAsync(review);
            listView.ItemsSource = await App.Database.GetReviewsAsync();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetReviewsAsync();
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            Review r;
            if (e.SelectedItem != null)
            {
                r = e.SelectedItem as Review;
                var lp = new ListReview()
                {
                    BookID = bl.ID,
                    ReviewID = r.ID
                };
                await App.Database.SaveListReviewAsync(lp);
                r.ListReviews = new List<ListReview> { lp };

                await Navigation.PopAsync();
            }
        }
    }
}
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

    public partial class CalendarPage : ContentPage
    {
        public CalendarPage()
        {
            InitializeComponent();
            
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetBookListsAsync();
        }
        private void OnDateSelected(object sender,DateChangedEventArgs e)
        {
            Recalculate();
        }

        private void includeSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            Recalculate();
        }
        void Recalculate()
        {
            TimeSpan timeSpan = endDatePicker.Date - startDatePicker.Date + (includeSwitch.IsToggled ? TimeSpan.FromDays(1) : TimeSpan.Zero);
            resultLabel.Text = String.Format("You finished the book in {0} day{1}", timeSpan.Days, timeSpan.Days == 1 ? "" : "s");
                
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            listView.IsVisible = true;

        }
    }
}
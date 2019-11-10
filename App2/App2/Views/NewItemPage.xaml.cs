using App2.Models;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App2.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public Command GoToAboutPageCommand => new Command(async () => await NavigateToAboutPageAsync());

        //Version 1: Works but goes to the tabbed pages first (not straight to the AboutPage)
        //public async Task NavigateToAboutPageAsync()
        //{
        //    await Navigation.PopModalAsync();
        //    await Shell.Current.GoToAsync($"///AboutPage").ConfigureAwait(false);
        //}

        // Version 2:  Goes straight to the AboutPage like I wanted
        public static async Task NavigateToAboutPageAsync()
        {
            var section = Shell.Current.CurrentItem.CurrentItem;
            await Shell.Current.GoToAsync($"///AboutPage").ConfigureAwait(false);
            await section.Navigation.PopModalAsync();
        }

        public NewItemPage()
        {
            InitializeComponent();

            Item = new Item
            {
                Text = "Item name",
                Description = "This is an item description."
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using App2.Models;
using System.Windows.Input;
using System.Threading.Tasks;

namespace App2.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }
       
        public ICommand GoToAboutPageCommand => new Command(async () => await NavigateToAboutPageAsync().ConfigureAwait(false));
        public async Task NavigateToAboutPageAsync() => await Shell.Current.GoToAsync($"aboutpage").ConfigureAwait(false); //<-- I hit this line but nothing heppens!
        //private async Task NavigateToAboutPageAsync() => await Shell.Current.Navigation.PushAsync(new AboutPage()); <-- doesn't work either

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
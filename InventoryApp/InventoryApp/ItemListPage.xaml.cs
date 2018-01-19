
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ZXing.Mobile;

namespace InventoryApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemListPage : ContentPage
	{
		public ItemListPage ()
		{
			InitializeComponent ();
            this.Title = "Item List";

            

            var searchItem = new ToolbarItem
            {
                Icon = "search.png",
            };

            searchItem.Clicked += async (sender, e) =>
            {
                await DisplayAlert("Coming Soon...", "The Search feature is not fully implemented yet please try again at a later time.", "OK!");
                Navigation.PushAsync();
            };

            ToolbarItems.Add(searchItem);

            var sortItem = new ToolbarItem
            {
                Icon = "sort.png"
            };

            sortItem.Clicked += async (sender, e) =>
            {
                await DisplayAlert("Coming Soon...", "The Sort feature is not fully implemented yet please try again at a later time.","OK!");
            };

            ToolbarItems.Add(sortItem);

            var addItem = new ToolbarItem
            {
                Icon = "plus.png"
            };

            addItem.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new ItemPage() { BindingContext = new Item() });
            };

            ToolbarItems.Add(addItem);

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            ItemListView.ItemsSource = await App.Database.GetItemAsync();
            
        }

        async void Object_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ItemPage() { BindingContext = e.SelectedItem as Item });
            }
        }
	}
}
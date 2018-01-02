
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            var toolbarItem = new ToolbarItem
            {
                Text = "+"
            };

            toolbarItem.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new ItemPage() { BindingContext = new Item() });
            };

            ToolbarItems.Add(toolbarItem);

            

            var scanToolbarItem = new ToolbarItem
            {
                Text = "Scan"
            };

            scanToolbarItem.Clicked += async delegate
            {
                var scanner = new MobileBarcodeScanner();
                var result = await scanner.Scan();
                Console.WriteLine(result);
            };

            ToolbarItems.Add(scanToolbarItem);

          

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
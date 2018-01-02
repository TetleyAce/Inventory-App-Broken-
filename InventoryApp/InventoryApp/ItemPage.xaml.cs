using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InventoryApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemPage : ContentPage
	{
		public ItemPage ()
		{
			InitializeComponent ();
		}

        async void Save_Clicked(object sender, System.EventArgs e)
        {
            var objectItem = (Item)BindingContext;
            await App.Database.SaveItemAsync(objectItem);
            await Navigation.PopAsync();
        }

        async void Delete_Clicked(object sender, System.EventArgs e)
        {
            var objectItem = (Item)BindingContext;
            await App.Database.DeleteItemAsync(objectItem);
            await Navigation.PopAsync();
        }
    }
}
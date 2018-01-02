using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ZXing.Mobile;

namespace InventoryApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemPage : ContentPage, INotifyPropertyChanged
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

        async void Scan_Clicked(object sender, System.EventArgs e)
        {
            //Create Object
            var objectItem = (Item)BindingContext;

            //Save Current Instance
            if (objectItem.ItemName != null)
            {
                await App.Database.SaveItemAsync(objectItem);
            }
            

            //Scanner opened
            var scanner = new MobileBarcodeScanner();
            var result = await scanner.Scan();

            //Result entered to Instance
            
            if (result != null)
            {
                objectItem.Barcode = result.Text;
            }

            //Object Page refresh

            Navigation.InsertPageBefore(new ItemPage() { BindingContext = objectItem as Item }, Navigation.NavigationStack[Navigation.NavigationStack.Count - 1]);
            await Navigation.PopAsync();

        }

        async void Addition_Clicked(object Sender, System.EventArgs e)
        {
            int _quantity;
            Int32.TryParse(CounterEntry.Text, out _quantity);
            _quantity++;
            CounterEntry.Text = Convert.ToString(_quantity);
        }

        async void Subtraction_Clicked(object Sender, System.EventArgs e)
        {
            int _quantity;
            Int32.TryParse(CounterEntry.Text, out _quantity);
            _quantity--;
            CounterEntry.Text = Convert.ToString(_quantity);
        }
    }
}
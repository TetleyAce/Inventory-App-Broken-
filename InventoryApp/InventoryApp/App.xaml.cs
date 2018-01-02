using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

using ZXing.Mobile;

namespace InventoryApp
{
	public partial class App : Application
	{

        static ItemDatabase database;
		public App ()
		{
            try
            {
                InitializeComponent();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                Console.WriteLine(e.Data);
            }
			

			MainPage = new NavigationPage( new ItemListPage());
		}

        public static ItemDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ItemDatabase(DependencyService.Get<ILocalFileHandler>().GetLocalFilePath("Item.db3"));
                }
                return database;
            }
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

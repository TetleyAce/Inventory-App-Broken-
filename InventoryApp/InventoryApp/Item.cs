using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace InventoryApp
{
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int ItemId
        {
            get;
            set;
        }

        public string ItemName
        {
            get;
            set;
        }

        public string Barcode
        {
            get;
            set;
        }

        public int Quantity
        {
            get;
            set;
        }
    }
}

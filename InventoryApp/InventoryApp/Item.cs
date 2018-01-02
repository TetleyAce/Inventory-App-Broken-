using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace InventoryApp
{
    public class Item : IEquatable<Item>
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

        public bool Equals(Item other)
        {
            // Would still want to check for null etc. first.
            return this.ItemId == other.ItemId &&
                   this.ItemName == other.ItemName &&
                   this.Barcode == other.Barcode &&
                   this.Quantity == other.Quantity;
        }
    }
}

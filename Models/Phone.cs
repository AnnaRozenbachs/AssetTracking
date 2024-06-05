using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.Models
{
    public class Phone : Asset
    {
        public Phone(string model, string brand, string office, DateTime purchasedate, decimal price, string currency, decimal localprice)
        {
            Model = model;
            Brand = brand;
            Office = office;
            PurchaseDate = purchasedate;
            Price = price;
            Currency = currency;
            LocalPrice = localprice;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.Models
{
    public class Asset
    {
        public string Model { get; set; }

        public string Brand { get; set; }

        public string Office { get; set; }

        public DateTime PurchaseDate { get; set; }


        public decimal Price { get; set; }

        public string Currency { get; set; }

        public decimal LocalPrice { get; set; }
    }
}

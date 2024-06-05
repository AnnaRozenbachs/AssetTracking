using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.Models
{
    public class AssetInputs
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public string Office { get; set; }

        public string PurchaseDate { get; set; }

        public string PurchasePrice { get; set; }
    }
}

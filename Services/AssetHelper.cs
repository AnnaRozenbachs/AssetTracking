using AssetTracking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking.Services
{
    public class AssetHelper
    {
        public AssetInputs GetAssetInputs()
        {
            Console.WriteLine("Enter a brand:");
            var brand = Console.ReadLine();
            Console.WriteLine("Enter a model: ");
            var model = Console.ReadLine();
            Console.WriteLine("Select a office - (1) Sweden (2) USA (3) Italy");
            var office = Console.ReadLine();
            Console.WriteLine("Enter a purchasedate:");
            var purchaseDate = Console.ReadLine();
            Console.WriteLine("Enter a price: ");
            var purchasePrice = Console.ReadLine();

            return new AssetInputs
            {
                Brand = brand, 
                Office = office, 
                Model = model, 
                PurchaseDate = purchaseDate, 
                PurchasePrice = purchasePrice
            };
        }
        public string Office(string office)
        {
            switch (office)
            {
                case "1":
                    return "Sweden";
                case "2":
                    return "USA";
                default:
                    return "Italy";
            }
        }

        public Asset CalculateCurrency(Asset asset)
        {
            switch (asset.Office)
            {
                case "Sweden":
                    asset.LocalPrice = Math.Round((asset.Price * (decimal)10.46),2);
                    asset.Currency = "SEK";
                    break;
                case "Italy":
                    asset.LocalPrice = Math.Round((asset.Price * (decimal)0.92),2);
                    asset.Currency = "EUR";
                    break;
                default:
                    asset.LocalPrice = Math.Round(asset.Price,2);
                    asset.Currency = "USD";
                    break;
               
            }
            return asset;
        }

        public void CheckDateExpiration(DateTime purchaseDate)
        {
            var expiredDate = purchaseDate.AddYears(3);
            var currentThreeMonthSpan = DateTime.Now.AddMonths(3);
            var currentSixMonthSpan = DateTime.Now.AddMonths(6);

            if(DateTime.Now.Year > expiredDate.Year 
                || (DateTime.Now.Year == expiredDate.Year && currentThreeMonthSpan.Month >= expiredDate.Month))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(purchaseDate.ToString("yy-MM-dd").PadRight(10));
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (DateTime.Now.Year > expiredDate.Year 
                || (DateTime.Now.Year == expiredDate.Year && currentSixMonthSpan.Month >= expiredDate.Month))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(purchaseDate.ToString("yy-MM-dd").PadRight(10));
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.Write(purchaseDate.ToString("yy-MM-dd").PadRight(10));
            }


        }

        public void ShowList(List<Asset> assets)
        {

            Console.WriteLine(
                "Type".PadRight(10) +
                "Brand".PadRight(10) +
                "Model".PadRight(10) +
                "Office".PadRight(10) +
                "Date".PadRight(10) +
                "Price".PadRight(10) +
                "Currency".PadRight(10) +  
                "Local price");

            var sortedAssets = assets.OrderBy(a=>a.Office).ThenBy(a=>a.PurchaseDate);
            foreach (Asset asset in sortedAssets)
            {
                var localPrice = CalculateCurrency(asset).LocalPrice;
                var currency = CalculateCurrency(asset).Currency;
               
                Console.Write(asset.GetType().Name.PadRight(10));
                Console.Write(asset.Brand.PadRight(10));
                Console.Write(asset.Model.PadRight(10));
                Console.Write(asset.Office.PadRight(10));
                CheckDateExpiration(asset.PurchaseDate);
                Console.Write(asset.Price.ToString().PadRight(10));
                Console.Write(currency.PadRight(10));
                Console.Write(localPrice.ToString() + "\n");
            }
        }

    }
}

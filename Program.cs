using AssetTracking.Models;
using AssetTracking.Services;

List<Asset> assets = new List<Asset>();
AssetHelper assetHelper = new AssetHelper();

while (true)
{
    RunApplication();
}

void RunApplication()
{
    Console.WriteLine("Choose asset to add (1) Computer (2) Phone. Show assetlist by entering (3)");
    var type = Console.ReadLine();

    AssetInputs inputs = null;

    try
    {
        switch (type)
        {
            case "1":
                inputs = assetHelper.GetAssetInputs();
                var computer = new Computer(inputs.Model, inputs.Brand, assetHelper.Office(inputs.Office), DateTime.Parse(inputs.PurchaseDate), decimal.Parse(inputs.PurchasePrice));
                assets.Add(computer);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Asset is created");
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case "2":
                inputs = assetHelper.GetAssetInputs();
                var phone = new Phone(inputs.Model, inputs.Brand, assetHelper.Office(inputs.Office), DateTime.Parse(inputs.PurchaseDate), decimal.Parse(inputs.PurchasePrice));
                assets.Add(phone);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Asset is created");
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case "3":
                assetHelper.ShowList(assets);
                break;
        }
       
    }
    catch(Exception e)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(e.Message);
        Console.ForegroundColor = ConsoleColor.White;
    }


}
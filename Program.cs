// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
//using Asset_Tracking_3_Lavinia;

using Asset_Tracking_3_Lavinia;

while (true)
{

    List<Assets> assets = new List<Assets>();
    Console.WriteLine("Enter an asset name: \n Exit the prompt with 'q' \n ------------- \n Already existing categories are 'computer' and 'cellphone'");
    string TypeOfAsset = Console.ReadLine();

    if (TypeOfAsset.ToLower().Contains("q"))
    {
        break;
    }

    Console.WriteLine("Enter the purchasing date (YYYY-MM-DD): ");
    string Purchased = Console.ReadLine();

    try
    {
        bool isPurchaseTimeRight = DateTime.TryParse(Purchased, out DateTime result);

        if (isPurchaseTimeRight)
        {

            DateTime PurchaseTime = Convert.ToDateTime(Purchased);

            Deprecated deprecated = new Deprecated();

            bool IsDeprecated = deprecated.CheckDeprecated(PurchaseTime);


            //om dator
            if (TypeOfAsset.Contains("computer"))
            {

                Console.WriteLine("Enter a type (already existing ones are 'stationary' and 'laptop'): ");
                string ComputerType = Console.ReadLine();
                Console.WriteLine("Brand name: ");
                string Brand = Console.ReadLine();


                //lagg till resurserna i listan
                Computers newComputer = new Computers(ComputerType, Brand, PurchaseTime, IsDeprecated);
                assets.Add(newComputer);


            }
            else if (TypeOfAsset.Contains("cellphone"))
            {
                Console.WriteLine("Enter a type (already existing ones are 'smartphone' and 'oldermodel'): ");
                string CellType = Console.ReadLine();
                Console.WriteLine("Brand name: ");
                string Brand = Console.ReadLine();

                //lagg till resurserna i listan
                CellPhones newCell = new CellPhones(CellType, Brand, PurchaseTime, IsDeprecated);
                assets.Add(newCell);


            }
            else if (TypeOfAsset != "computer" || TypeOfAsset != "cellphone")
            {

                Console.WriteLine("Skriv in en resurstyp: ");
                string AssetClass = Console.ReadLine();
                Console.WriteLine("Skriv in ett marke: ");
                string Brand = Console.ReadLine();


                //lagg till resurserna i listan
                OtherAssets newAsset = new OtherAssets(TypeOfAsset, AssetClass, Brand, PurchaseTime, IsDeprecated);
                assets.Add(newAsset);


            }

        }
    }
    catch (FormatException WrongDateFormat)
    {
        Console.WriteLine($"Datum ska vara i formatet YYYY-MM-DD: {WrongDateFormat}");
    }


            

          ListAssets(assets);

}

void ListAssets(List<Assets> assets)
{

    //visa produkterna
    if (assets.Count != 0)
    {

        try
        {

            Console.WriteLine("RESOURCES THAT ARE IN THE DB");

            Console.WriteLine($"Resource Category".PadRight(25) + "Type".PadRight(25) + "Brand".PadRight(25) + "Purchase Date");


            //sortering per kategori sen inkopsdatum

            assets = assets.OrderBy(assets => assets.GetType().Name)
                .ThenBy(assets => assets.Purchased.ToString()).ToList();
            Console.WriteLine(" ");


            foreach (Assets asset in assets)
            {


                if (asset is Computers && (asset as Computers).IsDeprecated == true)
                {

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine((asset as Computers).ResourceType.PadRight(25) + " " + (asset as Computers).Brand.PadRight(25)
                   + " " + (asset as Computers).ComputerType.PadRight(25) + (asset as Computers).Purchased
                   , Console.ForegroundColor);
                    Console.ResetColor();

                }
                else if (asset is Computers && (asset as Computers).IsDeprecated == false)
                {

                    Console.WriteLine((asset as Computers).ResourceType.PadRight(25) + " " + (asset as Computers).Brand.PadRight(25)
                   + " " + (asset as Computers).ComputerType.PadRight(25) + (asset as Computers).Purchased
                   );
                }
                //Check if asset object is a cellphone object
                else if (asset is CellPhones && (asset as CellPhones).IsDeprecated == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine((asset as CellPhones).ResourceType.PadRight(25) + " " + (asset as CellPhones).Brand.PadRight(25)
                            + " " + (asset as CellPhones).CellType.PadRight(25) + (asset as CellPhones).Purchased
                            , Console.ForegroundColor);
                    Console.ResetColor();
                }
                else if (asset is CellPhones && (asset as CellPhones).IsDeprecated == false)
                {
                    Console.WriteLine((asset as CellPhones).ResourceType.PadRight(25) + " " + (asset as CellPhones).Brand.PadRight(25)
                          + " " + (asset as CellPhones).CellType.PadRight(25) + (asset as CellPhones).Purchased
                          );
                }

                //Check if asset object is a new asset object
                else if (asset is OtherAssets && (asset as OtherAssets).IsDeprecated == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine((asset as OtherAssets).ResourceType.PadRight(25) + " " + (asset as OtherAssets).Brand.PadRight(25)
                            + " " + (asset as OtherAssets).AssetClass.PadRight(25)
                         + (asset as OtherAssets).Purchased, Console.ForegroundColor);
                    Console.ResetColor();

                }
                else if (asset is OtherAssets && (asset as OtherAssets).IsDeprecated == false)
                {

                    Console.WriteLine((asset as OtherAssets).ResourceType.PadRight(25) + " " + (asset as OtherAssets).Brand.PadRight(25)
                            + " " + (asset as OtherAssets).AssetClass.PadRight(25)
                         + (asset as OtherAssets).Purchased);
                }

            }


        }
        catch (Exception exc)
        {
            Console.WriteLine($"FEL: {exc}");
        }




    }
    //throw new NotImplementedException();
}
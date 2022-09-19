// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
//using Asset_Tracking_3_Lavinia;

using Asset_Tracking_3_Lavinia;
using System;




    List<Assets> assets = new List<Assets>();


   


while (true)
{

    Console.WriteLine("Exit the prompt with 'q' \n ------------- \n Already existing categories are 'computer' and 'cellphone' \n ------------------------------ \n >>> Enter an asset type: \n");
    string TypeOfAsset = Console.ReadLine();

    if (TypeOfAsset.ToLower().Contains("q"))
    {
        ListAssets(assets);
        break;
    }

    Console.WriteLine(">>> Enter the purchasing date (YYYY-MM-DD): ");
    string Purchased = Console.ReadLine();

    try
    {
        bool isPurchaseTimeRight = DateTime.TryParse(Purchased, out DateTime result);

        int index = 0;

        if (isPurchaseTimeRight)
        {

            DateTime PurchaseTime = Convert.ToDateTime(Purchased);

        Deprecated deprecated = new Deprecated();

        bool IsDeprecated = deprecated.CheckDeprecated(PurchaseTime);


        //om dator
        if (TypeOfAsset.Contains("computer"))
        {
            Console.WriteLine(">>> Enter brand name: ");
            string Brand = Console.ReadLine();
            // Console.WriteLine(Brand);


            //lagg till resurserna i listan
            Computers newComputer = new Computers(Brand, PurchaseTime, IsDeprecated);
            assets.Add(newComputer);


        }
        else if (TypeOfAsset.Contains("cellphone"))
        {
            Console.WriteLine(">>> Enter brand name: ");
            string Brand = Console.ReadLine();

            //lagg till resurserna i listan
            CellPhones newCell = new CellPhones(Brand, PurchaseTime, IsDeprecated);
            assets.Add(newCell);


        }
        else if (TypeOfAsset != "computer" || TypeOfAsset != "cellphone")
        {

            Console.WriteLine(">>> Enter brand name: ");
            string Brand = Console.ReadLine();


            //lagg till resurserna i listan
            OtherAssets newAsset = new OtherAssets(TypeOfAsset, Brand, PurchaseTime, IsDeprecated);

            try
            {
                assets.Add(newAsset);
                // Console.WriteLine(">>>>>>>>>>>>>> ADDED OK ");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                // Console.WriteLine("y cannot be 0");
            }


        }
        // }

        Console.WriteLine($"***** Produkt {index} added. Enter more products or end with 'q' ***** \n\n");
        index += 1;
    }
    }
    catch (FormatException WrongDateFormat)
    {
        Console.WriteLine($"Date format should be YYYY-MM-DD: {WrongDateFormat}");
    }


 } //end while true







void ListAssets(List<Assets> assets)
{


    try
    {

        Console.WriteLine("RESOURCES THAT ARE IN THE DB");

            Console.WriteLine($"Resource Type".PadRight(25) + "Brand".PadRight(25) + "Purchase Date");

            //LINQ
            var result = from d1 in assets 
                         select new { d1.ResourceType, d1.IsDeprecated, d1.Purchased, d1.Brand } 
                         into allEntered
                         select new { allEntered.ResourceType, allEntered.Brand, allEntered.Purchased, allEntered.IsDeprecated};

            result = result.OrderBy(result => result.ResourceType).ToList();


           // foreach (Assets asset in assets)
           foreach (var res in result)
            {
               

                if (res.IsDeprecated == true)
                { 

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine(res.ResourceType.PadRight(25) + " " + res.Brand.PadRight(25)
                   + " " + res.Purchased, Console.ForegroundColor);
                    Console.ResetColor();

                }
                else if (res.IsDeprecated == false)
                {

                    Console.WriteLine(res.ResourceType.PadRight(25) + " " + res.Brand.PadRight(25)
                   + " " + res.Purchased);
                }
            }


    }
            catch (Exception exc)
    {
       Console.WriteLine($"fel: {exc}");
    }




} // end list assets



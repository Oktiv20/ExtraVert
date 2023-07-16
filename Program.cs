List<Plant> plants = new List<Plant>()
{
    new Plant()
    {
        Species = "Bamboo",
        LightNeeds = 1,
        AskingPrice = 10.50m,
        City = "Nashville",
        ZIP = "37204",
        IsSold = false
    },
    new Plant()
    {
        Species = "Fern",
        LightNeeds = 3,
        AskingPrice = 30.99m,
        City = "Ashville",
        ZIP = "28715",
        IsSold = false
    },
    new Plant()
    {
        Species = "Rosebush",
        LightNeeds = 5,
        AskingPrice = 19.99m,
        City = "New York",
        ZIP = "10004",
        IsSold = false
    },
    new Plant()
    {
        Species = "Aloe Vera",
        LightNeeds = 2,
        AskingPrice = 5.00m,
        City = "Chicago",
        ZIP = "60018",
        IsSold = true
    },
    new Plant()
    {
        Species = "Palm",
        LightNeeds = 2,
        AskingPrice = 59.99m,
        City = "Los Angeles",
        ZIP = "90001",
        IsSold = true
    },  
};

string greeting = @"Welcome to ExtraVert
Your one-stop shop for buying plants you won't take care of!";

Console.WriteLine(greeting);
string choice = null;
while (choice != "0")
{
    Console.WriteLine(@"Please choose an option:
    0. Exit
    1. Display all plants
    2. Post plant for adoption
    3. Adopt a plant
    4. Delist a plant");
    choice = Console.ReadLine();

    if (choice == "0")
    {
        Console.WriteLine("See you next time!");
    }
    else if (choice == "1")
    {
        ViewAllPlants();
        Console.WriteLine("Press any key to continue:");
        Console.ReadKey();
    }
    else if (choice == "2")
    {
        throw new NotImplementedException("Post plant for adoption");
    }
    else if (choice == "3")
    {
        throw new NotImplementedException("Adopt a plant");
    }
    else if (choice == "4")
    {
        throw new NotImplementedException("Delist a plant");
    }
}


void ViewAllPlants() {

    Console.WriteLine("Plants:");
    for (int i = 0; i < plants.Count; i++)
    {
        var plant = plants[i];
        Console.WriteLine($"{i + 1}. {plant.Species}");
    }

    Plant chosenPlant = null;

    while (chosenPlant == null)
    {
        Console.WriteLine("Please enter a plant number:");
        try
        {
            int response = int.Parse(Console.ReadLine().Trim());
            chosenPlant = plants[response - 1];
        }
        catch (FormatException)
        {
            Console.WriteLine("Please choose the correct number!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please choose an existing item only!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Not valid choice. Please try again.");
        }
    }

    Console.WriteLine(@$"You chose:
{chosenPlant.Species}, which costs ${chosenPlant.AskingPrice}.");
}

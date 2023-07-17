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
        Species = "Ficus",
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
string? choice = null;

// MAIN MENU 

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
        PostPlant();
        Console.WriteLine("Press any key to continue:");
        Console.ReadKey();
    }
    else if (choice == "3")
    {
        AdoptPlant();
        Console.WriteLine("Press any key to continue:");
        Console.ReadKey();
    }
    else if (choice == "4")
    {
        RemovePlant();
        Console.WriteLine("Press any key to continue:");
        Console.ReadKey();
    }
}

// DISPLAY ALL PLANTS

void ViewAllPlants() {

    Console.WriteLine("Plants:");
    for (int i = 0; i < plants.Count; i++)
    {
        var plant = plants[i];
        Console.WriteLine($"{i + 1}. {plant.Species}");
    }

    Plant chosenPlant = null!;

    while (chosenPlant == null)
    {
        Console.WriteLine("Please enter a plant number:");
        try
        {
            int response = int.Parse(Console.ReadLine()!.Trim());
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
            Console.WriteLine("Not a valid choice. Please try again.");
        }
    }

    Console.WriteLine(@$"A {chosenPlant.Species} in {chosenPlant.City} {(chosenPlant.IsSold ? "was sold" : "is available" )} for ${chosenPlant.AskingPrice}.");
}

// POST PLANT FOR ADOPTION

void PostPlant()
{
    Console.WriteLine("Add a new plant");
    Console.WriteLine("Enter the species of the plant:");
    string? species = Console.ReadLine()!;

    Console.WriteLine("Enter the light needs of the plant using numbers 1-5:");
    int lightNeeds = int.Parse(Console.ReadLine()!.Trim());

    Console.WriteLine("Enter the price of the plant:");
    decimal askingPrice = decimal.Parse(Console.ReadLine()!.Trim());

    Console.WriteLine("Enter the city:");
    string? city = Console.ReadLine()!;
    
    Console.WriteLine("Enter the zip code:");
    string? zipCode = Console.ReadLine();

    Plant plant = new Plant
    {
        Species = species,
        LightNeeds = lightNeeds,
        AskingPrice = askingPrice,
        City = city,
        ZIP = zipCode
    };

    plants.Add(plant);

    Console.WriteLine("You've successfully added a plant!");
}

void AdoptPlant()
{
    Console.WriteLine("Choose a plant to adopt:");

    List<Plant> adoptablePlants = plants.Where(plant => !plant.IsSold).ToList();

    Console.WriteLine("Plants available for adoption:");

    for (int i = 0; i < adoptablePlants.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {adoptablePlants[i].Species}");
    }

    Plant adoptedPlant = null!;

    while (adoptedPlant == null)
    {
        Console.WriteLine("Please enter a plant number to adopt:");
        try
        {
            int response = int.Parse(Console.ReadLine()!.Trim());
            adoptedPlant = adoptablePlants[response - 1];
            adoptedPlant.IsSold = true;
        }
        catch (FormatException)
        {
            Console.WriteLine("Please choose the correct number!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please choose an existing plant only!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Not a valid choice. Please try again.");
        }
    }
    Console.WriteLine($"You've successfully adopted a {adoptedPlant.Species} plant!");
}

void RemovePlant()
{
    Console.WriteLine("Choose a plant to remove:");

    for (int i = 0; i < plants.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {plants[i].Species}");
    }

    Plant RemovePlant = null!;

    while (RemovePlant == null)
    {
        try
        {
            Console.WriteLine("Enter plant number to remove:");
            int response = int.Parse(Console.ReadLine()!.Trim());
            RemovePlant = plants[response - 1];
        }
        catch (FormatException)
        {
            Console.WriteLine("Please enter a valid number from list.");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please enter a valid number from list.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Not a valid choice. Please try again.");
        }
    }

    plants.Remove(RemovePlant);

    Console.WriteLine($"You've removed a {RemovePlant.Species} plant!");
}
List<Plant> plants = new List<Plant>()
{
    new Plant()
    {
        Species = "Bamboo",
        LightNeeds = 1,
        AskingPrice = 10,
        City = "Nashville",
        ZIP = "37204",
        IsSold = false
    },
    new Plant()
    {
        Species = "Fern",
        LightNeeds = 3,
        AskingPrice = 30,
        City = "Ashville",
        ZIP = "00012",
        IsSold = false
    },
    new Plant()
    {
        Species = "Rosebush",
        LightNeeds = 5,
        AskingPrice = 20,
        City = "New York",
        ZIP = "38421",
        IsSold = false
    },
    new Plant()
    {
        Species = "Aloe Vera",
        LightNeeds = 2,
        AskingPrice = 5,
        City = "Chicago",
        ZIP = "78475",
        IsSold = true
    },
    new Plant()
    {
        Species = "Palm",
        LightNeeds = 2,
        AskingPrice = 60,
        City = "Los Angeles",
        ZIP = "90062",
        IsSold = true
    },  
};

string greeting = @"Welcome to ExtraVert
Your one-stop shop for buying plants you won't take care of!";

Console.WriteLine(greeting);
string choice = null;

for (int i = 0; i < plants.Count; i++)
{
    var plant = plants[i];
    Console.WriteLine($"{i + 1}. {plant.Species}");
}
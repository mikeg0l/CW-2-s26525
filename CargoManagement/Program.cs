using CargoManagement;

// TEST 1: Creating containers of different types
Console.WriteLine("=== TEST 1: Creating containers ===");
var liquidContainer = new LiquidContainer(500, 250, 200, 2000);
var gasContainer = new GasContainer(400, 220, 200, 1500);
var cooledContainer = new CooledContainer(600, 260, 220, 2500, ProductType.Bananas, 12.5);

Console.WriteLine("Created containers:");
Console.WriteLine(liquidContainer);
Console.WriteLine(gasContainer);
Console.WriteLine(cooledContainer);
Console.WriteLine();

// TEST 2: Loading cargo into containers
Console.WriteLine("=== TEST 2: Loading cargo ===");
var waterCargo = new Cargo(ProductType.Water, 1000);
var gasCargo = new Cargo(ProductType.Gas, 800);
var bananaCargo = new Cargo(ProductType.Bananas, 1500, 12.0);
var dangerousLiquid = new Cargo(ProductType.Petrol, 500, isDangerous: true);

try
{
    Console.WriteLine("Loading water into liquid container...");
    liquidContainer.Load(waterCargo);
    Console.WriteLine("Loading gas into gas container...");
    gasContainer.Load(gasCargo);
    Console.WriteLine("Loading bananas into cooled container...");
    cooledContainer.Load(bananaCargo);
    Console.WriteLine("Loading dangerous liquid into liquid container...");
    liquidContainer.Load(dangerousLiquid);
}
catch (OverfillException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
Console.WriteLine();

// TEST 3: Creating container ships
Console.WriteLine("=== TEST 3: Creating container ships ===");
var ship1 = new ContainerShip(30, 10, 50);
var ship2 = new ContainerShip(25, 15, 70);

Console.WriteLine("Created ships:");
Console.WriteLine("Ship 1: " + ship1);
Console.WriteLine("Ship 2: " + ship2);
Console.WriteLine();

// TEST 4: Loading a container onto a ship
Console.WriteLine("=== TEST 4: Loading a container onto a ship ===");
ship1.LoadContainer(liquidContainer);
Console.WriteLine("After loading liquid container onto ship 1:");
Console.WriteLine("Ship 1: " + ship1);
Console.WriteLine();

// TEST 5: Loading a list of containers onto a ship
Console.WriteLine("=== TEST 5: Loading multiple containers onto a ship ===");
Console.WriteLine("Ship 1: " + ship1);
var containerList = new List<Container> { gasContainer, cooledContainer };
ship1.LoadContainers(containerList);
Console.WriteLine("After loading multiple containers onto ship 1:");
Console.WriteLine("Ship 1: " + ship1);
Console.WriteLine();

// TEST 6: Removing a container from a ship
Console.WriteLine("=== TEST 6: Removing a container from a ship ===");
ship1.UnloadContainer(gasContainer);
Console.WriteLine("After removing gas container from ship 1:");
Console.WriteLine("Ship 1: " + ship1);
Console.WriteLine();

// TEST 7: Emptying a container
Console.WriteLine("=== TEST 7: Emptying a container ===");
Console.WriteLine("Before emptying cooled container:");
Console.WriteLine(cooledContainer);
cooledContainer.Empty();
Console.WriteLine("After emptying cooled container:");
Console.WriteLine(cooledContainer);

Console.WriteLine("Before emptying gas container:");
Console.WriteLine(gasContainer);
gasContainer.Empty();
Console.WriteLine("After emptying gas container (should retain 5% of gas):");
Console.WriteLine(gasContainer);
Console.WriteLine();

// TEST 8: Replacing a container on a ship
Console.WriteLine("=== TEST 8: Replacing a container on a ship ===");
// Create a new container to replace with
var newLiquidContainer = new LiquidContainer(450, 240, 190, 1800);
newLiquidContainer.Load(new Cargo(ProductType.Juice, 1200));

Console.WriteLine("Before replacing liquid container on ship 1:");
Console.WriteLine("Ship 1: " + ship1);

ship1.ReplaceContainer(liquidContainer, newLiquidContainer);

Console.WriteLine("After replacing liquid container on ship 1:");
Console.WriteLine("Ship 1: " + ship1);
Console.WriteLine();

// TEST 9: Moving a container between two ships
Console.WriteLine("=== TEST 9: Moving a container between ships ===");
Console.WriteLine("Before moving cooled container from ship 1 to ship 2:");
Console.WriteLine("Ship 1: " + ship1);
Console.WriteLine("Ship 2: " + ship2);

ship1.MoveContainer(cooledContainer, ship2);

Console.WriteLine("After moving cooled container from ship 1 to ship 2:");
Console.WriteLine("Ship 1: " + ship1);
Console.WriteLine("Ship 2: " + ship2);
Console.WriteLine();

// TEST 10: Displaying information about a specific container
Console.WriteLine("=== TEST 10: Displaying information about a specific container ===");
Console.WriteLine("Liquid container information:");
Console.WriteLine(liquidContainer);
Console.WriteLine("Gas container information:");
Console.WriteLine(gasContainer);
Console.WriteLine("Cooled container information:");
Console.WriteLine(cooledContainer);
Console.WriteLine();

// TEST 11: Displaying information about a ship and its cargo
Console.WriteLine("=== TEST 11: Displaying information about ships and their cargo ===");
Console.WriteLine("Ship 1 information:");
Console.WriteLine(ship1);
Console.WriteLine("Ship 2 information:");
Console.WriteLine(ship2);

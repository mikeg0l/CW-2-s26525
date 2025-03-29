namespace CargoManagement;

public class GasContainer : Container, IHazardNotifier
{
    private static int _serialNumberCounter = 1;
    
    public GasContainer(double weight, int height, int depth, double capacity) : 
        base(weight, height, depth, capacity)
    {
        SerialNumber += "G-" + _serialNumberCounter++;
    }
    
    public void Notify(string message)
    {
        Console.WriteLine($"Dangerous operation detected - {message} - {SerialNumber}");
    }

    public override void Empty()
    {
       // W momencie kiedy opróżniamy kontener na gaz - pozostawiamy 5% jego ładunku wewnątrz kontenera. 
    
       
        double remainingGas = CargoList.Sum(c => c.Weight) * 0.05;
        CargoList.Clear();
        CargoList.Add(new Cargo(ProductType.Gas, remainingGas));
    }
}
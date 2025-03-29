namespace CargoManagement;

public class LiquidContainer : Container, IHazardNotifier
{
    private static int _serialNumberCounter = 1;
    public bool IsCarryingDangerousLiquid { get; set; }
    
    public LiquidContainer(double weight, int height, int depth, double capacity) : 
        base(weight, height, depth, capacity)
    {
        SerialNumber += "L-" + _serialNumberCounter++;
    }
    
    public void Notify(string message)
    {
        Console.WriteLine($"Dangerous operation detected: {message} for {SerialNumber}");
    }

    public override void Load(Cargo cargo)
    {
        if (IsCarryingDangerousLiquid && CargoList.Sum(c => c.Weight) + cargo.Weight > Capacity * 0.5)
        {
            Notify("Liquid container is carrying dangerous cargo, cannot load more");
            return; 
        }
        if (CargoList.Sum(c => c.Weight) + cargo.Weight > Capacity * 0.9)
        {
            Notify("Container is at 90% capacity, cannot load more");
            return; 
        }
        
        base.Load(cargo);
        
        if (cargo.IsDangerous is not null && cargo.IsDangerous == true)
        {
            IsCarryingDangerousLiquid = true;
        }
    }

    public override string ToString()
    {
        return base.ToString() + " - Is carrying dangerous liquid: " + IsCarryingDangerousLiquid;
    }
}

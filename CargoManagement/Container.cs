namespace CargoManagement;

public abstract class Container
{
    public double Weight { get; set; }
    public int Height { get; set; }

    public List<Cargo> CargoList { get; set; } = [];
    public int Depth { get; set; }
    public string SerialNumber { get; set; }
    public double Capacity { get; set; }
    
    public Container(double weight, int height, int depth, double capacity)
    {
        Weight = weight;
        Height = height;
        Depth = depth;
        Capacity = capacity;
        SerialNumber = "KON-";
    }
    
    public virtual void Empty()
    {
       CargoList.Clear();
    }
    
    public virtual void Load(Cargo cargo)
    {
        if (CargoList.Sum(c => c.Weight) + cargo.Weight > Capacity)
        {
            throw new OverfillException("Container is full");
        }
        CargoList.Add(cargo); 
    }
    
    public override string ToString()
    {
        return $"Serial number: {SerialNumber} - cargo Weight: {CargoList.Sum(c => c.Weight)} kg" +
               $" - Capacity: {Capacity} kg - Container weight: {Weight} kg - Height: {Height} cm - Depth: {Depth} cm" +
               $" - cargo list: {string.Join(", ", CargoList.Select(c => c.ToString()))}";
    }
}
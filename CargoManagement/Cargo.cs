namespace CargoManagement;

public class Cargo
{
    public ProductType ProductType { get; set; }
    public double Weight { get; set; }
    public double? Temperature { get; set; }
    public bool? IsDangerous { get; set; }
    
    public Cargo(ProductType productType, double weight, double? temperature = null, bool? isDangerous = null)
    {
        Temperature = temperature;
        Weight = weight;
        IsDangerous = isDangerous;
        ProductType = productType;
    }
    
    public override string ToString()
    {
        return $"Product type: {ProductType} - Weight: {Weight} kg - Temperature: {Temperature} Celsius - Is Dangerous: {IsDangerous}";
    }
}
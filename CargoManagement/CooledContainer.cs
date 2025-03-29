namespace CargoManagement;

public class CooledContainer : Container, IHazardNotifier
{
   private static Dictionary<ProductType, double> _productTypeTemperatures = new()
   {
      { ProductType.Bananas, 13.3 },
      { ProductType.Chocolate, 18 },
      { ProductType.Fish, 2 },
      { ProductType.Meat, -15 },
      { ProductType.IceCream, -18 },
      { ProductType.FrozenPizza, -30 },
      { ProductType.Cheese, 7.2 },
      { ProductType.Sausages, 5 },
      { ProductType.Butter, 20.5 },
      { ProductType.Eggs, 19 }
   };
   
   private static int _serialNumberCounter = 1;
   
   public ProductType ProductType { get; set; }
   
   public double Temperature { get; set; }

   public CooledContainer(double weight, int height, int depth, double capacity, ProductType productType, double temperature) 
      : base(weight, height, depth, capacity)
   {
      SerialNumber = SerialNumber + "C-"  + _serialNumberCounter++;
      ProductType = productType;
      Temperature = temperature;
   }
   
   public override void Load(Cargo cargo)
   {
      if (cargo.ProductType != ProductType)
      {
         Notify("Product type mismatch");
         return;
      }
      
      if (cargo.Temperature > _productTypeTemperatures[ProductType])
      {
         Notify("Temperature too high for product type");
         return;
      }
      
      base.Load(cargo);
   }
   
   public void Notify(string message)
   {
      Console.WriteLine($"Dangerous operation detected - {message} - {SerialNumber}");
   }
}
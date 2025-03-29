namespace CargoManagement;

public class ContainerShip
{
    public List<Container> Containers { get; set; }
    
    public int MaxSpeed { get; set; } // in knots

    public int MaxNumberOfContainers { get; set; }
    
    public double MaxWeight { get; set; } // in tons
    
    public ContainerShip(int maxSpeed, int maxNumberOfContainers, double maxWeight)
    {
        MaxSpeed = maxSpeed;
        MaxNumberOfContainers = maxNumberOfContainers;
        MaxWeight = maxWeight;
        Containers = [];
    }
    
    public void LoadContainer(Container container)
    {
        if (Containers.Count >= MaxNumberOfContainers)
        {
            throw new OverfillException("Ship is full");
        }
        
        if (Containers.Sum(c => c.Weight) + container.Weight > MaxWeight * 1000)
        {
            throw new OverfillException("Ship is too heavy");
        }
        
        Containers.Add(container);
    }
    
    public void UnloadContainer(Container container)
    {
        if (!Containers.Contains(container))
        {
            Console.WriteLine("Container not found");
        }
        
        Containers.Remove(container);
    }
    
    public void LoadContainers(List<Container> containers)
    {
        foreach (var container in containers)
        {
            LoadContainer(container);
        }
    }
    
    public void ReplaceContainer(Container oldContainer, Container newContainer)
    {
        if (!Containers.Contains(oldContainer))
        {
            Console.WriteLine("Container not found");
            return;
        }
        
        UnloadContainer(oldContainer);
        LoadContainer(newContainer);
    }
    
    public void MoveContainer(Container container, ContainerShip destinationShip)
    {
        if (!Containers.Contains(container))
        {
            Console.WriteLine("Container not found");
            return;
        }
        
        UnloadContainer(container);
        destinationShip.LoadContainer(container);
    }

    public override string ToString()
    {
        return $"Container Ship - Max Speed: {MaxSpeed} knots - Max Number of Containers: {MaxNumberOfContainers}" +
               $" - Max Weight: {MaxWeight} tons - Current Weight: {Containers.Sum(c => c.Weight)} tons" +
               $" - Containers: {string.Join(", ", Containers.Select(c => c.ToString()))}";
    }
}
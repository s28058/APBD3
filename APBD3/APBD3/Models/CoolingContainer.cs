using APBD3.Exeptions;

namespace APBD3.Models;

public class CoolingContainer : Container
{
    public string? CurrentProduct { get; private set; }
    public double ContainerTemperature { get; }
    public double ProductTemperature { get; private set; } = 0;

    public CoolingContainer(double height,
        double containerWeight,
        double depth,
        SerialNumber serialNumber,
        double maxCargoWeight,
        double containerTemperature) : base(height,
        containerWeight,
        depth,
        serialNumber,
        maxCargoWeight)
    {
        if (serialNumber.Type != ContainerType.Cooling)
            throw new InvalidOperationException("Wrong type");

        ContainerTemperature = containerTemperature;
    }

    public void LoadCargo(double cargoToAdd, string? product, double productTemperature)
    {
        base.LoadCargo(cargoToAdd);

        if (CurrentProduct == null)
        {
            CurrentProduct = product;
            ProductTemperature = productTemperature;
        }
        else if (!CurrentProduct.Equals(product))
        {
            throw new ProductException("Wrong type of product");
        }

        if (ContainerTemperature < ProductTemperature)
        {
            throw new ProductException("Temperature of container is too low for this product");
        }
    }

    public override void UnloadCargo()
    {
        base.UnloadCargo();
        CurrentProduct = null;
        ProductTemperature = 0;
    }
    
    public override string ToString()
    {
        string productInfo = CurrentProduct != null ? $"Current Product: {CurrentProduct}\nProduct Temperature: {ProductTemperature} °C\n" : "No Product Loaded\n";
    
        return $"Cooling Container Details:\n" +
               $"Serial Number: {SerialNumber}\n" +
               $"Height: {Height} meters\n" +
               $"Depth: {Depth} meters\n" +
               $"Container Weight: {ContainerWeight} kg\n" +
               $"Max Cargo Weight: {MaxCargoWeight} kg\n" +
               $"Current Cargo Weight: {CargoWeight} kg\n" +
               $"Container Temperature: {ContainerTemperature} °C\n" +
               $"{productInfo}";
    }
}
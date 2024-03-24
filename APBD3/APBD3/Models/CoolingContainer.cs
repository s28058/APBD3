using APBD3.Exeptions;

namespace APBD3.Models;

public class CoolingContainer : Container
{
    public string CurrentProduct { get; private set; }
    public double ContainerTemperature { get; }
    public double ProductTemperature { get; }
    
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
    }

    public void LoadCargo(double cargoToAdd, string product, double productTemperature)
    {
        base.LoadCargo(cargoToAdd);
        
        if (CurrentProduct.Equals(null))
        {
            CurrentProduct = product;
        }else if (!CurrentProduct.Equals(product))
        {
            throw new ProductException("Wrong type of product");
        }

        if (ContainerTemperature < ProductTemperature)
        {
            throw new ProductException("Temperature of container is too low for this product");
        }
    }
}
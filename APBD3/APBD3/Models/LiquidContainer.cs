using System.Diagnostics.CodeAnalysis;

namespace APBD3.Models;

public class LiquidContainer : Container // TODO: Notyfikacje
{
    public CargoDanger CargoDanger { get; }
    
    public LiquidContainer(
        double height,
        double containerWeight,
        double depth,
        SerialNumber serialNumber,
        double maxCargoWeight,
        CargoDanger cargoDanger) : 
        base(
        height,
        containerWeight,
        depth,
        serialNumber,
        maxCargoWeight)
    {
        CargoDanger = cargoDanger;
    }

    private double CargoLimit => CargoDanger switch
    {
        CargoDanger.Hazardous => 0.5 * MaxCargoWeight,
        CargoDanger.Safe => 0.9 * MaxCargoWeight,
        _ => throw new ArgumentOutOfRangeException()
    };

    public override void LoadCargo(double cargoToAdd)
    {
        base.LoadCargo(cargoToAdd);
        if (CargoWeight > CargoLimit)
        {
            // TODO: Notifikacja
        }
    }
}
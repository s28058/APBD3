using System.ComponentModel;
using APBD3.Exeptions;
using APBD3.Models;
using FluentAssertions;
using Container = APBD3.Models.Container;

namespace TestAPBD3;

public class ContainerTests
{
    private Container _anyContainer = null!;

    [SetUp]
    public void Setup()
    {
        _anyContainer = new LiquidContainer(100, 40, 20, new SerialNumber(ContainerType.Liquid, 1), 100, CargoDanger.Safe);
    }
    
    [Test]
    public void ThrowExceptionWhenOverloaded()
    {
        var maxLoad = _anyContainer.MaxCargoWeight;
        var loadToMuch = () => _anyContainer.LoadCargo(maxLoad * 1.2);
        loadToMuch.Should()
            .ThrowExactly<OverfillException>();
    }
    
    [Test]
    public void ThrowNotThrowExceptionWhenLoadedToFull()
    {
        var maxLoad = _anyContainer.MaxCargoWeight;

        var loadToMuch = () => _anyContainer.LoadCargo(maxLoad);
        loadToMuch.Should()
            .NotThrow();
    }
}
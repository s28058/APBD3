using APBD3.Models;
using FluentAssertions;

namespace TestAPBD3;

public class SerialNumberTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void StartsWithKON()
    {
        var SerialNumber = new SerialNumber(ContainerType.Liquid, 1);

        string serialized = SerialNumber.ToString();
        serialized.Should().StartWith("KON");
    }
}
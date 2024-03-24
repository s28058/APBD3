using APBD3;
using APBD3.Models;
using FluentAssertions;

namespace TestAPBD3;

public class SerialNumberGeneratorTests
{
    [Test]
    public void EverySerialNumberShouldBeDifferent()
    {
        var generator = new SerialNumberGenerator();

        var s1 = generator.Get(ContainerType.Cooling);
        var s2 = generator.Get(ContainerType.Cooling);
        var s3 = generator.Get(ContainerType.Cooling);

        s1.ToString().Should().NotBeEquivalentTo(s2.ToString());
        s1.ToString().Should().NotBeEquivalentTo(s3.ToString());
        s2.ToString().Should().NotBeEquivalentTo(s3.ToString());
    }
}
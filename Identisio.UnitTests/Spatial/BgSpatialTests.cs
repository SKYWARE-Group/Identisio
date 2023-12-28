using NUnit.Framework;
using Skyware.Identisio.Spatial.Bg;

// Ignore Spelling: bg гоце

namespace Identisio.UnitTests.Spatial;

public class BgSpatialTests
{

    [TestCase("01.04", "Благоевград", "Гоце Делчев")]
    [TestCase("16.07", "Пловдив", "Марица")]
    [TestCase("22.01", "София (град)", "")]
    public void HealthRegionPositiveTests(string value, string region, string healthRegion)
    {
        HealthRegion result = HealthRegion.Parse(value);
        Assert.That(result.RegionName.Equals(region));
        Assert.That(result.MunicipalityName.Equals(healthRegion));
    }

    [TestCase("44.01")]
    [TestCase("22.05")]
    [TestCase(null)]
    [TestCase("")]
    [TestCase("AA.BB")]
    public void HealthRegionNegativeTests(string value)
    {
        bool result = HealthRegion.TryParse(value, out _);
        Assert.That(result, Is.False);
    }

}

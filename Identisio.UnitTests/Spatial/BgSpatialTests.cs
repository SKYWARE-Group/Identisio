using NUnit.Framework;
using Skyware.Identisio.Spatial.Bg;

// Ignore Spelling: bg гоце

namespace Identisio.UnitTests.Spatial;

public class BgSpatialTests
{

    [TestCase("01.04", "Благоевград", "01", "Гоце Делчев", "04")]
    [TestCase("16.07", "Пловдив", "16", "Марица", "07")]
    [TestCase("22.01", "София (град)", "22", "Средец", "01")]
    public void HealthRegionPositiveTests(string value, string region, string code, string healthRegion, string healthCode)
    {
        HealthRegion result = HealthRegion.Parse(value);
        Assert.That(result.RegionCode.Equals(code));
        Assert.That(result.RegionName.Equals(region));
        Assert.That(result.MunicipalityCode.Equals(healthCode));
        Assert.That(result.MunicipalityName.Equals(healthRegion));
    }

    [TestCase("44.01")]
    [TestCase("22.1")]
    [TestCase("22,01")]
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

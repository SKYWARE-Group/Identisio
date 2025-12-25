using NUnit.Framework;
using Skyware.Identisio.Individuals.Bg;
using System;

// Ignore Spelling: bg egn lnch uin

namespace Identisio.UnitTests.Personal;

public class BgPersonalTests
{


    [TestCase("1400000584", "Пазарджик", "14", 584)]
    [TestCase("2300065584", "София (град)", "23", 65584)]
    public void UinPositiveTests(string value, string region, string code, int seqNumber)
    {
        Uin result = Uin.Parse(value);
        Assert.That(result.RegionCode.Equals(code));
        Assert.That(result.RegionName.Equals(region));
        Assert.That(result.SequentialNumber.Equals(seqNumber));
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase("0000000000")]
    [TestCase("5200000584")]
    [TestCase("14000005841")]
    [TestCase("140005841")]
    public void UinNegativeTests(string? value)
    {
        bool result = Uin.TryParse(value, out _);
        Assert.That(result, Is.False);
    }

    // TODO: More tests for EGN and LNCH here

    [Test()]
    public void EgnParse()
    {
        Egn egn = Egn.Parse("6101057509");
        Assert.That(egn.IsMale, Is.True);
        Assert.That(egn.Birthdate == new DateTime(1961, 1, 5), Is.True);
    }

    [Test()]
    public void EgnParseErr()
    {
        Assert.Throws<ArgumentException>(() => Egn.Parse("6101137509"));
    }

    [Test()]
    public void EgnValidate()
    {
        bool egnValid = Egn.Validate("6101057509");
        Assert.That(egnValid, Is.True);
    }

    [Test()]
    public void LnchValidation()
    {
        bool isLnchValid = Lnch.Validate("0777180969");
        Assert.That(isLnchValid, Is.True);
    }

}

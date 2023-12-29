using NUnit.Framework;
using Skyware.Identisio.Organizations.Bg;

// Ignore Spelling: eik rzi bg

namespace Identisio.UnitTests.Organizations;

public class BgOrganizationsTests
{


    #region EIK

    [TestCase("121708719")]
    [TestCase("202557570")]
    [TestCase("1751162860016")]
    [TestCase("1751162861128")]
    [TestCase("1217087192000")]
    public void EikValidateTrue(string value)
    {
        var eikValidate = Eik.Validate(value);
        Assert.That(eikValidate, Is.True);
    }

    [TestCase("")]
    [TestCase("20255757")]
    [TestCase("121708729")]
    [TestCase("175116280")]
    [TestCase("202557571")]
    [TestCase("1751162860013")]
    [TestCase("1751162861127")]
    [TestCase("1217087192001")]
    [TestCase("1017087192000")]
    public void EikValidateFalse(string value)
    {
        var eikValidate = Eik.Validate(value);
        Assert.That(eikValidate, Is.False);
    }

    #endregion

    #region VATId

    [TestCase("BG121708719")]
    [TestCase("BG202557570")]
    [TestCase("BG1751162860016")]
    [TestCase("BG1751162861128")]
    [TestCase("BG1217087192000")]
    public void VATIdValidateTrue(string value)
    {
        var eikValidate = VatId.Validate(value);
        Assert.That(eikValidate, Is.True);
    }

    [TestCase("")]
    [TestCase("BG")]
    [TestCase("BG123456789852963555")]
    [TestCase("BGBG124578")]
    [TestCase("BG20255757")]
    [TestCase("BG121708729")]
    [TestCase("BG175116280")]
    [TestCase("EU202557571")]
    [TestCase("EU121708729")]
    [TestCase("EU175116280")]
    [TestCase("BG202557571")]
    [TestCase("BG1751162860013")]
    [TestCase("BG1751162861127")]
    [TestCase("BG1217087192001")]
    [TestCase("BG1017087192000")]
    public void VvatIdValidateFalse(string value)
    {
        var eikValidate = VatId.Validate(value);
        Assert.That(eikValidate, Is.False);
    }

    #endregion

    #region RZI
    
    [TestCase("0213141001", "Бургас", "23", "Царево", "14", 1, "141")] // Медико-Диагностична Лаборатория
    [TestCase("0290111234", "Бургас", "23", "", "90", 234, "111")] // Индивидуална първична извънболнична медицинска практика
    [TestCase("0204211032", "Бургас", "22", "Бургас", "04", 32, "211")] // Болница за активно лечение - многопрофилна
    [TestCase("2490141001", "Стара Загора", "24", "", "90", 1, "141")] // Медико-Диагностична Лаборатория
    public void RziPositiveTests(string value, string region, string regionCode, string municipality, string municipalityCode, int serial, string practiceType)
    {
        Rzi result = Rzi.Parse(value);
        Assert.That(result.RegionName.Equals(region));
        Assert.That(result.RegionCode.Equals(regionCode));
        Assert.That(result.MunicipalityOrSpecialName.Equals(municipality));
        Assert.That(result.MunicipalityOrSpecialCode.Equals(municipalityCode));
        Assert.That(result.PracticeTypeCode.Equals(practiceType));
        Assert.That(result.Serial.Equals(serial));
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase("1516111")]
    [TestCase("2201111000")]
    [TestCase("AAAAAAAAAA")]
    [TestCase("2245111356")]
    [TestCase("9910913001")]
    public void RziNegativeTests(string value)
    {
        var rziResult = Rzi.Validate(value);
        Assert.That(rziResult, Is.False);
    }

    #endregion

    [TestCase("2280111356")]
    [TestCase("0181913001")]
    [TestCase("1582111999")]
    public void NhifValidateTrue(string value)
    {
        var rziResult = NhifCode.Validate(value);
        Assert.That(rziResult, Is.True);
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase("1516111")]
    [TestCase("2201111000")]
    [TestCase("AAAAAAAAAA")]
    [TestCase("2283111356")]
    [TestCase("9981913001")]
    public void NhifValidateFalse(string value)
    {
        var rziResult = NhifCode.Validate(value);
        Assert.That(rziResult, Is.False);
    }

}

using NUnit.Framework;
using Skyware.Identisio.Organizations.Bg;

namespace Identisio.UnitTests.Organizations
{
    public class BgTests
    {

        [TestCase("121708719")]
        [TestCase("202557570")]              
        [TestCase("1751162860016")]
        [TestCase("1751162861128")]
        [TestCase("1217087192000")]
        public void EikValidateTrue(string eik)
        {
            var eikValidate = Eik.Validate(eik);
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
        public void EikValidateFalse(string eik) 
        {
            var eikValidate = Eik.Validate(eik);
            Assert.That(eikValidate, Is.False);
        }

        [TestCase("2201111356")]
        [TestCase("0111913001")]
        [TestCase("1516111999")]
        public void RziValidateTrue(string rziCode)
        {
            var rziResult = Rzi.Validate(rziCode);
            Assert.That(rziResult, Is.True);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("1516111")]
        [TestCase("2201111000")]
        [TestCase("AAAAAAAAAA")]
        [TestCase("2245111356")]
        [TestCase("9910913001")]
        public void RziValidateFalse(string rziCode)
        {
            var rziResult = Rzi.Validate(rziCode);
            Assert.That(rziResult, Is.False);
        }


        [TestCase("2280111356")]
        [TestCase("0181913001")]
        [TestCase("1582111999")]
        public void NhifValidateTrue(string rziCode)
        {
            var rziResult = NhifCode.Validate(rziCode);
            Assert.That(rziResult, Is.True);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("1516111")]
        [TestCase("2201111000")]
        [TestCase("AAAAAAAAAA")]
        [TestCase("2283111356")]
        [TestCase("9981913001")]
        public void NhifValidateFalse(string rziCode)
        {
            var rziResult = NhifCode.Validate(rziCode);
            Assert.That(rziResult, Is.False);
        }
    }
}

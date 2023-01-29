using NUnit.Framework;
using Skyware.Identisio.Organizations.Bg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
       
    }
}

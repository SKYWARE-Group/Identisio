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
        /// <summary>
        /// Valid Eik tests
        /// </summary>
        /// <param name="eik"></param>
        [TestCase("121708719")]       //Company - "Pension Insurance Company UBB"
        [TestCase("831447150")]       //Company - "CENTRAL COOPERATIVE BANK"
        [TestCase("1751162860016")]   //Branch of a company - "Opticom Ltd."
        [TestCase("1751162861128")]   //Branch of a company - "Opticom Ltd."
        [TestCase("1217087192000")]   //Branch of a company - "Pension Insurance Company UBB"
        public void EikValidateTrue(string eik)
        {
            var eikValidate = Eik.Validate(eik);
            Assert.That(eikValidate, Is.True);
        }

        /// <summary>
        /// Invalid Eik tests
        /// </summary>
        /// <param name="eik"></param>
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

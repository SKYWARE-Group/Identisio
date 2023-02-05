using NUnit.Framework;
using Skyware.Identisio.Individuals.Bg;
using Skyware.Identisio.Organizations.Bg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identisio.UnitTests.Personal
{
    public class BgTests
    {
        
        [Test()]
        public void EgnParse()
        {
            var egn = Egn.Parse("6101057509");
            Assert.IsTrue(egn.IsMale);
            Assert.IsTrue(egn.Birthdate == new DateTime(1961, 1, 5));
        }

        [Test()]
        public void EgnParseErr()
        {
            Assert.Throws<ArgumentException>(() => Egn.Parse("6101137509"));
        }

        [Test()]
        public void EgnValidate()
        {
            var egnValid = Egn.Validate("6101057509");
            Assert.IsTrue(egnValid);
        }

        [Test()]
        public void LnchValidation()
        {
            var isLnchValid = Lnch.Validate("0777180969");
            Assert.IsTrue(isLnchValid);
        }

        [Test()]
        public void RziParse()
        {
            var rzi = Rzi.Parse("0604221001");
            Assert.AreEqual(rzi.Region, 6);
            Assert.AreEqual(rzi.Municipality, 4);
            Assert.AreEqual(rzi.InstitutionType, 221);
            Assert.AreEqual(rzi.InstitutionNumber, 1);
        }

        [Test()]
        public void RziParseErr()
        {
            Assert.Throws<ArgumentException>(() => Rzi.Parse("0604100001"));
        }

        [Test()]
        public void RziValidate()
        {
            var isRziValid = Rzi.Validate("0604221001");
            var isRziInvalid = Rzi.Validate("0604100001");

            Assert.IsTrue(isRziValid);
            Assert.IsFalse(isRziInvalid);
        }
    }
}

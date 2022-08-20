using NUnit.Framework;
using Skyware.Identisio.Individuals.Bg;
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

    }
}

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
        [Test()]
        public void EikValidateNine()
        {
            var eikValidate = Eik.Validate("121708719");
            Assert.IsTrue(eikValidate);
        }
        [Test()]
        public void EikValidateThirteen()
        {
            var eikValidate = Eik.Validate("1751162860016");
            Assert.IsTrue(eikValidate);
        }
    }
}

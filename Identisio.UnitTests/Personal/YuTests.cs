using Identisio.Personal.Yu;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identisio.UnitTests.Personal
{
    public class YuTests
    {

        [Test()]
        public void YuPidParse()
        {
            var yuPid = YuPid.Parse("0101006500006");
            Assert.IsTrue(yuPid.IsMale);
            Assert.IsTrue(yuPid.Birthdate == new DateTime(2006, 1, 1));
        }

        [Test()]
        public void YuPidValidation()
        {
            var yuPidValid = YuPid.Validate("0101006500006");
            Assert.IsTrue(yuPidValid);
        }

    }
}

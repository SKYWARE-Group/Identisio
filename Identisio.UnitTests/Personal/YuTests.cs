using NUnit.Framework;
using Skyware.Identisio.Individuals.Yu;
using System;

namespace Identisio.UnitTests.Personal;

public class YuTests
{

    [Test()]
    public void YuPidParse()
    {
        YuPid yuPid = YuPid.Parse("0101006500006");
        Assert.That(yuPid.IsMale, Is.True);
        Assert.That(yuPid.Birthdate == new DateTime(2006, 1, 1), Is.True);
    }

    [Test()]
    public void YuPidParseErr()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => YuPid.Parse("0113006500006"));
    }

    [Test()]
    public void YuPidValidation()
    {
        bool yuPidValid = YuPid.Validate("0101006500006");
        Assert.That(yuPidValid, Is.True);
    }


}

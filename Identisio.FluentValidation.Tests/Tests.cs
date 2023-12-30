using Skyware.Identisio.FluentValidation.Validators;
using Skyware.Identisio.Individuals.Bg;
using Skyware.Identisio.Individuals.Yu;

namespace Identisio.FluentValidation.Tests;

public class Tests
{

    public static Dictionary<string, Type> CorrectIdentifiers = new()
    { 
        {"0641056880", typeof(Egn)},
        {"0777180969", typeof(Lnch)},
        {"0101006500006", typeof(YuPid)},
    };

    [Test]
    [TestCaseSource(nameof(CorrectIdentifiers))]
    public void Test1(KeyValuePair<string, Type> identifier)
    {
        Type validatorType = typeof(IdentifierValidator<>).MakeGenericType(identifier.Value);
        IValidator<string> validator = (IValidator<string>)Activator.CreateInstance(validatorType);
        validator.ValidateAndThrow(identifier.Key);
    }

}
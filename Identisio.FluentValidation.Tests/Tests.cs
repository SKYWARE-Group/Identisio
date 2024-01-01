using Identisio.FluentValidation.Tests.Model;
using Identisio.FluentValidation.Tests.Validators;
using Skyware.Identisio.FluentValidation.Validators;
using Skyware.Identisio.Individuals.Bg;
using Skyware.Identisio.Individuals.Yu;

namespace Identisio.FluentValidation.Tests;

public class Tests
{

    public static Person[] CorrectIdentifiersPeople = 
    [
        new Person() { Identifier = "0641056880", IdentifierType = IdentifierTypes.Egn },
        new Person() { Identifier = "0777180969", IdentifierType = IdentifierTypes.Lnch },
        new Person() { Identifier = "0101006500006", IdentifierType = IdentifierTypes.YuPid },
    ];

    public static Person[] InorrectIdentifiersPeople =
    [
        new Person() { Identifier = "0641056881", IdentifierType = IdentifierTypes.Egn },
        new Person() { Identifier = "0777180966", IdentifierType = IdentifierTypes.Lnch },
        new Person() { Identifier = "0101006500002", IdentifierType = IdentifierTypes.YuPid },
    ];

    public static Dictionary<string, Type> CorrectIdentifiers = new()
    { 
        {"0641056880", typeof(Egn)},
        {"0777180969", typeof(Lnch)},
        {"0101006500006", typeof(YuPid)},
    };

    public static Dictionary<string, Type> InorrectIdentifiers = new()
    {
        {"0641056881", typeof(Egn)},
        {"0777180966", typeof(Lnch)},
        {"0101006500002", typeof(YuPid)},
    };

    [Test]
    [TestCaseSource(nameof(InorrectIdentifiers))]
    public void InorrectIdentifiersTests(KeyValuePair<string, Type> identifier)
    {
        Type validatorType = typeof(IdentifierValidator<>).MakeGenericType(identifier.Value);
        IValidator<string> validator = (IValidator<string>)Activator.CreateInstance(validatorType);
        var validationResult = validator.Validate(identifier.Key);
        Assert.That(validationResult.IsValid, Is.EqualTo(false));
    }

    [Test]
    [TestCaseSource(nameof(CorrectIdentifiers))]
    public void CorrectIdentifiersTests(KeyValuePair<string, Type> identifier)
    {
        Type validatorType = typeof(IdentifierValidator<>).MakeGenericType(identifier.Value);
        IValidator<string> validator = (IValidator<string>)Activator.CreateInstance(validatorType);
        validator.ValidateAndThrow(identifier.Key);
    }

    [Test]
    [TestCaseSource(nameof(InorrectIdentifiersPeople))]
    public void InorrectIdentifiersPeopleTests(Person person)
    {
        var validator = new PersonValidator();
        var validationResult = validator.Validate(person);
        Assert.That(validationResult.IsValid, Is.EqualTo(false));
    }

    [Test]
    [TestCaseSource(nameof(CorrectIdentifiersPeople))]
    public void CorrectIdentifiersPeopleTests(Person person)
    {
        var validator = new PersonValidator();
        validator.ValidateAndThrow(person);
    }

}
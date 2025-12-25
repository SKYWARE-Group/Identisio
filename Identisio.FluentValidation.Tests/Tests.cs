using Identisio.FluentValidation.Tests.Model;
using Identisio.FluentValidation.Tests.Validators;
using FluentValidation.Results;
using Skyware.Identisio.Banking;
using Skyware.Identisio.FluentValidation.Validators;
using Skyware.Identisio.Individuals.Bg;
using Skyware.Identisio.Individuals.Yu;
using Skyware.Identisio.Organizations.Bg;
using Skyware.Identisio.Spatial.Bg;

namespace Identisio.FluentValidation.Tests;

public class Tests
{

    private static readonly Person[] CorrectIdentifiersPeople = 
    [
        new Person() { Identifier = "0641056880", IdentifierType = IdentifierTypes.Egn },
        new Person() { Identifier = "0777180969", IdentifierType = IdentifierTypes.Lnch },
        new Person() { Identifier = "0101006500006", IdentifierType = IdentifierTypes.YuPid },
        new Person() { Identifier = "121708719", IdentifierType = IdentifierTypes.Eik },
        new Person() { Identifier = "BGAABNBG96611020345678", IdentifierType = IdentifierTypes.Iban },
        new Person() { Identifier = "0213141001", IdentifierType = IdentifierTypes.Rzi },
        new Person() { Identifier = "BG121708719", IdentifierType = IdentifierTypes.VatId },
        new Person() { Identifier = "2280111356", IdentifierType = IdentifierTypes.NhifCode },
        new Person() { Identifier = "1400000584", IdentifierType = IdentifierTypes.Uin },
        new Person() { Identifier = "01.04", IdentifierType = IdentifierTypes.HealthRegion },
    ];

    private static readonly Person[] InorrectIdentifiersPeople =
    [
        new Person() { Identifier = "0641056881", IdentifierType = IdentifierTypes.Egn },
        new Person() { Identifier = "0777180966", IdentifierType = IdentifierTypes.Lnch },
        new Person() { Identifier = "0101006500002", IdentifierType = IdentifierTypes.YuPid },
        new Person() { Identifier = "121708729", IdentifierType = IdentifierTypes.Eik },
        new Person() { Identifier = "BG121708", IdentifierType = IdentifierTypes.Iban },
        new Person() { Identifier = "1516111", IdentifierType = IdentifierTypes.Rzi },
        new Person() { Identifier = "BG121708729", IdentifierType = IdentifierTypes.VatId },
        new Person() { Identifier = "2283111356", IdentifierType = IdentifierTypes.NhifCode },
        new Person() { Identifier = "0000000000", IdentifierType = IdentifierTypes.Uin },
        new Person() { Identifier = "44.01", IdentifierType = IdentifierTypes.HealthRegion },
    ];

    private static readonly Dictionary<string, Type> CorrectIdentifiers = new()
    { 
        {"0641056880", typeof(Egn)},
        {"0777180969", typeof(Lnch)},
        {"0101006500006", typeof(YuPid)},
        {"0213141001", typeof(Rzi)},
        {"BG121708719", typeof(VatId)},
        {"2280111356", typeof(NhifCode)},
        {"1400000584", typeof(Uin)},
        {"01.04", typeof(HealthRegion)},
        {"121708719", typeof(Eik)},
        {"BGAABNBG96611020345678", typeof(Iban)},
    };

    private static readonly Dictionary<string, Type> InorrectIdentifiers = new()
    {
        {"0641056881", typeof(Egn)},
        {"0777180966", typeof(Lnch)},
        {"0101006500002", typeof(YuPid)},
        {"1516111", typeof(Rzi)},
        {"BG121708729", typeof(VatId)},
        {"2283111356", typeof(NhifCode)},
        {"0000000000", typeof(Uin)},
        {"44.01", typeof(HealthRegion)},
        {"121708729", typeof(Eik)},
        {"BG121708", typeof(Iban)},
    };

    [Test]
    [TestCaseSource(nameof(InorrectIdentifiers))]
    public void InorrectIdentifiersTests(KeyValuePair<string, Type> identifier)
    {
        Type validatorType = typeof(IdentifierValidator<>).MakeGenericType(identifier.Value);
        IValidator<string> validator = (IValidator<string>)Activator.CreateInstance(validatorType)!;
        ValidationResult validationResult = validator.Validate(identifier.Key);
        Assert.That(validationResult.IsValid, Is.EqualTo(false));
    }

    [Test]
    [TestCaseSource(nameof(CorrectIdentifiers))]
    public void CorrectIdentifiersTests(KeyValuePair<string, Type> identifier)
    {
        Type validatorType = typeof(IdentifierValidator<>).MakeGenericType(identifier.Value);
        IValidator<string> validator = (IValidator<string>)Activator.CreateInstance(validatorType)!;
        validator.ValidateAndThrow(identifier.Key);
    }

    [Test]
    [TestCaseSource(nameof(InorrectIdentifiersPeople))]
    public void InorrectIdentifiersPeopleTests(Person person)
    {
        PersonValidator validator = new PersonValidator();
        ValidationResult validationResult = validator.Validate(person);
        Assert.That(validationResult.IsValid, Is.EqualTo(false));
    }

    [Test]
    [TestCaseSource(nameof(CorrectIdentifiersPeople))]
    public void CorrectIdentifiersPeopleTests(Person person)
    {
        PersonValidator validator = new PersonValidator();
        validator.ValidateAndThrow(person);
    }

}
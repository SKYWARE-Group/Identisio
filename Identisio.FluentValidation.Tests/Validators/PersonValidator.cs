using Identisio.FluentValidation.Tests.Model;
using Skyware.Identisio.FluentValidation;

namespace Identisio.FluentValidation.Tests.Validators;

public class PersonValidator : AbstractValidator<Person>
{

    /// <summary>
    /// FluentValidation validator for a string using Identisio identifier validation.
    /// </summary>
    public PersonValidator()
    {
        RuleFor(x => x.Identifier).IsValidEgn().When(x => x.IdentifierType.Equals(IdentifierTypes.Egn));
        RuleFor(x => x.Identifier).IsValidYuPid().When(x => x.IdentifierType.Equals(IdentifierTypes.YuPid));
        RuleFor(x => x.Identifier).IsValidLnch().When(x => x.IdentifierType.Equals(IdentifierTypes.Lnch));
        RuleFor(x => x.Identifier).IsValidEik().When(x => x.IdentifierType.Equals(IdentifierTypes.Eik));
        RuleFor(x => x.Identifier).IsValidIban().When(x => x.IdentifierType.Equals(IdentifierTypes.Iban));
        RuleFor(x => x.Identifier).IsValidRzi().When(x => x.IdentifierType.Equals(IdentifierTypes.Rzi));
        RuleFor(x => x.Identifier).IsValidVatId().When(x => x.IdentifierType.Equals(IdentifierTypes.VatId));
        RuleFor(x => x.Identifier).IsValidNhifCode().When(x => x.IdentifierType.Equals(IdentifierTypes.NhifCode));
        RuleFor(x => x.Identifier).IsValidUin().When(x => x.IdentifierType.Equals(IdentifierTypes.Uin));
        RuleFor(x => x.Identifier).IsValidHealthRegion().When(x => x.IdentifierType.Equals(IdentifierTypes.HealthRegion));
    }

}

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
    }

}

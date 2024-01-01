// Ignore Spelling: Egn, Lnch, Yu, Pid, Eik, Iban
using FluentValidation;
using Skyware.Identisio.Banking;
using Skyware.Identisio.FluentValidation.Validators;
using Skyware.Identisio.Individuals.Bg;
using Skyware.Identisio.Individuals.Yu;
using Skyware.Identisio.Organizations.Bg;

namespace Skyware.Identisio.FluentValidation;

public static class FluentValidationExtensions
{

    public static IRuleBuilderOptions<T, string?> IsValidEgn<T>(this IRuleBuilder<T, string> ruleBuilder) => 
        ruleBuilder.SetValidator(new IdentifierValidator<Egn>());

    public static IRuleBuilderOptions<T, string?> IsValidLnch<T>(this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new IdentifierValidator<Lnch>());

    public static IRuleBuilderOptions<T, string?> IsValidYuPid<T>(this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new IdentifierValidator<YuPid>());

    public static IRuleBuilderOptions<T, string?> IsValidEik<T>(this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new IdentifierValidator<Eik>());

    public static IRuleBuilderOptions<T, string?> IsValidIban<T>(this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new IdentifierValidator<Iban>());

}

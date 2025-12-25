using FluentValidation;
using Skyware.Identisio.Banking;
using Skyware.Identisio.FluentValidation.Validators;
using Skyware.Identisio.Individuals.Bg;
using Skyware.Identisio.Individuals.Yu;
using Skyware.Identisio.Organizations.Bg;
using Skyware.Identisio.Spatial.Bg;

// Ignore Spelling: Egn, Lnch, Yu, Pid, Eik, Iban, Rzi, Vat, Nhif, Uin

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

    public static IRuleBuilderOptions<T, string?> IsValidRzi<T>(this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new IdentifierValidator<Rzi>());

    public static IRuleBuilderOptions<T, string?> IsValidVatId<T>(this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new IdentifierValidator<VatId>());

    public static IRuleBuilderOptions<T, string?> IsValidNhifCode<T>(this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new IdentifierValidator<NhifCode>());

    public static IRuleBuilderOptions<T, string?> IsValidUin<T>(this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new IdentifierValidator<Uin>());

    public static IRuleBuilderOptions<T, string?> IsValidHealthRegion<T>(this IRuleBuilder<T, string> ruleBuilder) =>
        ruleBuilder.SetValidator(new IdentifierValidator<HealthRegion>());

}

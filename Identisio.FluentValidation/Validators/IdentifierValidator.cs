using FluentValidation;
using System;

namespace Skyware.Identisio.FluentValidation.Validators;

public class IdentifierValidator<TIdentifierBase> : AbstractValidator<string>
    where TIdentifierBase : IdentifierBase
{

    /// <summary>
    /// FluentValidation validator for a string using Identisio identifier validation.
    /// </summary>
    public IdentifierValidator()
    {
        RuleFor(element => element).Must((rootObject, el, context) =>
        {
            string errMsg = $"The input did not pass the \"Validate\" method of \"{typeof(TIdentifierBase).Name}\".";
            try
            {
                if (typeof(TIdentifierBase).GetMethod("Parse") != null && typeof(TIdentifierBase).GetMethod("Parse")!.GetParameters().Length == 1 && typeof(TIdentifierBase).GetMethod("Parse").GetParameters()[0].ParameterType == typeof(string))
                {
                    typeof(TIdentifierBase).GetMethod("Parse").Invoke(null, new object[] { el });
                    return true;
                }
                else
                {
                    context.MessageFormatter.AppendArgument("ErrorMessage", errMsg);
                    return (bool)typeof(TIdentifierBase)!.GetMethod(nameof(IdentifierBase.Validate)).Invoke(null, new string[] { el });
                }
            }
            catch (Exception ex)
            {
                if (!string.IsNullOrEmpty(ex.InnerException?.Message))
                    errMsg = ex.InnerException!.Message;
                else
                    errMsg = ex.Message;
            }
            context.MessageFormatter.AppendArgument("ErrorMessage", errMsg);
            return false;
        }).WithMessage("{ErrorMessage}");
    }

}

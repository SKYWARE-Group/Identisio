# Identisio.FluentValidation

Identisio is a library, developed by SKYWARE Group, for parsing and validation of a variety of identifiers. 
This package provides FluentValidation extensions to help with the integration of Identisio in projects using FluentValidation.

Some examples as to how can this library be used are listed bellow.

```cs
// Standalone identifier validator example
var validatorEgn = new IdentifierValidator<Egn>();
var validationResult = validatorEgn.Validate("0641056880");
// Custom abstract validator example
RuleFor(element => element).IsValidEgn();
```
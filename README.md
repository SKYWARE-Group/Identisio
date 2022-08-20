# <img src="Identisio/Assets/identisio-icon.png" height="28"> Identisio

This project is an attempt to build parsing and validation library for a variety of identifiers, such as IBAN, Vat numbers, etc.

## Usage

The easiest way to use this library is to get it from NuGet as follows:

`Install-Package Skyware.Identisio`

The identifiers comply with the well-known patterns, such as `Validate()`, `Parse(string id)` and `TryParse(string id, object x)`.

Example code:

```c#
var egn = Egn.Parse("6101057509");
Assert.IsTrue(egn.IsMale);
Assert.IsTrue(egn.Birthdate == new DateTime(1961, 1, 5));
```

## Currently supported identifiers

### <img src="Assets/individual.png" height="24"> Individuals
 - <img src="Assets/flag-bg.png" height="14"> Bulgaria
    - EGN ([Единен Граждански Номер, ЕГН](https://bg.wikipedia.org/wiki/%D0%95%D0%B4%D0%B8%D0%BD%D0%B5%D0%BD_%D0%B3%D1%80%D0%B0%D0%B6%D0%B4%D0%B0%D0%BD%D1%81%D0%BA%D0%B8_%D0%BD%D0%BE%D0%BC%D0%B5%D1%80))
    - LNCh (Личен Номер на Чужденец, ЛНЧ)
 - <img src="Assets/flag-yu.png" height="14"> Former Yougoslavian countries
    - JMBG ([ЕМБГ](https://en.wikipedia.org/wiki/Unique_Master_Citizen_Number))

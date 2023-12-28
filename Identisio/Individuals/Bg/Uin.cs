using Skyware.Identisio.Bg;
using System;
using System.Text.RegularExpressions;

// Ignore Spelling: uin

namespace Skyware.Identisio.Individuals.Bg;

/// <summary>
/// UIN (УИН) are identifiers for medical practitioners in Bulgaria.
/// Issuer: BMA (БЛС)
/// </summary>
/// <remarks>
/// Format: AABBBBBBBB, where <br/>
/// AA - Region (Област), 02-29 <br/>
/// BBBBBBBB - Sequential number (Пореден номер), 00000001 - 99999999 <br/>
/// </remarks>
public class Uin : RegionalIdentifier
{

    public override string Name => "Unique identifier number of a doctor";

    public override string NativeAbbreviation => "УИН";

    public override string NativeName => "Уникален идентификационен номер на лекар";

    public override bool IsPrivateData => false;


    public int SequentialNumber => throw new NotImplementedException();


    // Parsing

    public static Uin Parse(string value) => throw new NotImplementedException();

    public static bool TryParse(string value, out Uin result) => throw new NotImplementedException();

    // Validation

    public new static bool Validate(string value) => throw new NotImplementedException();

}

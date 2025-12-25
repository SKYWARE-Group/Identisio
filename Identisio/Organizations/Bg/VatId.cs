using System.Linq;
using System.Text.RegularExpressions;

namespace Skyware.Identisio.Organizations.Bg;


/// <summary>
/// VAT code of Bulgarian legal entities (compatible with EU VAT numbers). <br/>
/// Issuer: NRA (Агенция по вземанията).
/// </summary>
public class VatId : IdentifierBase
{
    private static readonly string[] VALID_VAT_ID_PREFIXES = ["BG"];

    public override string Name => "VAT Identification Code";

    public override string NativeAbbreviation => "ИН по ДДС";

    public override string NativeName => "Идентификационен код по ЗДДС";

    public override bool IsPrivateData => false;

    public new static bool Validate(string value)
    {
        if (string.IsNullOrEmpty(value)) return false;
        if (value.Length != 11 && value.Length != 15) return false;

        string code = value.Substring(0,2);
        if(!VALID_VAT_ID_PREFIXES.Contains(code)) return false;

        return Eik.Validate(value.Substring(2));
    }
}

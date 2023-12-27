// Ignore Spelling: uin

namespace Skyware.Identisio.Individuals.Bg;


/// <summary>
/// UIN (УИН) are identifiers for medical practitioners in Bulgaria.
/// Issuer: BMA (БЛС)
/// </summary>
public class Uin : IdentifierBase
{

    public override string Name => "Unique identifier number of a doctor";

    public override string NativeAbbreviation => "УИН";

    public override string NativeName => "Уникален идентификационен номер на лекар";

    public override bool IsPrivateData => false;

    //TODO: Implement Validate (Parse?)

}

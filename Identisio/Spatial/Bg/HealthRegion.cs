using Skyware.Identisio.Bg;
using System;

namespace Skyware.Identisio.Spatial.Bg;

/// <summary>
/// Spatially encodes location of a residence of a patient or place of a medical service.<br/>
/// Note that this class assumes "canonical" form, i.e. with dot as a delimiter.<br/>
/// WARNING: All municipalities in Sofia city region ("22") has health region "01".<br/>
/// Issuer: MoH (МЗ)
/// </summary>
/// <remarks>
/// Format: AA.BB, where:<br/>
/// AA - Region (Област), 01-28<br/>
/// BB - Health region (Здравен район)<br/>
/// </remarks>
public class HealthRegion : RegionalIdentifier
{

    public string MunicipalityCode { get; private set; }

    public string MunicipalityName { get; private set; }

    public override string Name => "Health region";

    public override string NativeAbbreviation => "Здр. р-н";

    public override string NativeName => "Здравен район";

    public override bool IsPrivateData => false;

    // Parsing

    public static HealthRegion Parse(string value) => throw new NotImplementedException();

    public static bool TryParse(string value, out HealthRegion result) => throw new NotImplementedException();

    // Validation

    public new static bool Validate(string value) => throw new NotImplementedException();


}

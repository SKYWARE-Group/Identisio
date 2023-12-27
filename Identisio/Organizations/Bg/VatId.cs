﻿namespace Skyware.Identisio.Organizations.Bg;


/// <summary>
/// VAT code of Bulgarian legal entities (compatible with EU VAT numbers). <br/>
/// Issuer: NRA (Агенция по вземанията).
/// </summary>
public class VatId : IdentifierBase
{

    public override string Name => "VAT Identification Code";

    public override string NativeAbbreviation => "ИН по ДДС";

    public override string NativeName => "Идентификационен код по ЗДДС";

    public override bool IsPrivateData => false;

    //TODO: implement Validate ("BG" + Eik)

}

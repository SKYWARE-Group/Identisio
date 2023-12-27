﻿namespace Skyware.Identisio.Banking;


/// <summary>
/// International Bank Account Number
/// </summary>
public class Iban : IdentifierBase
{

    public override string Name => "International Bank Account Number";

    public override string NativeAbbreviation => "IBAN";

    public override string NativeName => "International Bank Account Number";

    public override bool IsPrivateData => false;

    //TODO: implement validation (Parse?)

}

using System;
using System.Collections.Generic;
using System.Text;

namespace Skyware.Identisio.Organizations.Bg
{

    /// <summary>
    /// RZI (РЗИ) codes are identifiers for health institutions in Bulgaria
    /// </summary>
    public class Rzi : IdentifierBase
    {
        public override string Name => "Region Health Inspection Code";

        public override string NativeAbbreviation => "РЗИ";

        public override string NativeName => "РЗИ код";

        public override bool IsPrivateData => false;

        //TODO: implement Parse


    }

}

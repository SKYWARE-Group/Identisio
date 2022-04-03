using System;
using System.Collections.Generic;
using System.Text;

namespace Identisio.Organizations.Bg
{
    public class NhifCode : IdentifierBase
    {

        public override string Name => "Nhif code";

        public override string NativeAbbreviation => "НЗОК номер";

        public override string NativeName => "НЗОК номер";

        public override bool IsPrivateData => false;

        //TODO: implement Parse


    }

}

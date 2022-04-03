using System;
using System.Collections.Generic;
using System.Text;

namespace Identisio.Personal.Bg
{
    public class Uin : IdentifierBase
    {

        public override string Name => "Unique idenifier of a docotr";

        public override string NativeAbbreviation => "УИН";

        public override string NativeName => "Уникален идентификцаионен номер на лекар";

        public override bool IsPrivateData => false;

        public static bool Validate(string value) => throw new NotImplementedException();

    }

}

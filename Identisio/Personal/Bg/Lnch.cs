using System;
using System.Collections.Generic;
using System.Text;

namespace Identisio.Personal.Bg
{
    public class Lnch : IdentifierBase, IParsable<Egn>
    {
        public override string Name => "Personal Identifier of a Foreigner";

        public override string NativeShortName => "ЛНЧ";

        public override string NativeName => "Личен номер на чужденец";

        public Egn Parse(string value)
        {
            throw new NotImplementedException();
        }

        public bool TryParse(string value, out Egn result)
        {
            throw new NotImplementedException();
        }
    }

}

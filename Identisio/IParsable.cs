using System;
using System.Collections.Generic;
using System.Text;

namespace Identisio
{

    public interface IParsable<T>
    {

        T Parse(string value);

        bool TryParse(string value, out T result);

    }

}

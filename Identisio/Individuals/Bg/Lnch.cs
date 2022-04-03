using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Identisio.Individuals.Bg
{
    public class Lnch : IdentifierBase
    {

        #region Fields

        private static readonly string _LnchRegex = @"^\d{10}$";
        private static readonly Regex _Regex = new Regex(_LnchRegex);

        private static readonly int[] _Weights = new int[] { 21, 19, 17, 13, 11, 9, 7, 3, 1 };

        #endregion

        #region Props

        public override string Name => "Personal Identifier of a Foreigner";

        public override string NativeAbbreviation => "ЛНЧ";

        public override string NativeName => "Личен номер на чужденец";

        public override bool IsPrivateData => true;

        #endregion

        #region Actions

        public new static bool Validate(string iputLnch)
        {
            if (string.IsNullOrWhiteSpace(iputLnch)) return false;
            if (!_Regex.IsMatch(iputLnch.Trim())) return false;
            if (!IsCheckSumValid(iputLnch)) return false;
            return true;
        }

        private static bool IsCheckSumValid(string value)
        {
            int sum = 0;
            for (int i = 0; i <= 8; i++) sum += int.Parse(value.Substring(i, 1)) * _Weights[i];
            sum = sum % 10 % 10;
            return sum == int.Parse(value.Substring(9, 1));
        }

        #endregion

    }

}

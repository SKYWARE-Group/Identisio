using System;
using System.Text.RegularExpressions;

namespace Identisio.Personal.Yu
{
    public class YuPid : IdentifierBase, IEncodesGender, IEncodesBirthdate
    {

        #region Fields

        private static readonly string _YuRegex = @"^\d{13}$";
        private static readonly Regex _Regex = new Regex(_YuRegex);

        #endregion

        #region Constructors

        private YuPid(string yuValue, bool isMaleValue, DateTime birthdateValue)
        {
            this.Value = yuValue;
            this.IsMale = isMaleValue;
            this.Birthdate = birthdateValue;
        }

        #endregion

        #region Props

        public override string Name => "Unique Master Citizen Number";

        public override string NativeAbbreviation => "ЕМБГ/JMBG/JMБГ/EMŠO";

        public override string NativeName => "Eдинствен матичен број на граѓаните";

        public bool IsMale { get; private set; }

        public DateTime Birthdate { get; private set; }

        public override bool IsPrivateData => true;


        #endregion

        #region Actions

        // Creation

        public static YuPid Parse(string yuValue)
        {
            // Validity check
            if (string.IsNullOrWhiteSpace(yuValue)) throw new ArgumentNullException(nameof(yuValue));
            if (!_Regex.IsMatch(yuValue)) throw new ArgumentOutOfRangeException(nameof(yuValue), $"Invalid {nameof(YuPid)} format");
            if (!IsCheckSumValid(yuValue)) throw new ArgumentOutOfRangeException(nameof(yuValue), $"Bad {nameof(YuPid)} checksum");

            // Values extraction
            var isMale = ParseIsMale(yuValue);
            var dateOfBirth = ParseDob(yuValue);

            return new YuPid(yuValue, isMale, dateOfBirth);
        }

        public static bool TryParse(string value, out YuPid result)
        {
            try
            {
                result = YuPid.Parse(value);
                return true;
            }
            catch (Exception)
            {
                result = null;
                return false;
            }
        }

        // Validity Checks

        public new static bool Validate(string yuValue)
        {
            if (string.IsNullOrWhiteSpace(yuValue)) return false;
            if (!_Regex.IsMatch(yuValue.Trim())) return false;
            if (!IsCheckSumValid(yuValue)) return false;
            return true;
        }

        private static bool IsCheckSumValid(string yuValue)
        {
            int v = 11 - (7 * (int.Parse(yuValue.Substring(0, 1)) + int.Parse(yuValue.Substring(6, 1))) + 6 * (int.Parse(yuValue.Substring(1, 1)) + int.Parse(yuValue.Substring(7, 1))) + 5 * (int.Parse(yuValue.Substring(2, 1)) + int.Parse(yuValue.Substring(8, 1))) + 4 * (int.Parse(yuValue.Substring(3, 1)) + int.Parse(yuValue.Substring(9, 1))) + 3 * (int.Parse(yuValue.Substring(4, 1)) + int.Parse(yuValue.Substring(10, 1))) + 2 * (int.Parse(yuValue.Substring(5, 1)) + int.Parse(yuValue.Substring(11, 1)))) % 11;
            if (v > 10) v = 0;
            return v == int.Parse(yuValue.Substring(12, 1));
        }

        // Data extraction
        
        private static DateTime ParseDob(string Value)
        {
            int Year = int.Parse(Value.Substring(4, 3));
            if (Year >= 800)
            {
                Year += 1000;
            }
            else
            {
                Year += 2000;
            }
            return new DateTime(Year, int.Parse(Value.Substring(2, 2)), int.Parse(Value.Substring(0, 2)));
        }

        private static bool ParseIsMale(string Value)
        {
            return int.Parse(Value.Substring(9, 3)) < 500;
        }

        #endregion

    }

}

using System;
using System.Text.RegularExpressions;

namespace BDSA2016.Lecture02.Lib
{
    public static class PostalCodeValidator
    {
        public static bool IsValid(string postalCode)
        {
            var pattern = @"^\d{4}$";

            return Regex.IsMatch(postalCode, pattern);
        }

        public static bool TryParse(string postalCodeAndLocality, 
            out string postalCode, 
            out string locality)
        {
            var pattern = @"^(?<postalCode>\d{4})\s+(?<locality>.+)$";

            var regex = new Regex(pattern);

            var match = regex.Match(postalCodeAndLocality);

            if (!match.Success)
            {
                postalCode = default(string);
                locality = null;
                return false;
            }

            postalCode = match.Groups["postalCode"].Value;
            locality = match.Groups["locality"].Value;

            return true;
        }
    }
}

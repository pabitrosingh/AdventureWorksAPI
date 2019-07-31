using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AdventureWorksAPI.Helpers
{
    public class Validation : IValidation
    {
        public bool IsXSS(string ValueToCheck)
        {
           return ValueToCheck.Contains("<>![]{}/'\"") ? true : false;
        }

        public bool IsValidYear(string year)
        {
            return Regex.IsMatch(year,"^[0-9]{4}$");
        }

        public bool IsValidLocationID(string locationID)
        {
            return Regex.IsMatch(locationID,"^[0-9]{2}$");
        }

        public bool IsValidName(string Name)
        {
            return Regex.IsMatch(Name,"^[A-Za-z ]+$");
        }

        public bool IsValidNumber(string Value)
        {
            return Regex.IsMatch(Value,"^[0-9]+$");
        }
    }
}

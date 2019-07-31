using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorksAPI.Helpers
{
    public interface IValidation
    {
        bool IsXSS(string ValueToCheck);
        bool IsValidYear(string year);
        bool IsValidLocationID(string locationID);
        bool IsValidName(string workOrderType);
        bool IsValidNumber(string Value);
    }
}

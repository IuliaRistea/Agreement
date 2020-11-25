using Agreement.Helpers;
using System.Collections.Generic;

namespace Agreement.Interfaces
{
    public interface IErrorService
    {
        public bool AddError(string uniqueId, ResultType resultType, List<string> errors, string requestType);
    }
}

using Agreement.Helpers;
using Agreement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agreement.Services
{
    public interface IErrorService
    {
        public bool AddError(string uniqueId, Result<AgreementModel> result, RequestType requestType);
    }
}

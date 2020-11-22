using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VMD.RESTApiResponseWrapper.Core.Wrappers;

namespace Agreement.Services
{
    public interface IBusinessService
    {
        public string GetAgreements();

        public APIResponse GetAgreementModel(string uniqueId);
    }
}

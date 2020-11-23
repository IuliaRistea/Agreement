using Agreement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Agreement.Services
{
    public interface IBusinessService
    {
        public ICollection<AgreementModel> GetAgreements();
        public AgreementModel GetAgreementModel(string uniqueId);

        public HttpResponseMessage PostAgreementModel(string agreementString);
    }
}

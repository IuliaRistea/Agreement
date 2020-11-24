using Agreement.Helpers;
using Agreement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Agreement.Interfaces
{
    public interface IBusinessService
    {
        public ICollection<AgreementModel> GetAgreements();
        public Result<AgreementModel> GetAgreementModel(string uniqueId);

        public Result<AgreementModel> PostAgreementModel(AgreementModel agreementModel);

        public bool DeleteAgreementModel(string uniqueId);
        public AgreementModel PutAgreementModel(AgreementModel agreementModel);
    }
}

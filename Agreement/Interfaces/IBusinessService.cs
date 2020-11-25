using Agreement.Helpers;
using Agreement.Models;
using System.Collections.Generic;

namespace Agreement.Interfaces
{
    public interface IBusinessService
    {
        public ICollection<AgreementModel> GetAgreements();
        public Result<AgreementModel> GetAgreementModel(string uniqueId);

        public Result<AgreementModel> PostAgreementModel(AgreementModel agreementModel);

        public Result<AgreementModel> DeleteAgreementModel(string uniqueId);
        public Result<AgreementModel> PutAgreementModel(AgreementModel agreementModel);
    }
}

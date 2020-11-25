using Agreement.Models;
using System.Collections.Generic;

namespace Agreement.Interfaces
{
    public interface IAgreementRepository
    {
        public ICollection<AgreementModel> GetAgreements();
        AgreementModel GetAgreement(string uniqueId);
        bool AgreementExists(string uniqueId);
        bool CreateAgreement(AgreementModel agreement);
        bool UpdateAgreement(AgreementModel agreement);
        bool DeleteAgreement(string uniqueId);
        bool Save();
    }
}

using Agreement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agreement.Services
{
    public interface IAgreementRepository
    {
        public ICollection<AgreementModel> GetAgreements();
        AgreementModel GetAgreement(string uniqueId);
        bool AgreementExists(string uniqueId);
        bool CreateAgreement(AgreementModel agreement);
        bool UpdateAgreement(AgreementModel agreement);
        bool DeleteAgreement(AgreementModel agreement);
        bool Save();
    }
}

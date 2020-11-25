using Agreement.Helpers;
using Agreement.Models;

namespace Agreement.Interfaces
{
    public interface IValidatorService
    {
        public Status ValidateAgreement(AgreementModel agreementModel);
    }
}

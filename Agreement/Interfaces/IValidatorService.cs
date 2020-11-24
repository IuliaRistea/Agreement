using Agreement.Helpers;
using Agreement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agreement.Interfaces
{
    public interface IValidatorService
    {
        public Status ValidateAgreement(AgreementModel agreementModel);
    }
}

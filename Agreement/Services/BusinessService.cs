using Agreement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Agreement.Services
{
    public class BusinessService : IBusinessService
    {
        private IAgreementRepository _agreementRepository;

        public BusinessService(IAgreementRepository agreementRepository)
        {
            _agreementRepository = agreementRepository;
        }

        public string GetAgreements()
        {
           return JsonSerializer.Serialize(_agreementRepository.GetAgreements());
           ///return ActionResult(_agreementRepository.GetAgreements());
        }
    }
}

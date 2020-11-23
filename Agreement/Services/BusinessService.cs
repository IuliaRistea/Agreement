using Agreement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Agreement.Services
{
    public class BusinessService : IBusinessService
    {
        private IAgreementRepository _agreementRepository;

        public BusinessService(IAgreementRepository agreementRepository)
        {
            _agreementRepository = agreementRepository;
        }

        public ICollection<AgreementModel> GetAgreements()
        {
            return _agreementRepository.GetAgreements();
        }

        public AgreementModel GetAgreementModel(string uniqueId)
        {
            var agreementModel = _agreementRepository.GetAgreement(uniqueId);
            return agreementModel;
        }


        public HttpResponseMessage PostAgreementModel(string agreementString)
        {

            var options = new JsonSerializerOptions()
            {
                IncludeFields = true,
            };
            AgreementModel agreementModel = JsonSerializer.Deserialize<AgreementModel>(agreementString, options);

            Console.WriteLine(agreementModel.CNPCUI);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

    }
}

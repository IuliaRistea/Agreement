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


        public AgreementModel PostAgreementModel(AgreementModel agreementModel)
        {
            bool success = _agreementRepository.CreateAgreement(agreementModel);
            if (!success) return null;

            return agreementModel;
        }

        public bool DeleteAgreementModel(string uniqueId)
        {
            if (_agreementRepository.AgreementExists(uniqueId) == false)
                return false;
            bool success = _agreementRepository.DeleteAgreement(uniqueId);
            return success;
        }

        public AgreementModel PutAgreementModel(AgreementModel agreementModel)
        {

            if (_agreementRepository.AgreementExists(agreementModel.CNPCUI) == false)
                return null;
            bool success = _agreementRepository.UpdateAgreement(agreementModel);

            if (!success) return null;

            return agreementModel;

        }
    }
}

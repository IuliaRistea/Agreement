using Agreement.Helpers;
using Agreement.Models;
using System;
using System.Collections.Generic;

namespace Agreement.Services
{
    public class BusinessService : IBusinessService
    {
        private IAgreementRepository _agreementRepository;
        private IErrorService _errorService;

        public BusinessService(IAgreementRepository agreementRepository, IErrorService errorService)
        {
            _agreementRepository = agreementRepository;
            _errorService = errorService;
        }

        public ICollection<AgreementModel> GetAgreements()
        {

            return _agreementRepository.GetAgreements();
        }

        public Result<AgreementModel> GetAgreementModel(string uniqueId)
        {
            var agreementModel = _agreementRepository.GetAgreement(uniqueId);
            if (agreementModel == null)
            {
                Result<AgreementModel> result = new NotFoundResult<AgreementModel>("Agreement not found!");
                if (_errorService.AddError(uniqueId, result, RequestType.Get) == false)
                    Console.WriteLine("Errors service failed");
                return result;
            }
            return new SuccessResult<AgreementModel>(agreementModel);
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

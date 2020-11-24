using Agreement.Helpers;
using Agreement.Interfaces;
using Agreement.Models;
using System;
using System.Collections.Generic;

namespace Agreement.Services
{
    public class BusinessService : IBusinessService
    {
        private IAgreementRepository _agreementRepository;
        private IErrorService _errorService;
        private IValidatorService _validatorService;

        public BusinessService(IAgreementRepository agreementRepository, IErrorService errorService, IValidatorService validatorService)
        {
            _agreementRepository = agreementRepository;
            _errorService = errorService;
            _validatorService = validatorService;
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
                if (_errorService.AddError(uniqueId, result, "Get") == false)
                    Console.WriteLine("Error service failed");
                return result;
            }
            return new SuccessResult<AgreementModel>(agreementModel);
        }


        public Result<AgreementModel> PostAgreementModel(AgreementModel agreementModel)
        {
            var validateResult = _validatorService.ValidateAgreement(agreementModel);

            if (validateResult.ResultType != ResultType.Ok)
            {
                if (_errorService.AddError((agreementModel.CNPCUI != null ? agreementModel.CNPCUI : "invalid"), validateResult, "Post") == false)
                    Console.WriteLine("Error service failed");
                return validateResult;
            }

            try { 
                bool success = _agreementRepository.CreateAgreement(agreementModel);
                if (!success) 
                {
                    Result<AgreementModel> result = new BadRequestResult<AgreementModel>("Bad request: Agreement already exists!");
                    if (_errorService.AddError(agreementModel.CNPCUI, result, "Post") == false)
                        Console.WriteLine("Error service failed");
                    return result;
                }
            }catch(Exception e) {

                Result<AgreementModel> result = new BadRequestResult<AgreementModel>("Bad request: Agreement create failed!");
                if (_errorService.AddError(agreementModel.CNPCUI, result, "Post") == false)
                    Console.WriteLine("Error service failed");
                return result;
            }
            return new SuccessResult<AgreementModel>(agreementModel);

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

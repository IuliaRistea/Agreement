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
            try {
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
            catch (Exception e)
            {
                return new UnexpectedResult<AgreementModel>();
            }
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
                if (_agreementRepository.AgreementExists(agreementModel.CNPCUI))
                {
                    Result<AgreementModel> result = new NotFoundResult<AgreementModel>("Agreement already exist!");
                    if (_errorService.AddError(agreementModel.CNPCUI, result, "Post") == false)
                        Console.WriteLine("Error service failed");
                    return result;
                }

                bool success = _agreementRepository.CreateAgreement(agreementModel);

                if (!success)
                {
                    Result<AgreementModel> result = new BadRequestResult<AgreementModel>("Bad request: Agreement create failed!");
                    if (_errorService.AddError(agreementModel.CNPCUI, result, "Post") == false)
                        Console.WriteLine("Error service failed");
                    return result;
                }
            } catch {

                Result<AgreementModel> result = new UnexpectedResult<AgreementModel>();
                if (_errorService.AddError(agreementModel.CNPCUI, result, "Post") == false)
                    Console.WriteLine("Error service failed");
                return result;
            }
            return new SuccessResult<AgreementModel>(agreementModel);

        }

        public Result<AgreementModel> DeleteAgreementModel(string uniqueId)
        {
            if (_agreementRepository.AgreementExists(uniqueId) == false )
            {
                Result<AgreementModel> result = new NotFoundResult<AgreementModel>("Agreement not found!");
                if (_errorService.AddError(uniqueId, result, "Delete") == false)
                    Console.WriteLine("Error service failed");
                return result;
            }
            try
            {
                bool success = _agreementRepository.DeleteAgreement(uniqueId);

                if (!success)
                {
                    Result<AgreementModel> result = new BadRequestResult<AgreementModel>("Bad request: Agreement update failed!");
                    if (_errorService.AddError(uniqueId, result, "Delete") == false)
                        Console.WriteLine("Error service failed");
                    return result;
                }
            }
            catch
            {

                Result<AgreementModel> result = new UnexpectedResult<AgreementModel>();
                if (_errorService.AddError(uniqueId, result, "Put") == false)
                    Console.WriteLine("Error service failed");
                return result;
            }


            return new SuccessResult<AgreementModel>();
        }

        public Result<AgreementModel> PutAgreementModel(AgreementModel agreementModel)
        {
            var validateResult = _validatorService.ValidateAgreement(agreementModel);

            if (validateResult.ResultType != ResultType.Ok)
            {
                if (_errorService.AddError((agreementModel.CNPCUI != null ? agreementModel.CNPCUI : "invalid"), validateResult, "Put") == false)
                    Console.WriteLine("Error service failed");
                return validateResult;
            }

            try
            {
                if (!_agreementRepository.AgreementExists(agreementModel.CNPCUI))
                {
                    Result<AgreementModel> result = new NotFoundResult<AgreementModel>("Agreement not found!");
                    if (_errorService.AddError(agreementModel.CNPCUI, result, "Put") == false)
                        Console.WriteLine("Error service failed");
                    return result;
                }
                bool success = _agreementRepository.UpdateAgreement(agreementModel);
               
                if (!success)
                {
                    Result<AgreementModel> result = new BadRequestResult<AgreementModel>("Bad request: Agreement update failed!");
                    if (_errorService.AddError(agreementModel.CNPCUI, result, "Put") == false)
                        Console.WriteLine("Error service failed");
                    return result;
                }
            }
            catch 
            {

                Result<AgreementModel> result = new UnexpectedResult<AgreementModel>();
                if (_errorService.AddError(agreementModel.CNPCUI, result, "Put") == false)
                    Console.WriteLine("Error service failed");
                return result;
            }
            return new SuccessResult<AgreementModel>(agreementModel);

        }
    }
}

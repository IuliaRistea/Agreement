using Agreement.Models;
using Agreement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agreement.Helpers
{
    public class ErrorService : IErrorService
    {
        private IErrorRepository _errorRepository;
        public ErrorService(IErrorRepository errorRepository)
        {
            _errorRepository = errorRepository;
        }

        public bool AddError(string uniqueId, Result<AgreementModel> result, RequestType requestType)
        {
            ErrorModel errorModel = new ErrorModel()
            {
                UniqueId = uniqueId,
                RequestType = requestType,
                ResultType = result.ResultType,
                ErrorMessage = result.Errors.ToString(),
            };

            return _errorRepository.CreateError(errorModel);


        }
    }
}

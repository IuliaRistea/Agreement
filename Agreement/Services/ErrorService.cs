using Agreement.Models;
using Agreement.Interfaces;
using Agreement.Helpers;
using System.Collections.Generic;

namespace Agreement.Services
{
    public class ErrorService : IErrorService
    {
        private IErrorRepository _errorRepository;
        public ErrorService(IErrorRepository errorRepository)
        {
            _errorRepository = errorRepository;
        }

        public bool AddError(string uniqueId, ResultType resultType, List<string> errors, string requestType)
        {
            
            ErrorModel errorModel = new ErrorModel()
            {
                UniqueId = uniqueId,
                RequestType = requestType,
                ResultType = resultType.ToString("G"),
                ErrorMessage = string.Join(" | ", errors)
            };

            return _errorRepository.CreateError(errorModel);


        }
    }
}

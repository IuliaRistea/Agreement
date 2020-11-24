using Agreement.Models;
using Agreement.Interfaces;
using Agreement.Helpers;

namespace Agreement.Services
{
    public class ErrorService : IErrorService
    {
        private IErrorRepository _errorRepository;
        public ErrorService(IErrorRepository errorRepository)
        {
            _errorRepository = errorRepository;
        }

        public bool AddError(string uniqueId, Result<AgreementModel> result, string requestType)
        {
            
            ErrorModel errorModel = new ErrorModel()
            {
                UniqueId = uniqueId,
                RequestType = requestType,
                ResultType = result.ResultType.ToString("G"),
                ErrorMessage = result.Error
            };

            return _errorRepository.CreateError(errorModel);


        }
    }
}

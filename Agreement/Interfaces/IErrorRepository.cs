using Agreement.Models;
using System.Collections.Generic;

namespace Agreement.Interfaces
{
    public interface IErrorRepository
    {
        public ICollection<ErrorModel> GetErrors();
        bool CreateError(ErrorModel error);
        bool Save();
    }
}

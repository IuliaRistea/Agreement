using Agreement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agreement.Services
{
    public interface IErrorRepository
    {
        public ICollection<ErrorModel> GetErrors();
        bool CreateError(ErrorModel error);
        bool Save();
    }
}

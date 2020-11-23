using Agreement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agreement.Services
{
    public class ErrorRepository : IErrorRepository
    {
        private DatabaseContext _context;

        public ErrorRepository(DatabaseContext context)
        {
            _context = context;
        }

        public bool CreateError(ErrorModel error)
        {
            _context.Add(error);
            return Save();
        }

        public ICollection<ErrorModel> GetErrors()
        {
            return _context.Errors.ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved >= 0 ? true : false;
        }
    }
}

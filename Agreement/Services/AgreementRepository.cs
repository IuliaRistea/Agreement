using Agreement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agreement.Services
{
    public class AgreementRepository : IAgreementRepository
    {
        private AgreementDbContext _context;

        public AgreementRepository(AgreementDbContext context)
        {
            _context = context;
        }

        public bool AgreementExists(string uniqueId)
        {
            return _context.Agreements.Any(agreement => agreement.CNPCUI == uniqueId);
        }

        public bool CreateAgreement(AgreementModel agreement)
        {
            _context.Add(agreement);
            return Save();
        }

        public bool DeleteAgreement(AgreementModel agreement)
        {
            _context.Remove(agreement);
            return Save();
        }

        public AgreementModel GetAgreement(string uniqueId)
        {
            return _context.Agreements.Where(agreement => agreement.CNPCUI == uniqueId).FirstOrDefault();
        }

        public ICollection<AgreementModel> GetAgreements()
        {
            return _context.Agreements.OrderBy(agreement => agreement.CNPCUI ).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved >= 0 ? true : false;
        }

        public bool UpdateAgreement(AgreementModel agreement)
        {
            _context.Update(agreement);
            return Save();
        }
    }
}

using Agreement.Interfaces;
using Agreement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Agreement.Services
{
    public class AgreementRepository : IAgreementRepository
    {
        private DatabaseContext _context;

        public AgreementRepository(DatabaseContext context)
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

        public bool DeleteAgreement(string uniqueId)
        {
            if (AgreementExists(uniqueId) == false)
                return false;

            _context.Remove(GetAgreement(uniqueId));
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
            _context.Entry(GetAgreement(agreement.CNPCUI)).State = EntityState.Detached;
            _context.Entry(agreement).State = EntityState.Modified;
            _context.Update(agreement);
            return Save();
        }
    }
}

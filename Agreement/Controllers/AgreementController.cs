using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Agreement.Models;
using Agreement.Services;

namespace Agreement.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AgreementController : ControllerBase
    {
      

        private readonly DatabaseContext _context;

        public AgreementController(DatabaseContext context)
        {
            _context = context;
        }
        // GET: api/Agreement
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgreementModel>>> GetAgreements()
        {
            return await _context.Agreements.ToListAsync();
        }

        // GET: api/Agreement/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AgreementModel>> GetAgreementModel(string id)
        {
            var agreementModel = await _context.Agreements.FindAsync(id);

            if (agreementModel == null)
            {
                return NotFound();
            }

            return agreementModel;
        }

        // PUT: api/Agreement/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgreementModel(string id, AgreementModel agreementModel)
        {
            if (id != agreementModel.CNPCUI)
            {
                return BadRequest();
            }

            _context.Entry(agreementModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgreementModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Agreement
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AgreementModel>> PostAgreementModel(AgreementModel agreementModel)
        {
            _context.Agreements.Add(agreementModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AgreementModelExists(agreementModel.CNPCUI))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAgreementModel", new { id = agreementModel.CNPCUI }, agreementModel);
        }

        // DELETE: api/Agreement/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AgreementModel>> DeleteAgreementModel(string id)
        {
            var agreementModel = await _context.Agreements.FindAsync(id);
            if (agreementModel == null)
            {
                return NotFound();
            }

            _context.Agreements.Remove(agreementModel);
            await _context.SaveChangesAsync();

            return agreementModel;
        }

        private bool AgreementModelExists(string id)
        {
            return _context.Agreements.Any(e => e.CNPCUI == id);
        }
    }
}

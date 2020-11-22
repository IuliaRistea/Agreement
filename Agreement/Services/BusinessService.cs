using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text.Json;
using VMD.RESTApiResponseWrapper.Core.Wrappers;

namespace Agreement.Services
{
    public class BusinessService : IBusinessService
    {
        private IAgreementRepository _agreementRepository;

        public BusinessService(IAgreementRepository agreementRepository)
        {
            _agreementRepository = agreementRepository;
        }

        public string GetAgreements()
        {
           return JsonSerializer.Serialize(_agreementRepository.GetAgreements());
           ///return ActionResult(_agreementRepository.GetAgreements());
        }

        public APIResponse GetAgreementModel(string uniqueId)
        {
            var agreementModel = _agreementRepository.GetAgreement(uniqueId);
            if (agreementModel == null)
            {
                return new APIResponse((int)HttpStatusCode.NotFound);
            }
            return new APIResponse(
                (int)HttpStatusCode.OK,
                message: "GetAgreementModel succeeded",
                result: JsonSerializer.Serialize(agreementModel));
        }
        /*
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
                }*/
        /*
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
                }*/
        /*
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
                }*/
        /*
                private bool AgreementModelExists(string id)
                {
                    return _context.Agreements.Any(e => e.CNPCUI == id);
                }*/
    }
}

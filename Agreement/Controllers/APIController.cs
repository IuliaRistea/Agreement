using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Agreement.Helpers;
using Agreement.Models;
using Agreement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Agreement.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private IBusinessService _businessService;

        public APIController(IBusinessService businessService)
        {
            _businessService = businessService;
        }

        [HttpGet]
        public ICollection<AgreementModel> Get()
        {
            return _businessService.GetAgreements();
        }

        [HttpGet("{uniqueId}")]
        [ProducesResponseType(typeof(AgreementModel), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 400)]
        [ProducesResponseType(500)]
        public ActionResult<AgreementModel> Get(string uniqueId)
        {

            Result<AgreementModel> result = _businessService.GetAgreementModel(uniqueId);
            if (result.ResultType == ResultType.NotFound) return NotFound(result.Errors);
            return result.Data;
        }

        /// <summary>
        /// Creates a TodoItem.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///          "cnpcui": "CNP234",
        ///          "nume": "Nume",
        ///          "prenume": "Prenume",
        ///          "denumireCompanie": null,
        ///          "judet": "B",
        ///          "nrTelefon": "5551234",
        ///          "email": "test@gmail.com",
        ///          "acordPrelucrareDate": true,
        ///          "comunicareMarketing": true,
        ///          "comunicareEmail": true,
        ///          "comunicareSMS": true,
        ///          "comunicarePosta": true
        ///      }
        ///
        /// </remarks>
        /// <param name="item"></param>
        /// <returns>A newly created TodoItem</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>            
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<AgreementModel> Post(AgreementModel agreementModel)
        {
            
            return _businessService.PostAgreementModel(agreementModel); 
        }


        [HttpPut]
        public ActionResult<AgreementModel> Put(AgreementModel agreementModel)
        {

            return _businessService.PutAgreementModel(agreementModel);
        }

        [HttpDelete("{uniqueId}")]
        public bool Delete(string uniqueId)
        {
            return _businessService.DeleteAgreementModel(uniqueId);
        }
    }
}

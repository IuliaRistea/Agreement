using System;
using System.Collections.Generic;
using Agreement.Helpers;
using Agreement.Models;
using Agreement.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Agreement.Controllers
{
    [Produces("application/json")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private IBusinessService _businessService;

        public APIController(IBusinessService businessService)
        {
            _businessService = businessService;
        }

        [ProducesResponseType(200)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
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
            switch (result.ResultType)
            {
                case ResultType.Unexpected:
                    return StatusCode(500,result.Errors);
                case ResultType.NotFound:
                    return NotFound(result.Errors);
                default: 
                    break;
            }
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
            Result<AgreementModel> result = _businessService.PostAgreementModel(agreementModel);
            switch (result.ResultType)
            {
                case ResultType.Unexpected:
                    return StatusCode(500, result.Errors);
                case ResultType.BadRequest:
                    return BadRequest(result.Errors);
                default:
                    break;
            }
            return result.Data;
           
        }


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<AgreementModel> Put(AgreementModel agreementModel)
        {

            Result<AgreementModel> result = _businessService.PutAgreementModel(agreementModel);
            switch (result.ResultType)
            {
                case ResultType.Unexpected:
                    return StatusCode(500, result.Errors);
                case ResultType.BadRequest:
                    return BadRequest(result.Errors);
                case ResultType.NotFound:
                    return NotFound(result.Errors);
                default:
                    break;
            }
            return result.Data;
        }

        [HttpDelete("{uniqueId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(string uniqueId)
        {
            Result<AgreementModel> result = _businessService.DeleteAgreementModel(uniqueId);
            switch (result.ResultType)
            {
                case ResultType.Unexpected:
                    return StatusCode(500, result.Errors);
                case ResultType.BadRequest:
                    return BadRequest(result.Errors);
                case ResultType.NotFound:
                    return NotFound(result.Errors);
                default:
                    break;
            }
            return Ok();
        }
    }
}

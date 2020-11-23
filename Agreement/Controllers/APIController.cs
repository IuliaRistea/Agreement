using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Agreement.Models;
using Agreement.Services;
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

           return _businessService.GetAgreementModel(uniqueId); 
        }

        [HttpPost]
        public string Post([FromBody] string value)
        {
            Console.WriteLine(value);
           // _businessService.PostAgreementModel(value);
            return "Hello World!";
        }


        [HttpPut("{id}")]
        public string Put(int id, [FromBody] string value)
        {
            return "Hello Galaxy!";
        }


        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return "Hello Universe!";
        }
    }
}

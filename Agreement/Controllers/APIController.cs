using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Agreement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VMD.RESTApiResponseWrapper.Core.Wrappers;

namespace Agreement.Controllers
{
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
        public string Get()
        {
            return _businessService.GetAgreements();
            //return "hello";
        }

        [HttpGet("{uniqueId}")]
        public ActionResult<string> Get(string uniqueId)
        {
            APIResponse response = _businessService.GetAgreementModel(uniqueId); 
            if (response.StatusCode == (int)HttpStatusCode.NotFound)
            {
                return NotFound();
            }
            return Ok((string)response.Result);
        }

        [HttpPost]
        public string Post([FromBody] string value)
        {
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

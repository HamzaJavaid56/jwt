using BusinessOperations.Services;
using Dapper;
using DataAccess.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingAPI.Controllers
{
 
    public class DapperController : ControllerBase
    {
        private readonly IDapperService _Dservice;
        private readonly string connString = Startup.StaticConfig.GetConnectionString("DbContextBilling");

        public DapperController(IDapperService Dservice )
        {      
            _Dservice = Dservice;
        }

        [HttpGet,Authorize]
        [Route("api/Dapper/GetListWithSp")]
        public IActionResult GetListWithSp()
        {
            var response = _Dservice.GetListWithSp(connString);
            return Ok(response);
        }

        [HttpGet]
        [Route("api/Dapper/GetListWithParaSp")]
        public IActionResult GetListWithParaSp(customer cus)
        {
            var response = _Dservice.GetListWithParaSp(cus);         
            return Ok(response); 

        }

        [HttpPost]
        [Route("api/Dapper/GetSingleObjectWithStoreProcedure")]
        public IActionResult GetSingleObjectWithStoreProcedure(customer cus)
        {
            var response = _Dservice.GetSingleObjectWithStoreProcedure(cus);
            return Ok(response);

        }

    }
}

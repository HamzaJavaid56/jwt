
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DapperController : ControllerBase
    {
        public DapperController()
        {
           

        }

        [HttpGet]
        [Route("api/Dapper/GetListWithSp")]
        public IActionResult GetListWithSp()
        {
            var proc = "SP_Get_Customers";
            var cus="";
            //var cus = SPRepoistory<customer>.GetListWithSp(proc);
            return Ok(cus);          
        }
    }
}

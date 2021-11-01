using DataAccess.Model;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingAPI.Controllers
{
  
    public class EFController : ControllerBase
    {
        private readonly IRepositoryEF<customer> _rep;

        public EFController(IRepositoryEF<customer> rep)
        {
            _rep = rep;       
        }

        [HttpGet]
        [Route("api/EF/GetAll")]

        public IActionResult GetAll()
        {
           
            return Ok(_rep.GetModel());
        }

        [HttpGet]
        [Route("api/EF/GetById")]
        public IActionResult GetById(int id)
        {
       
            return Ok(_rep.GetModelById(id));
        }
        [HttpPost]
        [Route("api/EF/AddModel")]
        public IActionResult AddModel(customer obj)
        {

            return Ok( _rep.AddModel(obj));
        }

        [HttpPost]
        [Route("api/EF/UpdateModel")]
        public IActionResult UpdateModel(customer obj)
        {

            return Ok(_rep.UpdateModel(obj));
        }
        [HttpGet]
        [Route("api/EF/DeleteModel")]
        public IActionResult DeleteModel(int id)
        {

            return Ok(_rep.DeleteModel(id));
        }

    }
}

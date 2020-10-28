using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIDebitoner.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace APIDebitoner.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DebitonerController : ControllerBase
    {
        DebitonerBLL debitonerBLL = new DebitonerBLL();
        private readonly ILogger<DebitonerController> _logger;

        public DebitonerController(ILogger<DebitonerController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<Debitoner> Get()
        {
          
            
            return Ok(debitonerBLL.GetAllDebitoner());
        }
        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                return Ok(debitonerBLL.GetDebitionerByID(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}

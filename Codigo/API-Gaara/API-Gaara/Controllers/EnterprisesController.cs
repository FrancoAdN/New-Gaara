using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_Gaara.Services;
using API_Gaara.Models;


namespace API_Gaara.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnterprisesController : ControllerBase
    {
        private readonly EnterpriseService _enterpriseService;

        public EnterprisesController(EnterpriseService enterpriseService)
        {
            _enterpriseService = enterpriseService;
        }

        [HttpGet]
        public ActionResult<List<Enterprise>> Get() =>
            _enterpriseService.Get();

        [HttpGet("{id:length(24)}", Name = "GetEnterprise")]
        public ActionResult<Enterprise> Get(string id)
        {
            var enterprise = _enterpriseService.Get(id);

            if (enterprise == null)
            {
                return NotFound();
            }

            return enterprise;
        }

        [HttpPost]
        public ActionResult<Enterprise> Create(Enterprise ent)
        {
            _enterpriseService.Create(ent);

            return CreatedAtRoute("GetEnterprise", new { id = ent.id.ToString() }, ent);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Enterprise entIn)
        {
            var ent = _enterpriseService.Get(id);

            if (ent == null)
            {
                return NotFound();
            }

            _enterpriseService.Update(id, entIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var ent = _enterpriseService.Get(id);

            if (ent == null)
            {
                return NotFound();
            }

            _enterpriseService.Remove(ent.id);

            return NoContent();
        }
    }
}
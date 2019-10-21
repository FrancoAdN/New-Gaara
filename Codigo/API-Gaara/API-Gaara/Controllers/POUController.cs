using API_Gaara.Models;
using API_Gaara.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API_Gaara.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class POUController : ControllerBase
    {
        private readonly EnterpriseService _enterprise;

        public POUController(EnterpriseService enterprise)
        {
            _enterprise = enterprise;
        }

        [HttpGet]
        public ActionResult Get() =>
            Ok();
        [HttpGet("{id:length(24)}", Name = "GetPOU")]
        public ActionResult<List<ProjectOfUser>> Get(string id)
        {
            var ent = _enterprise.GetProjectOfUsers(id);
            if (ent == null)
                return NotFound();
            return ent;
        }
    }
}
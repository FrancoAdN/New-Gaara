using API_Gaara.Models;
using API_Gaara.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API_Gaara.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GOUController : ControllerBase
    {
        private readonly EnterpriseService _enterprise;

        public GOUController(EnterpriseService enterprise)
        {
            _enterprise = enterprise;
        }

        [HttpGet]
        public ActionResult Get() =>
            Ok();
        [HttpGet("{id:length(24)}", Name = "GetGOF")]
        public ActionResult<List<GroupsOfUser>> Get(string id)
        
        {
            var ent = _enterprise.GetGroups(id);
            if (ent == null)
                return NotFound();
            return ent;
        }
    }
}
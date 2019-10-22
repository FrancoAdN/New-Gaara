using API_Gaara.Models;
using API_Gaara.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;


namespace API_Gaara.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly EnterpriseService _entService;

        public ProjectController(EnterpriseService entService)
        {
            _entService = entService;
        }

        [HttpGet]
        public ActionResult<String> Get(string ent, int id)
        {
            Project proj = _entService.GetProject(ent, id);
            Console.WriteLine(proj);
            if (proj == null)
                return NotFound();

            return proj.desc;
        }
    }
}
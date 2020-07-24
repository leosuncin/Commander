using System.Collections.Generic;
using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepository _repo = new MockCommanderRepository();

        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            return Ok(_repo.GetAllCommands());
        }

        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandById(int id)
        {
            var command = _repo.GetCommandById(id);

            if (command == null) return NotFound();

            return Ok(command);
        }
    }
}
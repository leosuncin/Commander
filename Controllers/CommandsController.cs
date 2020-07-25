using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.DTOs;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepository _repo;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDTO>> GetAllCommands()
        {
            var commands = _repo.GetAllCommands();

            return Ok(_mapper.Map<IEnumerable<CommandReadDTO>>(commands));
        }

        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDTO> GetCommandById(int id)
        {
            var command = _repo.GetCommandById(id);

            if (command == null) return NotFound();

            return Ok(_mapper.Map<CommandReadDTO>(command));
        }

        [HttpPost]
        public ActionResult<CommandReadDTO> CreateCommand(CommandCreateDTO newCommand)
        {
            var command = _mapper.Map<Command>(newCommand);
            _repo.CreateCommand(command);
            _repo.SaveChanges();

            return CreatedAtRoute(nameof(GetCommandById), new { Id = command.Id }, _mapper.Map<CommandReadDTO>(command));
        }

        [HttpPut("{id}")]
        public ActionResult<CommandReadDTO> UpdateCommand(int id, CommandUpdateDTO updateCommand)
        {
            var command = _repo.GetCommandById(id);

            if (command == null) return NotFound();

            _mapper.Map(updateCommand, command);
            _repo.UpdateCommand(command);
            _repo.SaveChanges();

            return Ok(_mapper.Map<CommandReadDTO>(command));
        }
    }
}
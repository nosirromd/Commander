using System.Collections.Generic;
using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;

        //MockCommanderRepo _repository = new MockCommanderRepo();
        public CommandsController(ICommanderRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var commandsSet = _repository.GetAllCommands();
            return Ok(commandsSet);
        }

        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandById(int id)
        {
            var commandItem =  _repository.GetCommandById(id);
            return Ok(commandItem);
        }
    }
    
}
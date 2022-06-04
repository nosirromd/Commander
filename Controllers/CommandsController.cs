using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        //MockCommanderRepo _repository = new MockCommanderRepo();
        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandsSet = _repository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>> (commandsSet));
        }

        [HttpGet("{id}", Name="GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var commandItem =  _repository.GetCommandById(id);

            if (commandItem != null)
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            else
                return NotFound();
        }

        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var newCommand = _mapper.Map<Command>(commandCreateDto);
            _repository.CreateCommand(newCommand);
            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(newCommand);
            //return Ok(commandReadDto);
            return CreatedAtRoute("GetCommandById", new { id = commandReadDto.Id}, commandReadDto );
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var commandFromRepo = _repository.GetCommandById(id);
            if (commandFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(commandUpdateDto, commandFromRepo); //overwites db obj with request obj
            _repository.UpdateCommand(commandFromRepo); //this is redundant for SQL server DB
            _repository.SaveChanges();
            return NoContent();
        }
    }
    
}
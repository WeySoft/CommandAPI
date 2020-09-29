using Comand.API.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Comand.API.Data;
using AutoMapper;
using Comand.API.Dtos;
using Microsoft.AspNetCore.JsonPatch;

namespace Comand.API.Controllers
{
    //api/commands
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET api/commands
        [HttpGet]
        public ActionResult <IEnumerable<CommandRead>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();

            return Ok(_mapper.Map<IEnumerable<CommandRead>>(commandItems));
        }

        // GET api/commands/{id}
        [HttpGet("{id}", Name="GetCommandById")]
        public ActionResult <CommandRead>  GetCommandById(int Id)
        {
            var commandItem = _repository.GetCommandById(Id);
            if(commandItem != null){
            return Ok(_mapper.Map<CommandRead>(commandItem));
            }
            return NotFound();
        }

        // POSt api/commands/
        [HttpPost]
        public ActionResult <CommandRead> CreateCommand(CommandCreate commandCreate)
        {
            var commandModel =_mapper.Map<Command>(commandCreate);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();
            var CommandReadDto = _mapper.Map<CommandRead>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById), new {Id = CommandReadDto.Id}, CommandReadDto);
//            return Ok(CommandReadDto);
        }

        //Put api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdate commandUpdateDto)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(commandUpdateDto, commandModelFromRepo);

            _repository.UpdateCommand(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        // Patch api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdate> patchDoc)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<CommandUpdate>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);
            if(!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);

            _repository.UpdateCommand(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //Delete api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteCommand(commandModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

    }
}
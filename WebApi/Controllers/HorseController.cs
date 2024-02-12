using Application.Horses.Create;
using Application.Horses.Delete;
using Application.Horses.GetAll;
using Application.Horses.GetById;
using Application.Horses.Update;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HorseController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<CreateHorseCommand> _createValidator;
        private readonly IValidator<UpdateHorseCommand> _updateValidator;

        public HorseController(IMediator mediator 
            ,IValidator<CreateHorseCommand> createValidator
            , IValidator<UpdateHorseCommand> updateValidator)
        {
            _mediator = mediator;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            GetAllHorseQuery query = new GetAllHorseQuery();

            var result = await _mediator.Send(query);

            return Ok(result.ValueOrDefault);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetById(int id)
        {
            GetHorseByIdQuery query = new GetHorseByIdQuery { Id = id };

            var result = await _mediator.Send(query);

            if (result.IsFailed)
            {
                return BadRequest(result.Reasons);
            }

            return Ok(result.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateHorseCommand command)
        {
            ValidationResult validation = await _createValidator.ValidateAsync(command);

            if(validation.IsValid)
            {
                var result = await _mediator.Send(command);

                return Ok();
            }

            return BadRequest(validation.Errors.Select(s => new { s.ErrorMessage, s.PropertyName }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateHorseCommand command)
        {
            command.Id = id;

            ValidationResult validation = await _updateValidator.ValidateAsync(command);

            if (validation.IsValid)
            {
                var result = await _mediator.Send(command);

                if (result.IsFailed)
                {
                    return BadRequest(result.Reasons);
                }

                return Accepted();
            }
            
            return BadRequest(validation.Errors.Select(s => new { s.ErrorMessage, s.PropertyName }));

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DeleteHorseCommand command = new DeleteHorseCommand { Id = id };

            var result = await _mediator.Send(command);

            if (result.IsFailed)
            {
                return BadRequest(result.Reasons);  
            }

            return Accepted();
        }
    }
}

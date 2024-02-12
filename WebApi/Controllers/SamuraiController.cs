using Application.Samurai.Create;
using Application.Samurai.Delete;
using Application.Samurai.GetAll;
using Application.Samurai.GetById;
using Application.Samurai.Update;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class SamuraiController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<CreateSamuraiCommand> _createValidator;
        private readonly IValidator<UpdateSamuraiCommand> _updateValidator;

        public SamuraiController(IMediator mediator
            , IValidator<CreateSamuraiCommand> createValidator
            , IValidator<UpdateSamuraiCommand> updateValidator)
        {
            _mediator = mediator;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            GetAllSamuraiQuery query = new GetAllSamuraiQuery();

            var result = await _mediator.Send(query);

            return Ok(result.ValueOrDefault);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            GetSamuraiByIdQuery query = new GetSamuraiByIdQuery { Id = id };

            var result = await _mediator.Send(query);

            if (result.IsFailed)
            {
                return BadRequest(result.Reasons);
            }

            return Ok(result.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateSamuraiCommand command)
        {
            ValidationResult validation = await _createValidator.ValidateAsync(command);

            if (validation.IsValid)
            {
                var result = await _mediator.Send(command);

                return Ok();
            }

            return BadRequest(validation.Errors.Select(s => new { s.ErrorMessage, s.PropertyName }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateSamuraiCommand command)
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
            DeleteSamuraiCommand command = new DeleteSamuraiCommand { Id = id };

            var result = await _mediator.Send(command);

            if (result.IsFailed)
            {
                return BadRequest(result.Reasons);
            }

            return Accepted();
        }
    }
}

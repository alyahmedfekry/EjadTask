using Application.Battle.AddSamuraiToBattle;
using Application.Battle.Create;
using Application.Battle.Delete;
using Application.Battle.GetAll;
using Application.Battle.GetById;
using Application.Battle.RemoveSamuraiFromBattle;
using Application.Battle.Update;
using Application.Horses.Create;
using Application.Horses.Delete;
using Application.Horses.GetById;
using Application.Horses.Update;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class BattleController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<CreateBattleCommand> _createValidator;
        private readonly IValidator<UpdateBattleCommand> _updateValidator;
        private readonly IValidator<AddSamuraiToBattleCommand> _addSamuriValidator;
        private readonly IValidator<RemoveSamuraiFromBattleCommand> _removeSamuriValidator;


        public BattleController(IMediator mediator
            , IValidator<CreateBattleCommand> createValidator
            , IValidator<UpdateBattleCommand> updateValidator
            , IValidator<AddSamuraiToBattleCommand> addSamuriValidator
            , IValidator<RemoveSamuraiFromBattleCommand> removeSamuriValidator)
        {
            _mediator = mediator;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _addSamuriValidator = addSamuriValidator;
            _removeSamuriValidator = removeSamuriValidator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            GetAllBattleQuery query = new GetAllBattleQuery();

            var result = await _mediator.Send(query);

            return Ok(result.ValueOrDefault);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            GetBattleByIdQuery query = new GetBattleByIdQuery { Id = id };

            var result = await _mediator.Send(query);

            if (result.IsFailed)
            {
                return BadRequest(result.Reasons);
            }

            return Ok(result.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateBattleCommand command)
        {
            ValidationResult validation = await _createValidator.ValidateAsync(command);

            if (validation.IsValid)
            {
                var result = await _mediator.Send(command);

                return Ok();
            }

            return BadRequest(validation.Errors.Select(s => new {s.ErrorMessage,s.PropertyName}));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateBattleCommand command)
        {
            command.Id = id;

            ValidationResult validation = await _updateValidator.ValidateAsync(command);

            if(validation.IsValid)
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
            DeleteBattleCommand command = new DeleteBattleCommand { Id = id };

            var result = await _mediator.Send(command);

            if (result.IsFailed)
            {
                return BadRequest(result.Reasons);
            }

            return Accepted();
        }

        [HttpPost("AddSamuraiToBattle")]
        public async Task<IActionResult> AddSamuraiToBattle(AddSamuraiToBattleCommand command)
        {
            ValidationResult validation = await _addSamuriValidator.ValidateAsync(command);

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

        [HttpDelete("RemoveSamuraiToBattle")]
        public async Task<IActionResult> RemoveSamuraiToBattle(RemoveSamuraiFromBattleCommand command)
        {

            ValidationResult validation = await _removeSamuriValidator.ValidateAsync(command);

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
    }
}

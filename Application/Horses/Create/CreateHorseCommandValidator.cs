using Application.Horses.Update;
using Domain.Abstractions.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Horses.Create
{
    public class CreateHorseCommandValidator : AbstractValidator<CreateHorseCommand>
    {
        public CreateHorseCommandValidator(IHorseRepository horseRepository) 
        {
            RuleFor(h => h.Name).MustAsync(async (name, _) =>
            {
                return await horseRepository.IsUniqueName(name);
            }).WithMessage("name must be unique!!");
            RuleFor(h => h.Weight).NotEmpty();
            RuleFor(h => h.Color).NotEmpty();
            RuleFor(h => h.Age).InclusiveBetween(1,30).WithMessage(" the age must be between 1-30");
            RuleFor(h => h.Speed).InclusiveBetween(55,90).WithMessage("the speed must be between 55-90");
        }
    }
}

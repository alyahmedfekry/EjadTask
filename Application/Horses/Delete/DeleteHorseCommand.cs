using Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Horses.Delete
{
    public sealed class DeleteHorseCommand : ICommand
    {
        public int Id { get; set; } 
    }
}

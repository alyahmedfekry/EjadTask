using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions;
namespace Application.Horses.Create
{
    public sealed class CreateHorseCommand : ICommand
    {
        public string Name { get; set; } = string.Empty;
        public double Weight { get; set; }
        public string Color { get; set; } = string.Empty;
        public int Age { get; set; }
        public double Speed { get; set; }
    }
}

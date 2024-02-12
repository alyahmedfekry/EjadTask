using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Horses.GetById
{
    public sealed class GetHorseByIdQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Weight { get; set; }
        public string Color { get; set; } = string.Empty;
        public int Age { get; set; }
        public double Speed { get; set; }
    }
}

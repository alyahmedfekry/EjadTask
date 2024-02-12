using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Samurai.GetById
{
    public class GetSamuraiByIdQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Role { get; set; } = string.Empty;
        public double Hight { get; set; }
        public double Weight { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsAvailable { get; set; }
    }
}

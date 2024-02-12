using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Horse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Weight { get; set; }
        public string Color { get; set; } = string.Empty;
        public int Age { get; set;}
        public double Speed { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsDeleted { get; set; }
        public Horse(string name ,double weight ,string color ,int age ,double speed)
        {
            Name = name;
            Weight = weight;
            Color = color;
            Age = age;
            Speed = speed;
            IsAvailable = true;
            IsDeleted = false;  
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Samurai
    {
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Role { get; set;} = string.Empty;
        public double Hight { get; set; }
        public double Weight { get; set; }   
        public bool IsDeleted { get; set; }
        public bool IsAvailable { get; set; }
        public Samurai(string name ,int age ,string role ,double hight ,double weight)
        {
            Name = name;
            Age = age;
            Role = role;
            Weight = weight;
            Hight = hight;
            IsAvailable = true;
            IsDeleted = false;
        }
    }
}

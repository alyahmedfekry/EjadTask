using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Battle
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime? FinishedDate { get; set; }
        public bool IsDeleted { get; set; }
        public HashSet<SamuraiBattle> samurais { get; set; } = new();
        public Battle(string name) 
        {
          Name = name;
        }
        public void AddSamuraiWithHorse(int horseId ,int samuraiId)
        {
            SamuraiBattle samuraiBattle = new SamuraiBattle
            {
                HorseId = horseId,
                SamuraiId = samuraiId,
                StratedRodeDate = DateTime.Now
            };

            samurais.Add(samuraiBattle);
        }
    }
}


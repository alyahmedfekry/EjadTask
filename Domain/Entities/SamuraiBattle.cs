using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SamuraiBattle
    {
        public int Id { get; set; } 
        public int SamuraiId { get; set; }
        public int HorseId { get; set; }
        public int BattleId { get; set; }
        public DateTime StratedRodeDate { get; set; }
        public DateTime? EndRodeDate { get; set; }
        public Samurai Samurai { get; set; }
        public Battle Battle { get; set; }
        public Horse Horse { get; set; }
    }
}

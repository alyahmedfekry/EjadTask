using Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Battle.AddSamuraiToBattle
{
    public sealed class AddSamuraiToBattleCommand : ICommand
    {
        public int? SamuraiId { get; set; }
        public int? HorseId { get; set; }
        public int? BattleId { get; set; }
    }
}

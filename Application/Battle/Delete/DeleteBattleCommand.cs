using Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Battle.Delete
{
    public class DeleteBattleCommand : ICommand
    {
        public int Id { get; set; } 
    }
}

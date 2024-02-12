using Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Battle.Create
{
    public sealed class CreateBattleCommand : ICommand
    {
        public string Name { get; set; } = string.Empty;

    }
}

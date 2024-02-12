using Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Samurai.Delete
{
    public class DeleteSamuraiCommand : ICommand
    {
        public int Id { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Battle.GetById
{
    public class GetBattleByIdQueryResponse 
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime? FinishedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}

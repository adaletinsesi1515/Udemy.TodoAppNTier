using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.TodoAppNtier.Dtos.Interfaces;

namespace Udemy.TodoAppNtier.Dtos.WorkDto
{
    public class WorkListDto : IDto
    {
        public int Id { get; set; }
        public string Definition { get; set; }
        public bool IsCompleted { get; set; }
    }
}

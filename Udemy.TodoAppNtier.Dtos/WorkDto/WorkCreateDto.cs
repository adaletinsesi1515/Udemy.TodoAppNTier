using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.TodoAppNtier.Dtos.Interfaces;

namespace Udemy.TodoAppNtier.Dtos.WorkDto
{
    public class WorkCreateDto : IDto
    {
        [Required(ErrorMessage ="İş tanımını boş geçemezsiniz...")]
        public string Definition { get; set; }
        public bool IsCompleted { get; set; }
    }
}

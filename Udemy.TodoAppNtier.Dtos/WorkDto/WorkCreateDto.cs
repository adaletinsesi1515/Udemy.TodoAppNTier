using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.TodoAppNtier.Dtos.WorkDto
{
    public class WorkCreateDto
    {
        [Required(ErrorMessage ="İş tanımını boş geçemezsiniz...")]
        public string Definition { get; set; }
        public bool IsCompleted { get; set; }
    }
}

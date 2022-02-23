using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.TodoAppNtier.Dtos.Interfaces;
using Udemy.TodoAppNtier.Dtos.WorkDto;

namespace Udemy.TodoAppNTier.Business.Interfaces
{
    public interface IWorkServices
    {
        Task<List<WorkListDto>> GetAll();

        Task <IDto> GetById<IDto>(int id);

        Task Create(WorkCreateDto dto);
        Task Remove(int id);
        Task Update(WorkUpdateDto dto);

    }
}

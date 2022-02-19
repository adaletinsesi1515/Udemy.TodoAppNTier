using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.TodoAppNTier.Business.Interfaces;
using Udemy.TodoAppNTier.DataAccess.UnitofWork;
using Udemy.TodoAppNtier.Dtos.WorkDto;
using Udemy.TodoAppNTier.Entities.Concrete;

namespace Udemy.TodoAppNTier.Business.Services
{
    public class WorkServices : IWorkServices
    {
        private readonly IUow _uow;

        public WorkServices(IUow uow)
        {
            _uow = uow;
        }

        public async Task<List<WorkListDto>> GetAll()
        {
            var list = await _uow.GetRepository<Work>().GetAll();
            var worklist = new List<WorkListDto>();
            if (list != null && list.Count > 0)
            {
                foreach (var work in list)
                {
                    worklist.Add(new()
                    {
                        Id = work.Id,
                        Definition = work.Definition,
                        IsCompleted = work.IsCompleted,
                    });
                }
            }
            return worklist;
        }

        public async Task<WorkListDto> GetById(int id)
        {
            var data = await _uow.GetRepository<Work>().GetById(id);
            return new()
            {
                Definition = data.Definition,
                IsCompleted = data.IsCompleted,
            };
        }

        public async Task Create(WorkCreateDto dto)
        {
            await _uow.GetRepository<Work>().Create(new()
            {
                Definition = dto.Definition,
                IsCompleted = dto.IsCompleted,
            });
            await _uow.SaveChanges();
        }

        public async Task Remove(object id)
        {
            var deletedWork = await _uow.GetRepository<Work>().GetById(id);
            _uow.GetRepository<Work>().Remove(deletedWork);
            await _uow.SaveChanges();
        }

        public async Task Update(WorkUpdateDto dto)
        {
            _uow.GetRepository<Work>().Update(new()
            {
                Id = dto.Id,
                Definition = dto.Definition,
                IsCompleted = dto.IsCompleted,
            });
            await _uow.SaveChanges();
        }
    }
}

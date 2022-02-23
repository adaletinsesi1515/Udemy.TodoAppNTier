using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Udemy.TodoAppNTier.Business.Interfaces;
using Udemy.TodoAppNTier.DataAccess.UnitofWork;
using Udemy.TodoAppNtier.Dtos.Interfaces;
using Udemy.TodoAppNtier.Dtos.WorkDto;
using Udemy.TodoAppNTier.Entities.Concrete;

namespace Udemy.TodoAppNTier.Business.Services
{
    public class WorkServices : IWorkServices
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public WorkServices(IUow uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<WorkListDto>> GetAll()
        {
            return _mapper.Map<List<WorkListDto>>(await _uow.GetRepository<Work>().GetAll());
        }

        public async Task<IDto> GetById<IDto>(int id)
        {
            return _mapper.Map<IDto>(await  _uow.GetRepository<Work>().GetByFilter(x=>x.Id == id));
        }

        public async Task Create(WorkCreateDto dto)
        {
            await _uow.GetRepository<Work>().Create(_mapper.Map<Work>(dto));
            await _uow.SaveChanges();
        }

        public async Task Remove(int id)
        {
            
            _uow.GetRepository<Work>().Remove(id);
            await _uow.SaveChanges();
        }

        public async Task Update(WorkUpdateDto dto)
        {
            _uow.GetRepository<Work>().Update(_mapper.Map<Work>(dto));
            await _uow.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Udemy.TodoAppNtier.Dtos.WorkDto;
using Udemy.TodoAppNTier.Entities.Concrete;

namespace Udemy.TodoAppNTier.Business.Mappings.AutoMapper
{
    public class WorkProfile : Profile 
    {
        public WorkProfile()
        {
            CreateMap<Work, WorkListDto>().ReverseMap();
            CreateMap<Work, WorkCreateDto>().ReverseMap();
            CreateMap<Work, WorkUpdateDto>().ReverseMap();
            CreateMap<WorkListDto, WorkUpdateDto>().ReverseMap();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DutchTreat.Data.Entities;
using DutchTreat.ViewModels;

namespace DutchTreat.Data
{
    public class DutchMappingProfile : Profile
    {
        public DutchMappingProfile()
        {
            //Creates a mapping between these objects and also creates the reverse map.
            CreateMap<Order, OrderViewModel>()
                .ForMember(vm => vm.OrderId, source => source.MapFrom(o => o.Id))
                .ReverseMap();
        }
    }
}

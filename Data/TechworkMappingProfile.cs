using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Techwork.Data.Entities;
using techwork_after_america_return.Data.Entities;
using techwork_after_america_return.ViewModels;

namespace techwork_after_america_return.Data
{
    public class TechworkMappingProfile: Profile//container for any mapper that we want to create
    {
        public TechworkMappingProfile()
        {
            CreateMap<Order, OrderViewModel>()
            .ForMember(o => o.OrderId, ex => ex.MapFrom(o => o.Id))
            .ReverseMap();

            CreateMap<OrderItem, OrderViewModel>()
                .ReverseMap();







        }
    }
}

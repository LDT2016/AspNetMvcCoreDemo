using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDemo.Models;
using ApiDemo.Models.ui.locations;
using ApiDemo.Utils;
using AutoMapper;

namespace ApiDemo.Map
{
    public class Location : Profile
    {
        public Location()
        {
            CreateMap<ImprintFormatBO, Format>()
                .ForMember(to => to.IsDefault, opt => { opt.MapFrom(from => from.IsDefault.Trim().Equals("y", StringComparison.OrdinalIgnoreCase)); })
                .ForMember(to => to.ShowOnWeb, opt => { opt.MapFrom(from => from.ShowOnWeb.Trim().Equals("y", StringComparison.OrdinalIgnoreCase)); })
                .ForMember(to => to.ProcessType,
                           opt =>
                           {
                               //opt.MapFrom(from => from.ProcessType);

                               opt.MapFrom(from => from.ProcessId.ToString().ToEnum<ProcessTypes>());
                           });
        }
    }

    public class MappingProfile : Profile
    {

    }

}

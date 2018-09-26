using System;
using AutoMapper;
using FacilityMgmt.Api.Contracts;
using FacilityMgmt.DAL.Common.Models;

namespace FacilityMgmt.Api
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public static class MappingConfiguration
    {
        public static IMapper Create()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<FacilityGroup, FacilityGroupDto>();
                cfg.CreateMap<Facility, FacilityDto>();
            });

            return Mapper.Instance;
        }
    }
}

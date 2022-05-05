using AutoMapper;
using Core.Domain.Entities.CatalogueItemAggregate;
using System.Collections.Generic;

namespace Core.Mapping.Profiles
{
    public class MappingProfiles : Profile
    {

        public MappingProfiles()
        {
            CreateMap<CatalogueItem, CatalogueItemDTO>().ReverseMap();
            //CreateMap<IList<CatalogueItem>, IList<CatalogueItemDTO>>();
        }
    }
}

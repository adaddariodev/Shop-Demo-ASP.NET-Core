using AutoMapper;
using Core.Domain.Entities.CatalogueItemAggregate;

namespace Core.Mapping.Profiles
{
    public class MappingProfiles : Profile
    {

        public MappingProfiles()
        {
            CreateMap<CatalogueItem, CatalogueItemDTO>().ReverseMap();
        }

    }
}

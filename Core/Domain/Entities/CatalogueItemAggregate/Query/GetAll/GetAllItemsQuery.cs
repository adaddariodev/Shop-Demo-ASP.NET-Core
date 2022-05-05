using AutoMapper;
using Core.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Core.Domain.Entities.CatalogueItemAggregate.Query.GetAll
{
    public class GetAllItemsQuery : IRequest<IList<CatalogueItemDTO>>
    {
        public GetAllItemsQuery()
        {

        }
    }

    public class GetAllItemsQueryHandler : IRequestHandler<GetAllItemsQuery, IList<CatalogueItemDTO>>
    {
        private readonly ICatalogueItemRepository _repository;
        private readonly IMapper _mapper;

        public GetAllItemsQueryHandler(ICatalogueItemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IList<CatalogueItemDTO>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
        {
            var items = await _repository.ListAllAsync();

            List<CatalogueItemDTO> ListitemsDTO = items.Select(x => new CatalogueItemDTO
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                ImagePath = x.ImagePath,
                Price = x.Price
            }).ToList();

            return ListitemsDTO;
        }
    }
}
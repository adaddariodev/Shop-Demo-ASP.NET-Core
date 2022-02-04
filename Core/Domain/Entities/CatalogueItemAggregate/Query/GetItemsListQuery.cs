using AutoMapper;
using Core.Domain.Entities.CatalogueItemAggregate;
using Core.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Domain.Entities.CatalogueItemAggregate.Query
{
    public class GetItemsListQuery : IRequest<List<CatalogueItemDTO>>
    {
    }

    public class GetItemsListQueryHandler : IRequestHandler<GetItemsListQuery, List<CatalogueItemDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ICatalogueItemRepository _catalogueItemRepository;

        public GetItemsListQueryHandler(IMapper mapper, ICatalogueItemRepository catalogueItemRepository)
        {
            _mapper = mapper;
            _catalogueItemRepository = catalogueItemRepository;
        }

        public async Task<List<CatalogueItemDTO>> Handle(GetItemsListQuery request, CancellationToken cancellationToken)
        {
            var users = await _catalogueItemRepository.ListAllAsync();

            if (users is null)
                throw new ArgumentException();

            return _mapper.Map<List<CatalogueItemDTO>>(users);
        }
    }
}

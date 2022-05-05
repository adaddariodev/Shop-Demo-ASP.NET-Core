using AutoMapper;
using Core.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Domain.Entities.CatalogueItemAggregate.Query.GetListByFilter
{
    public class GetItemsListByFilterQuery : IRequest<List<CatalogueItemDTO>>
    {
        public GetItemsListByFilterQuery(string filter)
        {
            Filter = filter;
        }

        public string Filter { get; }
    }

    public class GetItemsListByFilterQueryHandler : IRequestHandler<GetItemsListByFilterQuery, List<CatalogueItemDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ICatalogueItemRepository _catalogueItemRepository;

        public GetItemsListByFilterQueryHandler(IMapper mapper, ICatalogueItemRepository catalogueItemRepository)
        {
            _mapper = mapper;
            _catalogueItemRepository = catalogueItemRepository;
        }

        public async Task<List<CatalogueItemDTO>> Handle(GetItemsListByFilterQuery request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(request.Filter))
            {
                var items = _catalogueItemRepository.GetByFilter(request.Filter);

                if (items is null)
                    throw new ArgumentException("Impossible to get the list of items.");

                return _mapper.Map<List<CatalogueItemDTO>>(items);
            }
            else
            {
                var items = await _catalogueItemRepository.ListAllAsync();

                if (items is null)
                    throw new ArgumentException("Impossible to get the list of items.");

                return _mapper.Map<List<CatalogueItemDTO>>(items);
            }

        }
    }
}
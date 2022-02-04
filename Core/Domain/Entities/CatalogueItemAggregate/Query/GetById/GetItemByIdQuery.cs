using AutoMapper;
using Core.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Domain.Entities.CatalogueItemAggregate.Query.GetById
{
    public class GetItemByIdQuery : IRequest<CatalogueItemDTO>
    {
        public GetItemByIdQuery(long id)
        {
            Id = id;
        }

        public long Id { get; }
    }

    public class GetItemByIdQueryHandler : IRequestHandler<GetItemByIdQuery, CatalogueItemDTO>
    {
        private readonly IMapper _mapper;
        private readonly ICatalogueItemRepository _catalogueItemRepository;

        public GetItemByIdQueryHandler(IMapper mapper, ICatalogueItemRepository catalogueItemRepository)
        {
            _mapper = mapper;
            _catalogueItemRepository = catalogueItemRepository;
        }

        public async Task<CatalogueItemDTO> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
        {
            var item = await _catalogueItemRepository.GetByIdAsync(request.Id);

            if (item == null)
                throw new ArgumentException("The item you are searching doesnt exist.");

            return _mapper.Map<CatalogueItemDTO>(item);
        }
    }
}

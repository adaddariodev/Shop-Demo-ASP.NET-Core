using AutoMapper;
using Core.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Domain.Entities.CatalogueItemAggregate.Command.Update
{
    public class UpdateItemCommand : IRequest<UpdateItemCommandResponse>
    {
        public UpdateItemCommand(CatalogueItemDTO item, long id)
        {
            Item = item;
            Id = id;
        }

        public CatalogueItemDTO Item { get; }
        public long Id { get; }
    }

    public class UpdateProdottoCommandHandler : IRequestHandler<UpdateItemCommand, UpdateItemCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICatalogueItemRepository _catalogueItemRepository;

        public UpdateProdottoCommandHandler(IMapper mapper, ICatalogueItemRepository catalogueItemRepository)
        {
            _mapper = mapper;
            _catalogueItemRepository = catalogueItemRepository;
        }

        public async Task<UpdateItemCommandResponse> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            var updateItemCommandResponse = new UpdateItemCommandResponse();

            var validator = new UpdateItemCommandValidator(_catalogueItemRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                updateItemCommandResponse.Success = false;
                updateItemCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    updateItemCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (updateItemCommandResponse.Success)
            {
                //var prodotto = Prodotto.CreateProdotto(request.Prodotto.Nome, request.Prodotto.Descrizione, request.Prodotto.Prezzo, request.Prodotto.ProductImageURL, request.Prodotto.Categorie);
                //prodotto = await _prodottoRepository.AddAsync(prodotto);

                var prod = _mapper.Map<CatalogueItem>(request.Item);
                await _catalogueItemRepository.UpdateAsync(prod);

                updateItemCommandResponse.Item = _mapper.Map<CatalogueItemDTO>(request.Item);

            }

            return updateItemCommandResponse;
        }
    }
}

using AutoMapper;
using Core.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Core.Domain.Entities.CatalogueItemAggregate;

namespace Core.Domain.Entities.CatalogueItemAggregate.Command
{
    public class CreateItemCommand : IRequest<CreateItemCommandResponse>
    {
        public CreateItemCommand(string name, string description, double price, string imagePath)
        {
            Name = name;
            Description = description;
            Price = price;
            ImagePath = imagePath;
        }

        public string Name { get; }
        public string Description { get; }
        public double Price { get; }
        public string ImagePath { get; }
    }

    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, CreateItemCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICatalogueItemRepository _catalogueItemRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateItemCommandHandler(IMapper mapper, ICatalogueItemRepository catalogueItemRepository, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _catalogueItemRepository = catalogueItemRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<CreateItemCommandResponse> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var createItemCommandResponse = new CreateItemCommandResponse();

            var validator = new CreateItemCommandValidator(_catalogueItemRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createItemCommandResponse.Success = false;
                createItemCommandResponse.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    createItemCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (createItemCommandResponse.Success)
            {
                //get current
                var user = _httpContextAccessor.HttpContext.User.Identity.Name;

                var item = new CatalogueItem(request.Name, request.Description, request.Price, request.ImagePath, user);
                item = await _catalogueItemRepository.AddAsync(item);
                createItemCommandResponse.Item = _mapper.Map<CatalogueItemDTO>(item);
            }

            return createItemCommandResponse;
        }
    }
}

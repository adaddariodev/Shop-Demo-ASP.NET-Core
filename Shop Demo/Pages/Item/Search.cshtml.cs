using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Domain.Entities.CatalogueItemAggregate;
using Core.Domain.Entities.CatalogueItemAggregate.Query.GetListByFilter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Shop_Demo.Pages.Item
{
    public class SearchModel : PageModel
    {
        private readonly IMediator _mediator;

        public SearchModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [BindProperty(SupportsGet = true)]
        public string Filter { get; set; }

        public IList<CatalogueItemDTO> Item { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Item = await _mediator.Send(new GetItemsListByFilterQuery(Filter));

            return Page();
        }
    }
}

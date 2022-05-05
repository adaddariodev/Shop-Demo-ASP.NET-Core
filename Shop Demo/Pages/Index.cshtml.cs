using Core.Domain.Entities.CatalogueItemAggregate;
using Core.Domain.Entities.CatalogueItemAggregate.Query.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop_Demo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IMediator _mediator;

        public IndexModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [BindProperty(SupportsGet = true)]
        public string Handler { get; set; }

        public IList<CatalogueItemDTO> ItemList { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
           ItemList = await _mediator.Send(new GetAllItemsQuery());

            return Page();
        }
    }
}
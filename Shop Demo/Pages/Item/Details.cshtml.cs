using Core.Domain.Entities.CatalogueItemAggregate;
using Core.Domain.Entities.CatalogueItemAggregate.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Shop_Demo.Pages.Item
{
    public class DetailsModel : PageModel
    {
        private readonly IMediator _mediator;

        public DetailsModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [BindProperty(SupportsGet = true)]
        public CatalogueItemDTO Item { get; set; }

        public long Id { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Item = await _mediator.Send(new GetItemByIdQuery((long)id));

            if (Item == null)
            {
                return RedirectToPage("../Index", "Impossible to get the requested item!");
            }

            return Page();
        }
    }
}

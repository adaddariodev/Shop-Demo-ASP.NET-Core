using Core.Domain.Entities.CatalogueItemAggregate;
using Core.Domain.Entities.CatalogueItemAggregate.Query.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace MenuOnline.UI.Pages.Prodotto
{
    public class EditModel : PageModel
    {
        private readonly IMediator _mediator;

        public EditModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [BindProperty]
        public CatalogueItemDTO Item { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Item = await _mediator.Send(new GetItemByIdQuery((long)id));

            if (Item == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = await _mediator.Send(new UpdateProdottoCommand(Prodotto));

            return RedirectToPage("./Index", result);
        }

    }
}

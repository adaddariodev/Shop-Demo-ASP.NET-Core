using Core.Domain.Entities.CatalogueItemAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence
{
    public interface ICatalogueItemRepository : IAsyncRepository<CatalogueItem>
    {
    }
}

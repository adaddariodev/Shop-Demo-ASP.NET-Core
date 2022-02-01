using Core.Domain.Entities.Item;
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

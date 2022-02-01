using Core.Domain.Entities.Item;
using Core.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CatalogueItemRepository : BaseRepository<CatalogueItem>, ICatalogueItemRepository
    {
        public CatalogueItemRepository(MyDbContext myDbContext) : base(myDbContext)
        {

        }
    }
}

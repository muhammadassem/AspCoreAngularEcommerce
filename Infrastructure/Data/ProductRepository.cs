using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(StoreContext dbContext) : base(dbContext)
        {
        }

        public override IQueryable<Product> GetAll()
        {
            return base.GetAll().Include(x => x.ProductBrand).Include(x => x.ProductType).AsQueryable();
        }
    }
}
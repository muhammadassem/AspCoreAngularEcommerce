using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;
using Core.Extensions;
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

        public async Task<QueryResult<Product>> GetAllProducts(ProductQuery filter)
        {
            var query = base.GetAll().Include(x => x.ProductBrand).Include(x => x.ProductType).AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Name))
                query = query.Where(x => x.Name.Contains(filter.Name));


            var ordrByDictionary = new Dictionary<string, Expression<Func<Product, object>>>()
            {
                { "Name",  x => x.Name }
            };

            query = query.ApplyOrdering(filter, ordrByDictionary["Name"]);

            var queryResult = new QueryResult<Product>();
            queryResult.TotalRecords = await query.CountAsync();

            query = query.ApplyPaging(filter);

            queryResult.Items = query.ToList();

            return queryResult;
        }
    }
}
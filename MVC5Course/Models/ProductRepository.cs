using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5Course.Models
{   
	public  class ProductRepository : EFRepository<Product>, IProductRepository
	{
        public override IQueryable<Product> All()
        {
            return base.All().Where(p => p.IsDeleted != true);
        }

        public Product Find(int? id)
        {
            return All().FirstOrDefault(p => p.ProductId == id);
        }
    }

	public  interface IProductRepository : IRepository<Product>
	{

	}
}
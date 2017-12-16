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

        public override void Delete(Product entity)
        {
            //base.Delete(entity);
            entity.IsDeleted = true;
        }

        public IQueryable<Product> GetTop20()
        {
            return All().Take(20);
        }
    }

	public  interface IProductRepository : IRepository<Product>
	{

	}
}
using Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Model.EF;

namespace Model.DAO
{
   public class ProductCategoryDao : Repository<ProductCategory>

    {
        private K_TShop db = null;

        public ProductCategoryDao()
        {
            db = new K_TShop();
        }
        public IEnumerable<ProductCategory> GetAll()
        {
            return db.ProductCategory.OrderBy(x => x.Name);
        }


        public void Add(ProductCategory entity)
        {
            throw new NotImplementedException();
        }

        public bool CheckContains(Expression<Func<ProductCategory, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int Count(Expression<Func<ProductCategory, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(ProductCategory entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteMulti(Expression<Func<ProductCategory, bool>> where)
        {
            throw new NotImplementedException();
        }

        public void Update(ProductCategory entity)
        {
            throw new NotImplementedException();
        }
    }
}

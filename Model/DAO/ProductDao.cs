using Model.EF;
using Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Model.DAO
{
    public class ProductDao : Repository<Product>
    {
        private K_TShop db = null;

        public ProductDao()
        {
            db = new K_TShop();
        }

        public Product Add(Product entity)
        {
           return db.Product.Add(entity);
        }

        public bool CheckContains(Expression<Func<Product, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int Count(Expression<Func<Product, bool>> where)
        {
            throw new NotImplementedException();
        }

        public Product Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Product Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteMulti(Expression<Func<Product, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            return db.Product.OrderBy(x => x.Name);
        }

        public IEnumerable<Product> searchProduct(string sTuKhoa)
        {
            if (sTuKhoa == null)
            {
                return db.Product.ToList();
            }
            else return db.Product.Where(x => x.Name.Contains(sTuKhoa)).OrderBy(x => x.Name);
        }
        public IEnumerable<Product> GetListName()
        {
            return db.Product;
        }
        public IQueryable<Product> GetAll(string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Product> GetMulti(Expression<Func<Product, bool>> predicate, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Product> GetMultiPaging(Expression<Func<Product, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public Product GetSingleByCondition(Expression<Func<Product, bool>> expression, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public Product GetSingleById(int id)
        {
            return db.Product.SingleOrDefault(x => x.ID == id);
        }

        public void Update(Product entity)
        {
            var product = db.Product.SingleOrDefault(x => x.ID == entity.ID);
            product.Name = entity.Name;
            product.Code = entity.Code;
            product.MetaTitle = entity.MetaTitle;
            product.Price = entity.Price;
            product.IncludedVAT = entity.IncludedVAT;
            product.Quantity = entity.Quantity;
            product.Warranty = entity.Warranty;
            product.Detail = entity.Detail;
            product.Status = entity.Status;
            db.SaveChanges();
        }

        void Repository<Product>.Add(Product entity)
        {
            throw new NotImplementedException();
        }

        void Repository<Product>.Update(Product entity)
        {
            throw new NotImplementedException();
        }

        void Repository<Product>.Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        void Repository<Product>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        void Repository<Product>.DeleteMulti(Expression<Func<Product, bool>> where)
        {
            throw new NotImplementedException();
        }

        int Repository<Product>.Count(Expression<Func<Product, bool>> where)
        {
            throw new NotImplementedException();
        }

        bool Repository<Product>.CheckContains(Expression<Func<Product, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
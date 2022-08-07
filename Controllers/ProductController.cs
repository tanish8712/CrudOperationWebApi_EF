using CrudOperationWebApi_EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CrudOperationWebApi_EF.Controllers
{
    public class ProductController : ApiController
    {
        Entities db = new Entities();

        //add post request
        [HttpPost]
        [Route("api/Product")]
        public string Post(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return "Product added";
        }

        //get all products
        [HttpGet]
        [Route("api/Product")]
        public IEnumerable<Product> Get()
        {
            return db.Products.ToList();
        }
        
        public Product Get(int id)
        {
            Product prod = db.Products.Find(id);
            return prod;
        }

        public string Put(int id, Product product)
        {
            var prod_ = db.Products.Find(id);
            prod_.Name = product.Name;
            prod_.Price = product.Price;
            prod_.Quantity = product.Quantity;
            prod_.Active = product.Active;

            db.Entry(prod_).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return "Product Updated";
        }

        public string Delete(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return "Product Deleted";
        }
    }
}

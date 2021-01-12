using Microsoft.AspNetCore.Mvc;
using SleiFoodDb.Data;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SleiFoodDb.Models;


namespace SleiFoodDb.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class productController:ControllerBase
    {
        private readonly Databasedcontext databasedContext;
        public productController(Databasedcontext databasedContext)
        {
            this.databasedContext = databasedContext;
        }

        [HttpGet("{id}")]
        public IActionResult index(int id)
        {
            var products = databasedContext.products.FirstOrDefault(i=> i.productId == id);
            return Ok(products);
        }

        [HttpGet]
        public IActionResult index()
        {
            var products = databasedContext.products;
            return Ok(products);
        }


        [HttpPost("create")]
        public IActionResult create([FromForm]Product model)
        {
            databasedContext.products.Add(model);
            databasedContext.SaveChanges();
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult deleteProduct(int id)
        {
            var product = databasedContext.products.FirstOrDefault(i => i.productId == id);
            databasedContext.products.Remove(product);
            databasedContext.SaveChanges();
            return Ok();
        }

    }


}

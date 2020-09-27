using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreBasics.Models;
using CoreBasics.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreBasics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        public ProductService ProductService { get; }

        public ProductsController(ProductService productService)
        {
            ProductService = productService;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductService.GetProducts();
        }

        [Route("Rate")]
        [HttpGet]
        public ActionResult Get([FromQuery] string productId, [FromQuery] int rating)
        {
            ProductService.AddRating(productId, rating);
            return Ok();
        }

    }
}

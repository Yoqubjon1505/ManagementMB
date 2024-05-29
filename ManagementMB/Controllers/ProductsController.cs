using ManagementMB.DTOs;
using ManagementMB.Interfaces.IServices;
using ManagementMB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;

namespace ManagementMB.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService= productService;
        }
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productService.GetAll();
        }

        [HttpPost]
        public IActionResult Create([FromBody]ProductDTO product)
        {
           _productService.Create(product);
            return Ok(product);
        }

        [HttpPut("Update")]
        public IActionResult Update([FromQuery]Guid id,[FromBody]ProductDTO product)
        {
           var item = _productService.GetById(id);
            if (item != null)
            {
                _productService.Update(item.Id, product);
                return Ok(item);
            }
            return BadRequest();
        }

        [HttpDelete("Delete")]
        public IActionResult Delete([FromBody]Guid id)
        {
            var product = _productService.GetById(id);
            if (product !=null)
            {
                _productService.Delete(id);
                return Ok("Deleted");
            }
            return BadRequest();
        }
        [HttpGet("GetById")]
        public IActionResult GetById(Guid id) 
        {
            return Ok(_productService.GetById(id));
        }
    }
}

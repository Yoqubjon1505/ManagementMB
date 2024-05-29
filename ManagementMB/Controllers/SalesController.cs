using ManagementMB.DTOs;
using ManagementMB.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementMB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        ISaleService _saleService;
        public SalesController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpPost]
        public IActionResult Create([FromQuery] Guid id, [FromBody] SaleProductDTO item)
        {
            var _item = _saleService.Create(id, item);

            if (item != null)
            {
                return Ok(item);
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult UpdateSale([FromQuery]Guid id,[FromBody] SaleProductDTO item)
        {
            var _tem = _saleService.GetById(id);
            if (_tem != null)
            {
                return Ok(_saleService.UpdateSale(id, item));
            }
            return BadRequest();
        }
        [HttpDelete]
        public IActionResult DeleteSale([FromBody] Guid id)
        {
            var _item = _saleService.GetById(id);
            if (_item != null)
            {
                return Ok(_saleService.DeleteSale(_item.Id));

            }
            return BadRequest();
        }

        [HttpGet("GetById")]
        public IActionResult GetSaleById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid ID");
            }

            var item = _saleService.GetById(id);
            if (item != null)
            {
                return Ok(item);
            }

            return NotFound();
        }

        [HttpGet("GetDataTime")]
        public IActionResult GetByDateTime(DateTime dateTime)
        {
            var item = _saleService.GetByDateTime(dateTime);
            
            if (item != null)
            {
                return Ok(item);
            }
            return NotFound();

        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_saleService.GetAll());
        }
    }

}

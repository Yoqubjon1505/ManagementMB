using ManagementMB.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementMB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BalanceController : ControllerBase
    {
        private readonly IBalanceService _balanceService;
        public BalanceController(IBalanceService balanceService)
        {
            _balanceService = balanceService;
        }
        [HttpPost]
        public ActionResult GetBalanceByDateTime([FromBody]DateTime dateTime)
        {
          var balance =  _balanceService.GetByDate(dateTime);
            if (balance!=null)
            {
                return Ok(balance);
            }
            return NotFound();
        }
    }
}

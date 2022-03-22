using ASPNET_MongoDB_Quickstart.Models;
using ASPNET_MongoDB_Quickstart.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASPNET_MongoDB_Quickstart.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly IBankService bankService;

        public BankController(IBankService bankService)
        {
            this.bankService = bankService;
        }
        [HttpGet("")]

        public async Task<ActionResult<List<Accounts>>> Get()
        {
            var accounts = await bankService.GetAllAccountsAsync();

            return Ok(accounts);
        }
    }
}

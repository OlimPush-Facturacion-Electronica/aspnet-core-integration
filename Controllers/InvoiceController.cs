using aspnet_core_integration.Dtos.Invoice;
using aspnet_core_integration.Services;
using Microsoft.AspNetCore.Mvc;

namespace aspnet_core_integration.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class InvoiceController(IInvoiceService invoiceService) : ControllerBase
    {
        private readonly IInvoiceService _invoiceService = invoiceService;

        [HttpPost]
        public async  Task<IActionResult> Create([FromBody] InvoicePayloadDto requestDto)
        {
            var response = await _invoiceService.Create(requestDto);

            return Ok(response);
           
        }
      
    }
}

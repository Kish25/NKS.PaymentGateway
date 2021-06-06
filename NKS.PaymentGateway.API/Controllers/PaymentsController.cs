// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NKS.Payments.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Contracts;
    using Interfaces;
    using Core.Exceptions;
    using Serilog;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly IPaymentMapper _mapper;

        public PaymentsController(IPaymentService paymentService, IPaymentMapper mapper)
        {
            _paymentService = paymentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PaymentDTO>> Get()
        {
            return new List<PaymentDTO>();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            Log.Logger.Information($"Get Payment for reference {id}");
            var gatewayResponse = await _paymentService.GetBy(id);

            if (gatewayResponse == null)
                return BadRequest("Reference is not identified.");

            var response = _mapper.ToPaymentDetailsDto(gatewayResponse);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PaymentProcessRequest request)
        {
            Log.Logger.Information($"Process Payment ");

            if (request == null)
                return BadRequest("requires payment information to process.");

            var domainRequestEntity = _mapper.ToDomainEntity(request);
            try
            {
                var result = await _paymentService.ProcessAsync(domainRequestEntity);

                return Ok(_mapper.ToPaymentProcessResponse(result));
            }
            catch (CardValidationException e)
            {
                Log.Error(e,"Request Failed.");
                return BadRequest(e.Message);
            }
        }
    }
}

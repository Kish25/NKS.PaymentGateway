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

    /// <summary>
    /// Payments 
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _gatewayService;
        private readonly IPaymentMapper _mapper;

        public PaymentsController(IPaymentService gatewayService, IPaymentMapper mapper)
        {
            _gatewayService = gatewayService;
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
            var gatewayResponse = await _gatewayService.GetBy(id);

            if (gatewayResponse == null)
            return NotFound("Reference is not identified.");

            var response = _mapper.ToPaymentDetailsDto(gatewayResponse);

            return Ok(response);
          
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PaymentProcessRequest request)
        {
            // map to domain object
            var mappedEntity = _mapper.ToDomainEntity(request);
            try
            {
                var result = await _gatewayService.ProcessAsync(mappedEntity);

                return Ok(_mapper.ToPaymentProcessResponse(result));
            }
            catch (CardValidationException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

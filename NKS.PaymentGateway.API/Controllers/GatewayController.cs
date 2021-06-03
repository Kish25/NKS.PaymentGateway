using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NKS.PaymentGateway.API.Contracts;
using NKS.PaymentGateway.API.Interfaces;
using NKS.PaymentGateway.API.Models;
using NKS.PaymentGateway.Core.Exceptions;
using Serilog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NKS.PaymentGateway.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class GatewayController : ControllerBase
    {
        private readonly IGatewayService _gatewayService;
        private readonly IPaymentMapper _mapper;

        public GatewayController(IGatewayService gatewayService, IPaymentMapper mapper)
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

            var response = _mapper.MaptoDetails(gatewayResponse);

            return Ok(response);
            return new PaymentDTO();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PaymentProcessRequest request)
        {
            // map to domain object
            _mapper.MaptoDomain(request);
            try
            {
                _gatewayService.ProcessAsync(request);

                return Ok(_mapper.MaptoDto());
            }
            catch (CardValidationException e)
            {
                return BadRequest(e.Message);
            }

            
            //process
            // map to dto 


            return new PaymentProcessResponse();
        }
    }
}

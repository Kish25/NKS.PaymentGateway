using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NKS.PaymentGateway.API.Contracts;
using NKS.PaymentGateway.API.Models;

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
        [HttpGet]
        public async Task<IEnumerable<PaymentDTO>> Get()
        {
            return new List<PaymentDTO>();
        }

        [HttpGet("{id}")]
        public async Task<PaymentDTO> Get(Guid id)
        {
            return new PaymentDTO();
        }

        [HttpPost]
        public PaymentProcessResponse Post([FromBody] PaymentProcessRequest request)
        {

            return new PaymentProcessResponse();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyService;

namespace MyWebClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreeterController : ControllerBase
    {
        private readonly Greeter.GreeterClient _client;

        public GreeterController(Greeter.GreeterClient client)
        {
            _client = client;
        }

        [HttpGet("{name}")]
        public async Task<string> GetGreeting(string name)
        {
            var reply = await _client.SayHelloAsync(new HelloRequest { Name = name });
            return reply.Message;
        }
    }
}

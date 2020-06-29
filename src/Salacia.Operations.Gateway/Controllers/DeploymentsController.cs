using System;
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;

namespace Salacia.Operations.Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeploymentsController : ControllerBase
    {
        private Greeter.GreeterClient client;

        public DeploymentsController(Greeter.GreeterClient client)
        {
            this.client = client;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var reply = await client.SayHelloAsync(new HelloRequest { Name = "GreeterClient" });

            return Ok(reply.Message);
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetAsync(Guid id)
        //{
        //    var deployment = await deploymentService.GetDeploymentAsync(id);

        //    return Ok(deployment);
        //}

        //[HttpPost]
        //public async Task<IActionResult> PostAsync([FromBody] CreateDeploymentCommand command)
        //{
        //    var deployment = await deploymentService.CreateDeploymentAsync(command);

        //    return CreatedAtRoute(new { id = deployment.Id }, deployment);
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutAsync(Guid id, [FromBody] UpdateDeploymentCommand command)
        //{
        //    if (id != command.Id)
        //        return BadRequest();

        //    await deploymentService.UpdateDeploymentAsync(command);

        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteAsync(Guid id)
        //{
        //    await deploymentService.DeleteDeploymentAsync(new DeleteDeploymentCommand { Id = id });

        //    return NoContent();
        //}
    }
}
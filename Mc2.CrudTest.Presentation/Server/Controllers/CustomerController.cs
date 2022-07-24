using Mc2.CrudTest.Application.Features.DeleteCustomerById;
using Mc2.CrudTest.Application.Features.GetCustomerById;
using Mc2.CrudTest.Application.Features.RegisterCustomer;
using Mc2.CrudTest.Application.Features.UpdateCustomer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterCustomer([FromBody] RegisterCustomerRequest request)
        {
            try
            {
                var customer = await _mediator.Send(new RegisterCustomerCommand(request.FirstName, request.LastName, request.DateOfBirth, request.PhoneNumber, request.Email, request.BankAccountNumber));

                return Created(string.Empty, customer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{guid}")]
        public async Task<IActionResult> Delete(Guid guid, [FromBody] UpdateCustomerRequest request)
        {
            try
            {
                var result = await _mediator.Send(new UpdateCustomerCommand(guid, request.FirstName, request.LastName, request.DateOfBirth, request.PhoneNumber, request.Email, request.BankAccountNumber));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{guid}")]
        public async Task<IActionResult> Get(Guid guid)
        {
            try
            {
                var customer = await _mediator.Send(new GetCustomerByIdQuery(guid));
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        [Route("{guid}")]
        public async Task<IActionResult> Delete(Guid guid)
        {
            try
            {
                var result = await _mediator.Send(new DeleteCustomerByIdCommand(guid));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

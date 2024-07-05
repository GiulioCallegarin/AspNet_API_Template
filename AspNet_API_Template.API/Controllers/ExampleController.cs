using AspNet_API_Template.Application.Examples;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AspNet_API_Template.API.Controllers;

public class ExampleController : Controller
{
    private readonly ISender _sender;
    public ExampleController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("")]
    public async Task<ActionResult<string>> GetExample()
    {
        return await _sender.Send(new GetExampleQuery());
    }
}

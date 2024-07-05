using AspNet_API_Template.Infrastructure.Data;
using AspNet_API_Template.Shared.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet_API_Template.Application.Examples;

public class GetExampleQuery: IRequest<String>
{
}

public class GetExampleQueryHandler : IRequestHandler<GetExampleQuery, string>
{
    private readonly ApplicationDbContext context;
    public GetExampleQueryHandler(ApplicationDbContext _context)
    {
        context = _context;
    }
    public async Task<string> Handle(GetExampleQuery request, CancellationToken cancellationToken)
    {
        var example = context.Examples.FirstOrDefault();
        if (example?.ExampleMessage != null)
            return example.ExampleMessage.Message;
        return "No examples found";
    }
}
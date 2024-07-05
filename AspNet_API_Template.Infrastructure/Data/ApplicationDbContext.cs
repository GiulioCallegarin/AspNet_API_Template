using AspNet_API_Template.Shared.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet_API_Template.Infrastructure.Data;

public class ApplicationDbContext: IdentityDbContext<User>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    { 
    }

    public virtual DbSet<Example> Examples { get; set; }
    public virtual DbSet<ExampleMessage> ExampleMessages { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        var exampleMessage = new ExampleMessage() { ExampleMessageId = Guid.NewGuid(), Message = "This is an example" };

        builder.Entity<ExampleMessage>().HasData(
            exampleMessage
        );

        builder.Entity<Example>().HasData(
            new Example() { ExampleId = Guid.NewGuid(), ExampleMessageId = exampleMessage.ExampleMessageId }
        );
    }
}

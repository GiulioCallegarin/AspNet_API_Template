using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet_API_Template.Shared.Entities;

public class Example
{
    public Guid ExampleId { get; set; }
    public Guid ExampleMessageId { get; set; } // Foreign Key
    public virtual ExampleMessage ExampleMessage { get; set; } // Reference navigation property
}

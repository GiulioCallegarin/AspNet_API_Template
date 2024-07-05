using System.ComponentModel.DataAnnotations;

namespace AspNet_API_Template.Shared.Entities;

public class ExampleMessage
{
    public Guid ExampleMessageId { get; set; }
    public string Message { get; set; }
    public virtual Example Example { get; set; } // Reference navigation property
}

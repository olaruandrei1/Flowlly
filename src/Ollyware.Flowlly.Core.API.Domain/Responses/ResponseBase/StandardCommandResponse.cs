namespace Ollyware.Flowlly.Core.API.Domain.Responses.ResponseBase;

public class StandardCommandResponse : BaseCommandResponse
{
    public Guid TaskId { get; set; }

    public override object RetrieveObject()
    => new { Success, Message, TaskId };
}

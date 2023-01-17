namespace API.Communication;

public class ErrorMessage
{

    List<object> errors { get; set; } = null;

    string Meessage { get; set; }

    public ErrorMessage(string message, IEnumerable<object>? errorMessages = null)
    {
        this.Meessage = message;

        if (errorMessages != null)
        {
            this.errors = errorMessages.ToList();
        }
    }

    public object GetError()
    {
        return new { Message = this.Meessage, Errors = this.errors };
    }
}

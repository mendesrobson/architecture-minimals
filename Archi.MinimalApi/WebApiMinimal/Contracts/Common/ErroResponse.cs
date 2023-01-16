namespace WebApiMinimal.Contracts.Common;

public class ErroResponse
{
    public ErroResponse()
    {
        Erros = new();

    }

    public int StatusCode { get; set; }
    public string StatusMessage { get; set; }
    public List<string> Erros { get; } = new();
    public DateTime Timestamp { get; set; }
}

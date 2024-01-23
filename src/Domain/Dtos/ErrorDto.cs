namespace Domain.Dtos;

public class ErrorDto
{
    public string Message { get; set; } = null!;
    public int StatusCode { get; set; }
}

namespace Domain.Dtos.Receptionists;

public class ReceptionistUpdateDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? MiddleName { get; set; }
    
    public int OfficeId { get; set; }
}

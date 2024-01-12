namespace Domain.Entities;

public class Receptionist
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? MiddleName { get; set; }
    
    public Guid AccountId { get; set; }
    public int OfficeId { get; set; }
}

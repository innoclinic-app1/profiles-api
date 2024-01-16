namespace Domain.Dtos.Patients;

public class PatientDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? MiddleName { get; set; }
    public DateOnly BirthDate { get; set; }
    
    public Guid? AccountId { get; set; }
}

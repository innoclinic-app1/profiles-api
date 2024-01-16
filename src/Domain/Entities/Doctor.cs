namespace Domain.Entities;

using Status = Enums.EmployeeStatus;

public class Doctor
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? MiddleName { get; set; }
    public Status Status { get; set; }
    public DateOnly BirthDate { get; set; }
    public int CareerStartYear { get; set; }

    public int OfficeId { get; set; }
    public Guid AccountId { get; set; }
    public int SpecializationId { get; set; }
}

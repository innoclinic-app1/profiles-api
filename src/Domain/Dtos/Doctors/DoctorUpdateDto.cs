﻿namespace Domain.Dtos.Doctors;

using Status = Enums.EmployeeStatus;

public class DoctorUpdateDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? MiddleName { get; set; }
    public Status Status { get; set; }
    public DateOnly BirthDate { get; set; }
    public int CareerStartYear { get; set; }

    public int OfficeId { get; set; }
    public int SpecializationId { get; set; }
}

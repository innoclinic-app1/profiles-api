﻿using Domain.Entities;
using Status = Domain.Enums.EmployeeStatus;

namespace Infrastructure.Interfaces.Repositories;

public interface IDoctorRepository : IBaseRepository<Doctor>
{
    Task ChangeStatusAsync(int id, Status status, CancellationToken cancellation = default);
    
    Task<IEnumerable<Doctor>> GetManyAsync(string name, int officeId, int specializationId, int skip, int take,
        CancellationToken cancellation = default);
}

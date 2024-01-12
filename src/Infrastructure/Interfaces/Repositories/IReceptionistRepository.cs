﻿using Domain.Entities;

namespace Infrastructure.Interfaces.Repositories;

public interface IReceptionistRepository : IBaseRepository<Receptionist>
{
    IQueryable<Receptionist> GetByName(string name);
}
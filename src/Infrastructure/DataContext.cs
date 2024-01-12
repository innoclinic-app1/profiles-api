using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Doctor> Doctors { get; set; } = null!;
    public DbSet<Patient> Patients { get; set; } = null!;
    public DbSet<Receptionist> Receptionists { get; set; } = null!;
}

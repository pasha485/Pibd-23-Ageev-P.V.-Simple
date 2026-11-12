using DentalClinic.Models;
using Microsoft.EntityFrameworkCore;

namespace DentalClinic.Data;

/// <summary>
/// Контекст базы данных для подключения к PostgreSQL.
/// </summary>
public class DataContext : DbContext
{
    // Свойства DbSet представляют собой таблицы в базе данных.
    // По ним Entity Framework поймет, какие таблицы нужно создать.
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<AppointmentService> AppointmentServices { get; set; }

    /// <summary>
    /// Здесь мы настраиваем строку подключения к базе данных.
    /// </summary>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=DentalClinicDb;Username=postgres;Password=limon4ik");
    }

    /// <summary>
    /// Здесь мы настраиваем связи между таблицами (Fluent API).
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // 1. Связь Один-ко-многим: Пациент -> Приёмы
        // Один пациент может иметь много приёмов, но каждый приём принадлежит одному пациенту.
        modelBuilder.Entity<Appointment>()
            .HasOne<Patient>()
            .WithMany()
            .HasForeignKey(a => a.PatientId);

        // 2. Связь Один-ко-многим: Врач -> Приёмы
        // Один врач ведет много приёмов.
        modelBuilder.Entity<Appointment>()
            .HasOne<Doctor>()
            .WithMany()
            .HasForeignKey(a => a.DoctorId);

        // 3. Связь Многие-ко-многим: Приём <-> Услуги (через AppointmentService)
        // У одного приёма может быть много услуг, и одна услуга может быть на многих приёмах.

        // Связка с Приёмом
        modelBuilder.Entity<AppointmentService>()
            .HasOne<Appointment>()
            .WithMany()
            .HasForeignKey(x => x.AppointmentId);

        // Связка с Услугой
        modelBuilder.Entity<AppointmentService>()
            .HasOne<Service>()
            .WithMany()
            .HasForeignKey(x => x.ServiceId);

        base.OnModelCreating(modelBuilder);
    }
}
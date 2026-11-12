using DentalClinic.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DentalClinic.Data;

/// <summary>
/// Контекст базы данных для подключения к PostgreSQL.
/// </summary>
public class DataContext : DbContext
{
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<AppointmentService> AppointmentServices { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Отключаем строгую проверку UTC для PostgreSQL (чтобы даты не падали)
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=DentalClinicDb;Username=postgres;Password=limon4ik");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // 1. Один-ко-многим: Пациент -> Приёмы
        modelBuilder.Entity<Appointment>()
            .HasOne<Patient>()
            .WithMany()
            .HasForeignKey(a => a.PatientId)
            .OnDelete(DeleteBehavior.Restrict);

        // 2. Один-ко-многим: Врач -> Приёмы
        modelBuilder.Entity<Appointment>()
            .HasOne<Doctor>()
            .WithMany()
            .HasForeignKey(a => a.DoctorId)
            .OnDelete(DeleteBehavior.Restrict);

        // 3. Многие-ко-многим: Приём <-> Услуги
        modelBuilder.Entity<AppointmentService>()
            .HasOne<Appointment>()
            .WithMany()
            .HasForeignKey(x => x.AppointmentId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<AppointmentService>()
            .HasOne<Service>()
            .WithMany()
            .HasForeignKey(x => x.ServiceId)
            .OnDelete(DeleteBehavior.Restrict);

        base.OnModelCreating(modelBuilder);
    }
}
using Guia6_EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class Context : DbContext
{

    public DbSet<EstudianteUNAB> Estudiante { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-E6P6QHE\\SQLEXPRESS;Database=Program2;Trusted_Connection=True;");
        }
    }
}
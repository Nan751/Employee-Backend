using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Emp.Models;

public partial class EmployeeContext : DbContext
{
    public EmployeeContext()
    {
    }

    public EmployeeContext(DbContextOptions<EmployeeContext> options)
        : base(options)
    {
    }

   
    public virtual DbSet<TbEmployee> TbEmployees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{

}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
        modelBuilder.Entity<TbEmployee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_Emplo__3214EC07566220C0");

            entity.ToTable("tb_Employee");

            entity.Property(e => e.Basic)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Ctc)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("CTC");
            entity.Property(e => e.EmployeeCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Lta)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LTA");
            entity.Property(e => e.Medical).IsUnicode(false);
            entity.Property(e => e.Pf)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Spiallowance)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SPIAllowance");
            entity.Property(e => e.Telephone).IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

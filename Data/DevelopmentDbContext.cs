using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AspDotNetCoreMvcApp.Data;

public partial class DevelopmentDbContext : DbContext
{
    public DevelopmentDbContext()
    {
    }

    public DevelopmentDbContext(DbContextOptions<DevelopmentDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Name=SqliteConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

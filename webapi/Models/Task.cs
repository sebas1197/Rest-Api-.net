using Microsoft.EntityFrameworkCore;


public class Tasks : DbContext
{
    public Tasks(DbContextOptions<Tasks> options) : base(options)
    {

    }

    public DbSet<ModelTask> Tasks2 => Set<ModelTask>();

            protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ModelTask>()
            .HasKey(e => e.id);
    }
}


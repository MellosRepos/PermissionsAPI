using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;




namespace Infrastructure.Data
{
    public class SQLServerDBContext : DbContext
    {

        public SQLServerDBContext(DbContextOptions<SQLServerDBContext> options) : base(options)
        {

        }
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SQLServerDBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        public DbSet<Permissions> Permissions { get; set; }
        public DbSet<PermissionTypes> PermissionTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permissions>(entity =>
            {
                entity.ToTable("Permission", "dbo");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.EmployeeFirstName).HasColumnName("EMPLOYEE_FIRST_NAME");
                entity.Property(e => e.EmployeeLastName).HasColumnName("EMPLOYEE_LAST_NAME");
                entity.Property(e => e.PermissionDate).HasColumnName("PERMISSION_DATE");
                entity.Property(e => e.PermissionTypeId).HasColumnName("TYPE_ID");
                    
            });
            modelBuilder.Entity<PermissionTypes>(entity =>
            {
                entity.ToTable("PermissionType", "dbo");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Description).HasColumnName("DESCRIPTION");

            });
        }
    }
}
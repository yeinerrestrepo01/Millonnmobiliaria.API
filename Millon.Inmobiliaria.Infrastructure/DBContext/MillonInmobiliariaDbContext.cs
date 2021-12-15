using Microsoft.EntityFrameworkCore;
using Millon.Inmobiliaria.Domain.Entities;

namespace Millon.Inmobiliaria.Infrastructure.DBContext
{
    /// <summary>
    /// Clase para creacion de contexto de base de datos
    /// </summary>
    public partial class MillonInmobiliariaDbContext: DbContext
    {
        /// <summary>
        /// Inicializador de <class>MillonInmobiliariaDBContext</class>
        /// </summary>
        public MillonInmobiliariaDbContext()
        {
        }

        /// <summary>
        /// Inicializador de <class>MillonInmobiliariaDBContext</class>
        /// </summary>
        /// <param name="options">options</param>
        public MillonInmobiliariaDbContext(DbContextOptions<MillonInmobiliariaDbContext> options)
            :base(options)
        {
        }

        public virtual DbSet<Owner> Owner { get; set; }
        public virtual DbSet<Property> Property { get; set; }
        public virtual DbSet<PropertyImage> PropertyImage { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=caselink-uat.cnv0nwwl9cp4.us-east-1.rds.amazonaws.com;Database=CASELINK;Trusted_Connection=False;User=sysSuper;password=Key12DG!;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            OnModelCreatingPartial(modelBuilder);

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

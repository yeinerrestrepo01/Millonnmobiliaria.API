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
        public virtual DbSet<PropertyTrace> PropertyTrace { get; set; }
        public virtual DbSet<MoneyType> MoneyType { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LAPTOP-K991GUOR;Database=Millon;Trusted_Connection=False;User=sa;password=Complemento$0912;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            OnModelCreatingPartial(modelBuilder);

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

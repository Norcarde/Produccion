namespace Produccion.Web.Data
{
    using Microsoft.EntityFrameworkCore;
    using Produccion.Web.Data.Entities;

    public class DataContext: DbContext
    {
        public DbSet<Administradora> Administradoras { get; set; }
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {

        }
    }
}

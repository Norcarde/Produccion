namespace Produccion.Web.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;

    public class Repository : IRepository
    {
        private readonly DataContext context;

        public Repository(DataContext context)
        {
            this.context = context;
        }

        public IEnumerable<Administradora> GetAdministradoras()
        {
            return this.context.Administradoras.OrderBy(a => a.NombreAdministradora);
        }

        public Administradora GetAdministradora(int id)
        {
            return this.context.Administradoras.Find(id);
        }

        public void AddAdministradora(Administradora administradora)
        {
            this.context.Administradoras.Add(administradora);
        }

        public void UpdateAdministradora(Administradora administradora)
        {
            this.context.Update(administradora);
        }

        public void RemoveAdministradora(Administradora administradora)
        {
            this.context.Administradoras.Remove(administradora);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await this.context.SaveChangesAsync() > 0;
        }

        public bool AdministradoraExists(int id)
        {
            return this.context.Administradoras.Any(a => a.Id == id);
        }
    }
}

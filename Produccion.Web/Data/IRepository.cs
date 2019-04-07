namespace Produccion.Web.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Entities;
    public interface IRepository
    {
        void AddAdministradora(Administradora administradora);

        bool AdministradoraExists(int id);

        Administradora GetAdministradora(int id);

        IEnumerable<Administradora> GetAdministradoras();

        void RemoveAdministradora(Administradora administradora);

        Task<bool> SaveAllAsync();

        void UpdateAdministradora(Administradora administradora);
    }
}
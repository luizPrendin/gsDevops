using GS.Models;

namespace GS.Persistencia.Interfaces
{
    public interface IUsuarioRepositorio
    {
        IEnumerable<Usuario> GetAll();

        Usuario GetById(int? id);

        void Add(Usuario usuario);

        void Update(Usuario usuario);

        void Delete(Usuario usuario);
    }
}

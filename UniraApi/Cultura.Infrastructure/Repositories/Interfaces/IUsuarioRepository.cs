using Cultura.Domain.Entities;

namespace Cultura.Infrastructure.Interfaces.Repositorio
{
    public interface IUsuarioRepository
    {
        Task CreateUsuario(Usuario usuario); 

        Task<Usuario> GetUsuarioById(int id);

        Task<bool> UpdateUsuario(Usuario usuario);

        Task<Usuario> LoginValidation(string email, string senha);
    }
}

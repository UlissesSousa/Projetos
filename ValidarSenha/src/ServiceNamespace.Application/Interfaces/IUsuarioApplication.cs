using ServiceNamespace.Application.Models;
using ServiceNamespace.Domain.Entities;

namespace ServiceNamespace.Application.Interfaces
{
    public interface IUsuarioApplication
    {
        Result<Usuario> Salvar(UsuarioPostModel usuarioModel);
    }
}

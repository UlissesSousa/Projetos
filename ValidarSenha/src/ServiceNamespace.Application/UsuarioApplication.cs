using AutoMapper;
using ServiceNamespace.Application.Interfaces;
using ServiceNamespace.Application.Models;
using ServiceNamespace.Domain.Entities;

namespace ServiceNamespace.Application
{
    public class UsuarioApplication : IUsuarioApplication
    {
        private readonly IMapper _mapper;
        public UsuarioApplication(IMapper mapper)
        {
            _mapper = mapper;
        }
        public Result<Usuario> Salvar(UsuarioPostModel usuarioModel)
        {
            var usuario = _mapper.Map<UsuarioPostModel, Usuario>(usuarioModel);
            if (usuario.Valid) 
            {
                return Result<Usuario>.Ok(usuario);
            }
            return Result<Usuario>.Error(usuario.Notifications);
        }
    }
}

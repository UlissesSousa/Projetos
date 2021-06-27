using ServiceNamespace.Domain.ValueObjects;
using Flunt.Validations;
using ServiceNamespace.Domain.Core.Entities;

namespace ServiceNamespace.Domain.Entities
{
    public class Usuario : Entity
    {
        public Usuario(Senha senha) 
        {
            Senha = senha;
            AddNotifications(new Contract()
            .Requires()
            .IsNotNull(Senha, nameof(Senha), "Nome não pode ser nulo"));


            if (Senha != null )
                AddNotifications(Senha);

            
        }
        public Senha Senha { get; private set; }

    }
}

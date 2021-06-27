using ServiceNamespace.Domain.Entities;
using ServiceNamespace.Domain.ValueObjects;
using Xunit;

namespace ServiceNamespace.Tests.Domain
{
    public class UsuarioTest
    {
        [Theory]
        [InlineData("")]
        [InlineData("aa")]
        [InlineData("ab")]
        [InlineData("AAAbbbCc")]
        [InlineData("AcZp7*baa")]
        [InlineData("AcZp7*baAr")]
        [InlineData("AcZp7 bar")]
        public void ValidarUsuario_UsuarioInvalido_Test(string senha) 
        {
            var usuario = new Usuario(new Senha(senha));
            Assert.True(usuario.Invalid);
            Assert.Contains(usuario.Notifications, n => n.Property == nameof(Usuario.Senha.Valor));
        }
        [Fact]
        public void ValidarUsuario_UsuarioValido_Test() 
        {
            var usuario = new Usuario(new Senha("AcZp7*bar"));
            Assert.True(usuario.Valid);
        }
        [Fact]
        public void ValidarUsuario_UsuarioInvalido_Nulo_Test()
        {
            var usuario = new Usuario(null);
            Assert.True(usuario.Invalid);
            Assert.Contains(usuario.Notifications, n => n.Property == nameof(Usuario.Senha));
        }
    }
}

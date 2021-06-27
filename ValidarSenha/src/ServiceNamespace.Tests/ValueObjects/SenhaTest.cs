using ServiceNamespace.Domain.ValueObjects;
using Xunit;

namespace ServiceNamespace.Tests.ValueObjects
{
    public class SenhaTest
    {
        [Fact]
        public void CriarSenhaValida() 
        {
            var senha = new Senha("AcZp7*bar");
            Assert.True(senha.Valid);
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("aa")]
        [InlineData("ab")]
        [InlineData("AAAbbbCc")]
        [InlineData("AcZp7*baa")]
        [InlineData("AcZp7*baAr")]
        [InlineData("AcZp7 bar")]
        public void CriarSenhaInvalida(string senhas) 
        {
            var senha = new Senha(senhas);
            Assert.True(senha.Invalid);
            Assert.Contains(senha.Notifications,n => n.Property == nameof(Senha.Valor));
        }
    }
}

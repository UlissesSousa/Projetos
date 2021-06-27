using Microsoft.AspNetCore.Mvc;
using ServiceNamespace.Api.Controllers;
using ServiceNamespace.Application;
using ServiceNamespace.Application.Models;
using ServiceNamespace.Tests.Fixtures;
using Xunit;

namespace ServiceNamespace.Tests.Controllers
{
    [Collection("Mapper")]
    public class UsuarioControllerTest
    {
        private readonly MapperFixture _mapperFixture;
        public UsuarioControllerTest(MapperFixture mapperFixture)
        {
            _mapperFixture = mapperFixture;
        }

        [Fact]
        public void TestSenhaSucesso()
        {
            var usuario = new UsuarioPostModel() { Senha = "AcZp7*bar" };
            var controller = CreateClienteController();
            var result = controller.Validar(usuario);
            Assert.IsType<OkObjectResult>(result);
        }
        [Theory]
        [InlineData("")]
        [InlineData("aa")]
        [InlineData("ab")]
        [InlineData("AAAbbbCc")]
        [InlineData("AcZp7*baa")]
        [InlineData("AcZp7*baAr")]
        [InlineData("AcZp7 bar")]
        public void TestSenhaFalha(string senha)
        {
            var usuario = new UsuarioPostModel() { Senha = senha };
            var controller = CreateClienteController();
            var result = controller.Validar(usuario);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        private UsuarioController CreateClienteController()
        {
            var usuarioApplication = new UsuarioApplication(_mapperFixture.Mapper);

            return new UsuarioController(usuarioApplication);
        }


    }
}

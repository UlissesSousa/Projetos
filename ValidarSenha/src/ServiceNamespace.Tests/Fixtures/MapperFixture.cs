using AutoMapper;

namespace ServiceNamespace.Tests.Fixtures
{
    public class MapperFixture
    {
        public IMapper Mapper { get; }

        public MapperFixture()
        {
            var config = new MapperConfiguration(opts =>
            {
                opts.AddProfile(new Application.Mapping.UsuarioMap());
            });

            Mapper = config.CreateMapper();
        }
    }
}

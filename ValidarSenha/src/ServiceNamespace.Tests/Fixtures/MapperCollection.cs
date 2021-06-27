using Xunit;

namespace ServiceNamespace.Tests.Fixtures
{
    [CollectionDefinition("Mapper")]
    public class MapperCollection : ICollectionFixture<MapperFixture>
    {
    }
}

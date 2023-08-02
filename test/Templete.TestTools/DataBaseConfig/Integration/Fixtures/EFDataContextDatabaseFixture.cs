using Templete.Persistanse.EF;
using Xunit;

namespace Templete.TestTools.DataBaseConfig.Integration.
    Fixtures;

[Collection(nameof(ConfigurationFixture))]
public class EFDataContextDatabaseFixture : DatabaseFixture
{
    protected static EFDataContext CreateDataContext(string tenantId)
    {
        var connectionString =
            new ConfigurationFixture().Value.ConnectionString;

        
        return new EFDataContext(connectionString);
    }
}
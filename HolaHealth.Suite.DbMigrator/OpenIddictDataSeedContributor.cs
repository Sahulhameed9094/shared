using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace HolaHealth.Suite.DbMigrator;

public class OpenIddictDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly OpenIddictDataSeeder _openIddictDataSeeder;

    public OpenIddictDataSeedContributor(OpenIddictDataSeeder openIddictDataSeeder)
    {
        _openIddictDataSeeder = openIddictDataSeeder;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        await _openIddictDataSeeder.SeedAsync();
    }
}

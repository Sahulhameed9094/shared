using HolaHealth.Suite.AdministrationService;
using HolaHealth.Suite.AdministrationService.EntityFrameworkCore;
using HolaHealth.Suite.IdentityService;
using HolaHealth.Suite.IdentityService.EntityFrameworkCore;
using HolaHealth.Suite.ProductService;
using HolaHealth.Suite.ProductService.EntityFrameworkCore;
using HolaHealth.Suite.SaasService;
using HolaHealth.Suite.SaasService.EntityFrameworkCore;
using HolaHealth.Suite.Shared.Hosting;
using Volo.Abp.Modularity;
using Volo.Abp.Caching;
using Volo.Abp.Caching.StackExchangeRedis;
using System;
using Volo.Abp.Timing;
using HolaHealth.Suite.OrderService;
using HolaHealth.Suite.OrderService.EntityFrameworkCore;

namespace HolaHealth.Suite.DbMigrator;

[DependsOn(
    typeof(AbpCachingStackExchangeRedisModule),
    typeof(SuiteSharedHostingModule),
    typeof(IdentityServiceEntityFrameworkCoreModule),
    typeof(IdentityServiceApplicationContractsModule),
    typeof(SaasServiceEntityFrameworkCoreModule),
    typeof(SaasServiceApplicationContractsModule),
    typeof(AdministrationServiceEntityFrameworkCoreModule),
    typeof(AdministrationServiceApplicationContractsModule),
    typeof(ProductServiceApplicationContractsModule),
    typeof(ProductServiceEntityFrameworkCoreModule),
     typeof(OrderServiceApplicationContractsModule),
    typeof(OrderServiceEntityFrameworkCoreModule)
)]
public class SuiteDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpDistributedCacheOptions>(options => { options.KeyPrefix = "Suite:"; });

        //issue Fix for Cannot write DateTime with Kind=Local to PostgreSQL type 'timestamp with time zone
        Configure<AbpClockOptions>(options =>
        {
            options.Kind = DateTimeKind.Utc;
        });
    }
}

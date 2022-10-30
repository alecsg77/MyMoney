using AlecsG77.MyMoney.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace AlecsG77.MyMoney.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(MyMoneyEntityFrameworkCoreModule),
    typeof(MyMoneyApplicationContractsModule)
    )]
public class MyMoneyDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}

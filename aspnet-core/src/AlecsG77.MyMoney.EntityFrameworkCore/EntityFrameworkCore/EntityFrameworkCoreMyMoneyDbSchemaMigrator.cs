using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AlecsG77.MyMoney.Data;
using Volo.Abp.DependencyInjection;

namespace AlecsG77.MyMoney.EntityFrameworkCore;

public class EntityFrameworkCoreMyMoneyDbSchemaMigrator
    : IMyMoneyDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreMyMoneyDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the MyMoneyDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<MyMoneyDbContext>()
            .Database
            .MigrateAsync();
    }
}

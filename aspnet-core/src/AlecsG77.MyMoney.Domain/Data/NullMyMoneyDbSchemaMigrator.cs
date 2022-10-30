using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AlecsG77.MyMoney.Data;

/* This is used if database provider does't define
 * IMyMoneyDbSchemaMigrator implementation.
 */
public class NullMyMoneyDbSchemaMigrator : IMyMoneyDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}

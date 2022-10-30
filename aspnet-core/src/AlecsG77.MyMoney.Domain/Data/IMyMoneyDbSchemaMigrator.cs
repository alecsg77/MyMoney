using System.Threading.Tasks;

namespace AlecsG77.MyMoney.Data;

public interface IMyMoneyDbSchemaMigrator
{
    Task MigrateAsync();
}

using AlecsG77.MyMoney.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AlecsG77.MyMoney;

[DependsOn(
    typeof(MyMoneyEntityFrameworkCoreTestModule)
    )]
public class MyMoneyDomainTestModule : AbpModule
{

}

using Volo.Abp.Modularity;

namespace AlecsG77.MyMoney;

[DependsOn(
    typeof(MyMoneyApplicationModule),
    typeof(MyMoneyDomainTestModule)
    )]
public class MyMoneyApplicationTestModule : AbpModule
{

}

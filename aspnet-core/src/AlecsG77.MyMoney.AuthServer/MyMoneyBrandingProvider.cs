using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace AlecsG77.MyMoney;

[Dependency(ReplaceServices = true)]
public class MyMoneyBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "MyMoney";
}

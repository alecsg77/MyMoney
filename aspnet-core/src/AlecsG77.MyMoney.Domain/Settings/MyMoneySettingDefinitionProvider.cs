using Volo.Abp.Settings;

namespace AlecsG77.MyMoney.Settings;

public class MyMoneySettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(MyMoneySettings.MySetting1));
    }
}

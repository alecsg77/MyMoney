using AlecsG77.MyMoney.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AlecsG77.MyMoney.Permissions;

public class MyMoneyPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(MyMoneyPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(MyMoneyPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<MyMoneyResource>(name);
    }
}

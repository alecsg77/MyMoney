using AlecsG77.MyMoney.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AlecsG77.MyMoney.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class MyMoneyController : AbpControllerBase
{
    protected MyMoneyController()
    {
        LocalizationResource = typeof(MyMoneyResource);
    }
}

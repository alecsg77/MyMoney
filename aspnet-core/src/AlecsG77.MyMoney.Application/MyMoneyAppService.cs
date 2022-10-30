using System;
using System.Collections.Generic;
using System.Text;
using AlecsG77.MyMoney.Localization;
using Volo.Abp.Application.Services;

namespace AlecsG77.MyMoney;

/* Inherit your application services from this class.
 */
public abstract class MyMoneyAppService : ApplicationService
{
    protected MyMoneyAppService()
    {
        LocalizationResource = typeof(MyMoneyResource);
    }
}

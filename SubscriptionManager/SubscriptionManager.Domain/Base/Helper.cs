using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionManager.Domain.Base
{
    public static class Helper
    {
        public static DateTime GetDefaultExpiresDate()
        {
            return new DateTime(2099, 12, 31).ToUniversalTime();
        }
    }
}

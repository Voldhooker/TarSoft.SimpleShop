using System;
using System.Collections.Specialized;
using System.Configuration;

namespace TarSoft.SimpleShop.Core
{
    public class ShopSettings
    {
        public static TimeSpan CookieExpiration
        {
            get
            {
                return GetConfigurationValue("CookieExpiration", new TimeSpan(30));
            }
        }

        private static T GetConfigurationValue<T>(string alias, T defaultValue)
        {
            object parsedValue;
            try
            {
                var section = ConfigurationManager.GetSection("shopSettings") as NameValueCollection;
                string settingValue = null;
                if (section != null)
                {
                    settingValue = section[alias] ?? null;
                }
                parsedValue = Convert.ChangeType(settingValue, typeof(T));
                if (parsedValue == null)
                    parsedValue = defaultValue;
            }
            catch (Exception)
            {
                parsedValue = defaultValue;
            }

            return (T)parsedValue;
        }
    }
}

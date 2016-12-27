using Rocket.API;
using System;

namespace NokautBR.ShopList
{
    public class ShopListConfiguration : IRocketPluginConfiguration
    {
        public bool Enable;

        public void LoadDefaults()
        {
            Enable = true;
        }
    }
}

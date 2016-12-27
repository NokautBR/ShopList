using Rocket.API.Collections;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;

namespace NokautBR.ShopList
{
    public class ShopList : RocketPlugin<ShopListConfiguration>
    {
        public static ShopList Instance;

        public override TranslationList DefaultTranslations
        {
            get
            {
                return new TranslationList()
                {
                    {
                        "list_command_usage",
                        "Usage: /list to show all itens avaliables in shop"
                    },
                    {
                        "list_command_show_all",
                        "Items list from shop:"
                    },
                };
            }
        }

        protected override void Load()
        {
            Instance = this;
        }
    }
}

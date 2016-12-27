using Rocket.API;
using Rocket.Core.Logging;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NokautBR.ShopList
{
    public class CommandList : IRocketCommand
    {
        public List<string> Aliases
        {
            get
            {
                return new List<string>();
            }
        }

        public AllowedCaller AllowedCaller
        {
            get
            {
                return AllowedCaller.Player;
            }
        }

        public string Help
        {
            get
            {
                return "Shows all items stored in shop";
            }
        }

        public string Name
        {
            get
            {
                return "list";
            }
        }

        public List<string> Permissions
        {
            get
            {
                return new List<string>();
            }
        }

        public string Syntax
        {
            get
            {
                return "";
            }
        }

        public void Execute(IRocketPlayer caller, string[] command)
        {
            DatabaseReader database = new DatabaseReader();
            string[] items = database.GetAllItems();
            UnturnedChat.Say(caller,
                ShopList.Instance.Translations.Instance.Translate("list_command_show_all"));
            foreach (string i in items)
            {
                UnturnedChat.Say(caller,i);
            }
            
        }
    }
}

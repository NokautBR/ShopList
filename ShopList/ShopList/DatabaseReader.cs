using fr34kyn01535.Uconomy;
using MySql.Data.MySqlClient;
using Rocket.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaupShop;

namespace NokautBR.ShopList
{
    public class DatabaseReader
    {

        private MySqlConnection createConnection()

        {

            MySqlConnection mySqlConnection = null;

            try

            {

                if (Uconomy.Instance.Configuration.Instance.DatabasePort == 0)

                {

                    Uconomy.Instance.Configuration.Instance.DatabasePort = 3306;

                }

                mySqlConnection = new MySqlConnection(string.Format("SERVER={0};DATABASE={1};UID={2};PASSWORD={3};PORT={4};", new object[] {

                    Uconomy.Instance.Configuration.Instance.DatabaseAddress,

                    Uconomy.Instance.Configuration.Instance.DatabaseName,

                    Uconomy.Instance.Configuration.Instance.DatabaseUsername,

                    Uconomy.Instance.Configuration.Instance.DatabasePassword,

                    Uconomy.Instance.Configuration.Instance.DatabasePort}));

            }

            catch (Exception exception)

            {

                Logger.LogException(exception);

            }
            return mySqlConnection;

        }

        public DatabaseReader()
        {
        }

        public string[] GetAllItems()
        {
            List<string> items = new List<string>();

            try
            {
                ZaupShopConfiguration zaup = new ZaupShopConfiguration();
                zaup.LoadDefaults();
                MySqlConnection mySqlConnection = this.createConnection();
                MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
                mySqlCommand.CommandText = string.Concat(new string[] {
                    "select itemname, cost from ",
                    zaup.ItemShopTableName,
                    ";"
                });
                mySqlConnection.Open();
                MySqlDataReader reader = mySqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while(reader.Read())
                    {
                        items.Add(reader.GetString(0) + " = " + reader.GetDecimal(1));
                    }
                }
                reader.Close();
                mySqlConnection.Close();
                
            }
            catch (Exception exception)

            {
                Logger.LogException(exception);

            }

            return items.ToArray();
        }

    }
}

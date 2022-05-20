using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

using System.Threading.Tasks;

using Newtonsoft.Json;

using MySql.Data.MySqlClient;

namespace the_Cryptocurrencies_bot
{
    public class API
    {
        static async Task Main(string[] args)
        {
            ConeccionAPI api = new ConeccionAPI();
            var botClient = new TelegramBotClient("5334575224:AAG2ZDMcPJidtBydNDdqz8PQh2IVPLSGv_4");
            var chatID = "@CryptosWorldTrading";
            Chequeo abc = new Chequeo();

            int length = await api.Lenght();
            List<string> symbol = await api.APISymbol();
            List<string> price = await api.APIPrice();
            List<string> change = await api.APIChangeRate();
            List<string> low = await api.APILow();
            List<string> high = await api.APIHigh();

            List<string> usdt = new List<string>();
            List<string> priceUsdt = new List<string>();
            List<string> changeUsdt = new List<string>();
            List<string> lowUsdt = new List<string>();
            List<string> highUsdt = new List<string>();

            for (int i = 0; i < symbol.Count; i++)
            {
                string symbol2 = symbol[i];
                string price2 = price[i];
                string change2 = change[i];
                string low2 = low[i];
                string high2 = high[i];

                if (symbol2 == "ETH-USDT" || symbol2 == "BNB-USDT" || symbol2 == "XRP-USDT" || symbol2 == "LTC-USDT" ||
                            symbol2 == "ADA-USDT" || symbol2 == "SOL-USDT" || symbol2 == "DOGE-USDT" || symbol2 == "DOT-USDT" ||
                            symbol2 == "AVAX-USDT" || symbol2 == "TRX-USDT" || symbol2 == "SHIB-USDT" || symbol2 == "MATIC-USDT" ||
                            symbol2 == "CRO-USDT" || symbol2 == "NEAR-USDT" || symbol2 == "FTT-USDT" || symbol2 == "UNI-USDT" ||
                            symbol2 == "BCH-USDT" || symbol2 == "LINK-USDT" || symbol2 == "XLM-USDT" || symbol2 == "ATOM-USDT" ||
                            symbol2 == "ALGO-USDT" || symbol2 == "XMR-USDT" || symbol2 == "APE-USDT" || symbol2 == "MANA-USDT" ||
                            symbol2 == "VET-USDT" || symbol2 == "ICP-USDT" || symbol2 == "FIL-USDT" || symbol2 == "SAND-USDT" ||
                            symbol2 == "XTZ-USDT" || symbol2 == "KCS-USDT" || symbol2 == "CAKE-USDT" || symbol2 == "AXS-USDT" ||
                            symbol2 == "EOS-USDT" || symbol2 == "THETA-USDT" || symbol2 == "AAVE-USDT" || symbol2 == "HT-USDT" ||
                            symbol2 == "BTT-USDT" || symbol2 == "IOTA-USDT" || symbol2 == "NEO-USDT" || symbol2 == "WAVES-USDT" ||
                            symbol2 == "KSM-USDT" || symbol2 == "DASH-USDT" || symbol2 == "DASH-USDT" || symbol2 == "ENJ-USDT" ||
                            symbol2 == "XEM-USDT" || symbol2 == "KDA-USDT" || symbol2 == "KAVA-USDT" || symbol2 == "1INCH-USDT" ||
                            symbol2 == "YFI-USDT" || symbol2 == "ROSE-USDT" || symbol2 == "OMG-USDT" || symbol2 == "SNX-USDT" ||
                            symbol2 == "UMA-USDT" || symbol2 == "DGB-USDT" || symbol2 == "SUSHI-USDT" || symbol2 == "DAG-USDT" ||
                            symbol2 == "OCEAN-USDT" || symbol2 == "COTI-USDT" || symbol2 == "DAO-USDT" || symbol2 == "DFI-USDT" ||
                            symbol2 == "LUNA-USDT" || symbol2 == "MOVR-USDT" || symbol2 == "EWT-USDT" || symbol2 == "API3-USDT" ||
                            symbol2 == "BLOK-USDT" || symbol2 == "POLS-USDT" || symbol2 == "KAI-USDT" || symbol2 == "ORN-USDT" ||
                            symbol2 == "RMRK-USDT" || symbol2 == "DIA-USDT" || symbol2 == "SFP-USDT" || symbol2 == "AVA-USDT" ||
                            symbol2 == "VRA-USDT" || symbol2 == "PHA-USDT" || symbol2 == "ANC-USDT" || symbol2 == "HYDRA-USDT" ||
                            symbol2 == "BOSON-USDT" || symbol2 == "WILD-USDT" || symbol2 == "VELO-USDT" || symbol2 == "CUDOS-USDT" ||
                            symbol2 == "SLP-USDT" || symbol2 == "MAP-USDT" || symbol2 == "SDN-USDT" || symbol2 == "MIR-USDT" ||
                            symbol2 == "AKRO-USDT" || symbol2 == "KAR-USDT" || symbol2 == "BOA-USDT" || symbol2 == "NIM-USDT" ||
                            symbol2 == "GO-USDT" || symbol2 == "PDEX-USDT" || symbol2 == "DEGO-USDT" || symbol2 == "ORAI-USDT" ||
                            symbol2 == "SYLO-USDT" || symbol2 == "POLK-USDT" || symbol2 == "BOLT-USDT" || symbol2 == "CAS-USDT")
                {
                    usdt.Add(symbol2);
                    priceUsdt.Add(price2);
                    changeUsdt.Add(change2);
                    lowUsdt.Add(low2);
                    highUsdt.Add(high2);
                }
            }

            string connStr = "server=db-mysql-nyc1-93924-do-user-11577020-0.b.db.ondigitalocean.com" +
                ";user=doadmin;database=defaultdb;port=25060;password=AVNS_CcBsQVuaJUyWIET";

            MySqlConnection conn = new MySqlConnection(connStr);
            MySqlConnection conn2 = new MySqlConnection(connStr);
            //MySqlConnection conn3 = new MySqlConnection(connStr);
            MySqlConnection conn8 = new MySqlConnection(connStr);
            MySqlConnection conn9 = new MySqlConnection(connStr);

            conn8.Open();
            string sql8 = $"SELECT * from Main;";
            MySqlCommand cmd8 = new MySqlCommand(sql8, conn8);
            MySqlDataReader rdr8 = cmd8.ExecuteReader();

            List<string> strings = new List<string>();
            while (rdr8.Read())
            {
                strings.Add((string)rdr8[1]);
            }


            for (int s = 0; s < usdt.Count; s++)
            {
                bool presente = false;

                for (int o = 0; o < strings.Count; o++)
                {
                    if (usdt[s] == strings[o])
                    {
                        presente = true;
                        o = strings.Count;
                    }

                }
                if (presente == false)
                {
                    conn9.Open();
                    string sql9 = $"INSERT INTO Main (crypto, plusdiez, plusveinte, plustreinta" +
                        $", mainnesdiez, mainnesveinte, mainnestreinta) values('{usdt[s]}', 0, 0, 0, 0, 0, 0);";
                    MySqlCommand cmd9 = new MySqlCommand(sql9, conn9);
                    MySqlDataReader rdr9 = cmd9.ExecuteReader();
                    rdr9.Close();
                    conn9.Close();

                    conn9.Open();
                    sql9 = $"SELECT * from Main WHERE crypto = '{usdt[s]}';";
                    cmd9 = new MySqlCommand(sql9, conn9);
                    rdr9 = cmd9.ExecuteReader();
                    int id9 = 0;
                    if (rdr9.Read())
                    {
                        id9 = (int)rdr9[0];
                    }
                    rdr9.Close();
                    conn9.Close();

                    conn9.Open();
                    sql9 = $"INSERT INTO Datetime (id, day, hour) values ({id9}, 0, 0);";
                    cmd9 = new MySqlCommand(sql9, conn9);
                    rdr9 = cmd9.ExecuteReader();
                    rdr9.Close();
                    conn9.Close();
                }
            }
            rdr8.Close();
            conn8.Close();

            decimal z = 0;

            //int u = 0;
            //for (int b = 0; b < usdt.Count; b++)
            //{
            //    Console.WriteLine($"{usdt[b]},  {priceUsdt[b]},     {changeUsdt[b]},     {lowUsdt[b]},      {highUsdt[b]}");
            //}

            for (int l = 0; l < usdt.Count; l++)
            {

                string empty = string.Empty;

                Console.WriteLine($"{l}     {usdt[l]},       {priceUsdt[l]}      {changeUsdt[l]}     {lowUsdt[l]}    {highUsdt[l]}");

                string symbol2 = usdt[l];
                string price2 = priceUsdt[l];
                string change2 = changeUsdt[l];
                string low2 = lowUsdt[l];
                string high2 = highUsdt[l];

                List<string> cryptoName = new List<string>();

                z = decimal.Parse(changeUsdt[l]);

                decimal resultado = z * 100;

                string cambio = resultado.ToString();

                int t = 0;

                string xyz = string.Empty;

                bool q = false;

                for (int x = 0; x < cambio.Length; x++)
                {
                    xyz += cambio[x];

                    if (q == true)
                    {
                        t++;
                    }
                    if (cambio[x] == '.')
                    {
                        q = true;
                    }

                    if (t == 2)
                    {
                        x = cambio.Length - 1;
                    }
                }
                z = decimal.Parse(xyz);
                    empty = "T";

                conn.Open();
                string m = String.Empty;
                string sql = $"SELECT * from Main;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                rdr.Close();
                conn.Close();

                if (symbol2 == "ETH-USDT" || symbol2 == "BNB-USDT" || symbol2 == "XRP-USDT" || symbol2 == "LTC-USDT" ||
                        symbol2 == "ADA-USDT" || symbol2 == "SOL-USDT" || symbol2 == "DOGE-USDT" || symbol2 == "DOT-USDT" ||
                        symbol2 == "AVAX-USDT" || symbol2 == "TRX-USDT" || symbol2 == "SHIB-USDT" || symbol2 == "MATIC-USDT" ||
                        symbol2 == "CRO-USDT" || symbol2 == "NEAR-USDT" || symbol2 == "FTT-USDT" || symbol2 == "UNI-USDT" ||
                        symbol2 == "BCH-USDT" || symbol2 == "LINK-USDT" || symbol2 == "XLM-USDT" || symbol2 == "ATOM-USDT" ||
                        symbol2 == "ALGO-USDT" || symbol2 == "XMR-USDT" || symbol2 == "APE-USDT" || symbol2 == "MANA-USDT" ||
                        symbol2 == "VET-USDT" || symbol2 == "ICP-USDT" || symbol2 == "FIL-USDT" || symbol2 == "SAND-USDT" ||
                        symbol2 == "XTZ-USDT" || symbol2 == "KCS-USDT" || symbol2 == "CAKE-USDT" || symbol2 == "AXS-USDT" ||
                        symbol2 == "EOS-USDT" || symbol2 == "THETA-USDT" || symbol2 == "AAVE-USDT" || symbol2 == "HT-USDT" ||
                        symbol2 == "BTT-USDT" || symbol2 == "IOTA-USDT" || symbol2 == "NEO-USDT" || symbol2 == "WAVES-USDT" ||
                        symbol2 == "KSM-USDT" || symbol2 == "DASH-USDT" || symbol2 == "DASH-USDT" || symbol2 == "ENJ-USDT" ||
                        symbol2 == "XEM-USDT" || symbol2 == "KDA-USDT" || symbol2 == "KAVA-USDT" || symbol2 == "1INCH-USDT" ||
                        symbol2 == "YFI-USDT" || symbol2 == "ROSE-USDT" || symbol2 == "OMG-USDT" || symbol2 == "SNX-USDT" ||
                        symbol2 == "UMA-USDT" || symbol2 == "DGB-USDT" || symbol2 == "SUSHI-USDT" || symbol2 == "DAG-USDT" ||
                        symbol2 == "OCEAN-USDT" || symbol2 == "COTI-USDT" || symbol2 == "DAO-USDT" || symbol2 == "DFI-USDT" ||
                        symbol2 == "LUNA-USDT" || symbol2 == "MOVR-USDT" || symbol2 == "EWT-USDT" || symbol2 == "API3-USDT" ||
                        symbol2 == "BLOK-USDT" || symbol2 == "POLS-USDT" || symbol2 == "KAI-USDT" || symbol2 == "ORN-USDT" ||
                        symbol2 == "RMRK-USDT" || symbol2 == "DIA-USDT" || symbol2 == "SFP-USDT" || symbol2 == "AVA-USDT" ||
                        symbol2 == "VRA-USDT" || symbol2 == "PHA-USDT" || symbol2 == "ANC-USDT" || symbol2 == "HYDRA-USDT" ||
                        symbol2 == "BOSON-USDT" || symbol2 == "WILD-USDT" || symbol2 == "VELO-USDT" || symbol2 == "CUDOS-USDT" ||
                        symbol2 == "SLP-USDT" || symbol2 == "MAP-USDT" || symbol2 == "SDN-USDT" || symbol2 == "MIR-USDT" ||
                        symbol2 == "AKRO-USDT" || symbol2 == "KAR-USDT" || symbol2 == "BOA-USDT" || symbol2 == "NIM-USDT" ||
                        symbol2 == "GO-USDT" || symbol2 == "PDEX-USDT" || symbol2 == "DEGO-USDT" || symbol2 == "ORAI-USDT" ||
                        symbol2 == "SYLO-USDT" || symbol2 == "POLK-USDT" || symbol2 == "BOLT-USDT" || symbol2 == "CAS-USDT")
                {
                    try
                    {
                        conn.Open();
                        m = String.Empty;
                        sql = $"SELECT * from Main where crypto = '{usdt[l]}';";
                        cmd = new MySqlCommand(sql, conn);
                        rdr = cmd.ExecuteReader();

                        int id1 = 0;
                        string cryptoName1 = String.Empty;
                        int plus101 = 0;
                        int plus201 = 0;
                        int plus301 = 0;
                        int minus101 = 0;
                        int minus201 = 0;
                        int minus301 = 0;

                        int id2 = 0;
                        int day1 = 0;
                        int hour1 = 0;

                        if (rdr.Read())
                        {
                            id1 = (int)rdr[0];
                            cryptoName1 = (string)rdr[1];
                            plus101 = (int)rdr[2];
                            plus201 = (int)rdr[3];
                            plus301 = (int)rdr[4];
                            minus101 = (int)rdr[5];
                            minus201 = (int)rdr[6];
                            minus301 = (int)rdr[7];
                        }

                        rdr.Close();
                        conn.Close();

                        if (z >= 10 && z < 20)
                        {
                            if (plus101 == 0)
                            {
                                await abc.SendMessage10PAsync(chatID, usdt[l],
                                    priceUsdt[l], xyz, lowUsdt[l], highUsdt[l]);

                                conn2.Open();
                                m = String.Empty;
                                sql = $"UPDATE Main SET plusdiez = 1 where crypto = '{usdt[l]}';";
                                cmd = new MySqlCommand(sql, conn2);
                                var rdr2 = cmd.ExecuteReader();
                                rdr2.Close();
                                conn2.Close();

                                var h = DateTime.Now.Day;
                                var j = DateTime.Now.Hour;

                                conn2.Open();
                                m = String.Empty;
                                sql = $"UPDATE Datetime SET day = {h}, hour = {j} where id = {id1};";
                                cmd = new MySqlCommand(sql, conn2);
                                rdr2 = cmd.ExecuteReader();
                                rdr2.Close();
                                conn2.Close();

                            }

                            else if (plus101 != 0)
                            {
                                conn2.Open();
                                m = String.Empty;
                                sql = $"SELECT * from Datetime where id = {id1};";
                                cmd = new MySqlCommand(sql, conn2);
                                var rdr2 = cmd.ExecuteReader();

                                if (rdr2.Read())
                                {
                                    id2 = (int)rdr2[0];
                                    day1 = (int)rdr2[1];
                                    hour1 = (int)rdr2[2];
                                }
                                rdr2.Close();
                                conn2.Close();

                                var suma = day1 + 1;
                                var resta = day1 - 2;

                                if (DateTime.Now.Day == suma && DateTime.Now.Hour >= hour1)
                                {
                                    await abc.SendMessage10PAsync(chatID, usdt[l],
                                    priceUsdt[l], xyz, lowUsdt[l], highUsdt[l]);

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Main SET plusdiez = 1 where crypto = '{usdt[l]}';";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();

                                    var h = DateTime.Now.Day;
                                    var j = DateTime.Now.Hour;

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Datetime SET day = {h}, hour = {j} where id = {id1};";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();
                                }

                                else if (DateTime.Now.Day > suma)
                                {
                                    await abc.SendMessage10PAsync(chatID, usdt[l],
                                    priceUsdt[l], xyz, lowUsdt[l], highUsdt[l]);

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Main SET plusdiez = 1 where crypto = '{usdt[l]}';";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();

                                    var h = DateTime.Now.Day;
                                    var j = DateTime.Now.Hour;

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Datetime SET day = {h}, hour = {j} where id = {id1};";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();
                                }

                                else if (DateTime.Now.Day <= resta)
                                {
                                    await abc.SendMessage10PAsync(chatID, usdt[l],
                                    priceUsdt[l], xyz, lowUsdt[l], highUsdt[l]);

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Main SET plusdiez = 1 where crypto = '{usdt[l]}';";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();

                                    var h = DateTime.Now.Day;
                                    var j = DateTime.Now.Hour;

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Datetime SET day = {h}, hour = {j} where id = {id1};";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();
                                }
                            }

                        }

                        else if (z <= -10 && z > -20)
                        {
                            if (minus101 == 0)
                            {
                                await abc.SendMessage10NAsync(chatID, usdt[l],
                                    priceUsdt[l], xyz, lowUsdt[l], highUsdt[l]);

                                conn2.Open();
                                m = String.Empty;
                                sql = $"UPDATE Main SET mainnesdiez = 1 where crypto = '{usdt[l]}';";
                                cmd = new MySqlCommand(sql, conn2);
                                var rdr2 = cmd.ExecuteReader();
                                rdr2.Close();
                                conn2.Close();

                                var h = DateTime.Now.Day;
                                var j = DateTime.Now.Hour;

                                conn2.Open();
                                m = String.Empty;
                                sql = $"UPDATE Datetime SET day = {h}, hour = {j} where id = {id1};";
                                cmd = new MySqlCommand(sql, conn2);
                                rdr2 = cmd.ExecuteReader();
                                rdr2.Close();
                                conn2.Close();
                            }

                            else if (minus101 != 0)
                            {
                                conn2.Open();
                                m = String.Empty;
                                sql = $"SELECT * from Datetime where id = {id1};";
                                cmd = new MySqlCommand(sql, conn2);
                                var rdr2 = cmd.ExecuteReader();

                                if (rdr2.Read())
                                {
                                    id2 = (int)rdr2[0];
                                    day1 = (int)rdr2[1];
                                    hour1 = (int)rdr2[2];
                                }
                                rdr2.Close();
                                conn2.Close();

                                var suma = day1 + 1;
                                var resta = day1 - 2;

                                if (DateTime.Now.Day == suma && DateTime.Now.Hour >= hour1)
                                {
                                    await abc.SendMessage10NAsync(chatID, usdt[l],
                                    priceUsdt[l], xyz, lowUsdt[l], highUsdt[l]);

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Main SET mainnesdiez = 1 where crypto = '{usdt[l]}';";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();


                                    var h = DateTime.Now.Day;
                                    var j = DateTime.Now.Hour;

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Datetime SET day = {h}, hour = {j} where id = {id1};";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();
                                }

                                else if (DateTime.Now.Day > suma)
                                {
                                    await abc.SendMessage10NAsync(chatID, usdt[l],
                                    priceUsdt[l], xyz, lowUsdt[l], highUsdt[l]);

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Main SET mainnesdiez = 1 where crypto = '{usdt[l]}';";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();

                                    var h = DateTime.Now.Day;
                                    var j = DateTime.Now.Hour;

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Datetime SET day = {h}, hour = {j} where id = {id1};";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();
                                }

                                else if (DateTime.Now.Day <= resta)
                                {
                                    await abc.SendMessage10NAsync(chatID, usdt[l],
                                    priceUsdt[l], xyz, lowUsdt[l], highUsdt[l]);

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Main SET mainnesdiez = 1 where crypto = '{usdt[l]}';";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();

                                    var h = DateTime.Now.Day;
                                    var j = DateTime.Now.Hour;

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Datetime SET day = {h}, hour = {j} where id = {id1};";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();
                                }
                            }

                        }

                        else if (z >= 20 && z < 30)
                        {
                            if (plus201 == 0)
                            {
                                await abc.SendMessage20PAsync(chatID, usdt[l],
                                    priceUsdt[l], xyz, lowUsdt[l], highUsdt[l]);

                                conn2.Open();
                                m = String.Empty;
                                sql = $"UPDATE Main SET plusveinte = 1 where crypto = '{usdt[l]}';";
                                cmd = new MySqlCommand(sql, conn2);
                                var rdr2 = cmd.ExecuteReader();
                                rdr2.Close();
                                conn2.Close();

                                conn2.Open();
                                m = String.Empty;
                                sql = $"UPDATE Main SET plusdiez = 1 where crypto = '{usdt[l]}';";
                                cmd = new MySqlCommand(sql, conn2);
                                rdr2 = cmd.ExecuteReader();
                                rdr2.Close();
                                conn2.Close();

                                var h = DateTime.Now.Day;
                                var j = DateTime.Now.Hour;

                                conn2.Open();
                                m = String.Empty;
                                sql = $"UPDATE Datetime SET day = {h}, hour = {j} where id = {id1};";
                                cmd = new MySqlCommand(sql, conn2);
                                rdr2 = cmd.ExecuteReader();
                                rdr2.Close();
                                conn2.Close();
                            }

                            else if (plus201 != 0)
                            {
                                conn2.Open();
                                m = String.Empty;
                                sql = $"SELECT * from Datetime where id = {id1};";
                                cmd = new MySqlCommand(sql, conn2);
                                var rdr2 = cmd.ExecuteReader();

                                if (rdr2.Read())
                                {
                                    id2 = (int)rdr2[0];
                                    day1 = (int)rdr2[1];
                                    hour1 = (int)rdr2[2];
                                }
                                rdr2.Close();
                                conn2.Close();

                                var suma = day1 + 1;
                                var resta = day1 - 2;

                                if (DateTime.Now.Day == suma && DateTime.Now.Hour >= hour1)
                                {
                                    await abc.SendMessage20PAsync(chatID, usdt[l],
                                    priceUsdt[l], xyz, lowUsdt[l], highUsdt[l]);

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Main SET plusveinte = 1 where crypto = '{usdt[l]}';";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Main SET plusdiez = 1 where crypto = '{usdt[l]}';";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();

                                    var h = DateTime.Now.Day;
                                    var j = DateTime.Now.Hour;

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Datetime SET day = {h}, hour = {j} where id = {id1};";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();
                                }

                                else if (DateTime.Now.Day > suma)
                                {
                                    await abc.SendMessage20PAsync(chatID, usdt[l],
                                    priceUsdt[l], xyz, lowUsdt[l], highUsdt[l]);

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Main SET plusveinte = 1 where crypto = '{usdt[l]}';";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Main SET plusdiez = 1 where crypto = '{usdt[l]}';";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();

                                    var h = DateTime.Now.Day;
                                    var j = DateTime.Now.Hour;

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Datetime SET day = {h}, hour = {j} where id = {id1};";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();
                                }

                                else if (DateTime.Now.Day <= resta)
                                {
                                    await abc.SendMessage20PAsync(chatID, usdt[l],
                                    priceUsdt[l], xyz, lowUsdt[l], highUsdt[l]);

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Main SET plusveinte = 1 where crypto = '{usdt[l]}';";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Main SET plusdiez = 1 where crypto = '{usdt[l]}';";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();

                                    var h = DateTime.Now.Day;
                                    var j = DateTime.Now.Hour;

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Datetime SET day = {h}, hour = {j} where id = {id1};";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();
                                }
                            }
                        }

                        else if (z <= -20 && z > -30)
                        {
                            if (minus201 == 0)
                            {
                                await abc.SendMessage20NAsync(chatID, usdt[l],
                                    priceUsdt[l], xyz, lowUsdt[l], highUsdt[l]);

                                conn2.Open();
                                m = String.Empty;
                                sql = $"UPDATE Main SET mainnesveinte = 1 where crypto = '{usdt[l]}';";
                                cmd = new MySqlCommand(sql, conn2);
                                var rdr2 = cmd.ExecuteReader();
                                rdr2.Close();
                                conn2.Close();

                                conn2.Open();
                                m = String.Empty;
                                sql = $"UPDATE Main SET mainnesdiez = 1 where crypto = '{usdt[l]}';";
                                cmd = new MySqlCommand(sql, conn2);
                                rdr2 = cmd.ExecuteReader();
                                rdr2.Close();
                                conn2.Close();

                                var h = DateTime.Now.Day;
                                var j = DateTime.Now.Hour;

                                conn2.Open();
                                m = String.Empty;
                                sql = $"UPDATE Datetime SET day = {h}, hour = {j} where id = {id1};";
                                cmd = new MySqlCommand(sql, conn2);
                                rdr2 = cmd.ExecuteReader();
                                rdr2.Close();
                                conn2.Close();

                            }

                            else if (minus201 != 0)
                            {
                                conn2.Open();
                                m = String.Empty;
                                sql = $"SELECT * from Datetime where id = {id1};";
                                cmd = new MySqlCommand(sql, conn2);
                                var rdr2 = cmd.ExecuteReader();

                                if (rdr2.Read())
                                {
                                    id2 = (int)rdr2[0];
                                    day1 = (int)rdr2[1];
                                    hour1 = (int)rdr2[2];
                                }
                                rdr2.Close();
                                conn2.Close();

                                var suma = day1 + 1;
                                var resta = day1 - 2;

                                if (DateTime.Now.Day == suma && DateTime.Now.Hour >= hour1)
                                {
                                    await abc.SendMessage20NAsync(chatID, usdt[l],
                                    priceUsdt[l], xyz, lowUsdt[l], highUsdt[l]);

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Main SET mainnesveinte = 1 where crypto = '{usdt[l]}';";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Main SET mainnesdiez = 1 where crypto = '{usdt[l]}';";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();

                                    var h = DateTime.Now.Day;
                                    var j = DateTime.Now.Hour;

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Datetime SET day = {h}, hour = {j} where id = {id1};";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();
                                }

                                else if (DateTime.Now.Day > suma)
                                {
                                    await abc.SendMessage20NAsync(chatID, usdt[l],
                                       priceUsdt[l], xyz, lowUsdt[l], highUsdt[l]);

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Main SET mainnesveinte = 1 where crypto = '{usdt[l]}';";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Main SET mainnesdiez = 1 where crypto = '{usdt[l]}';";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();

                                    var h = DateTime.Now.Day;
                                    var j = DateTime.Now.Hour;

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Datetime SET day = {h}, hour = {j} where id = {id1};";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();
                                }

                                else if (DateTime.Now.Day <= resta)
                                {
                                    await abc.SendMessage20NAsync(chatID, usdt[l],
                                    priceUsdt[l], xyz, lowUsdt[l], highUsdt[l]);

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Main SET mainnesveinte = 1 where crypto = '{usdt[l]}';";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Main SET mainnesdiez = 1 where crypto = '{usdt[l]}';";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();

                                    var h = DateTime.Now.Day;
                                    var j = DateTime.Now.Hour;

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Datetime SET day = {h}, hour = {j} where id = {id1};";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn.Close();
                                }
                            }
                        }

                        else if (z >= 30)
                        {
                            if (plus301 == 0)
                            {
                                await abc.SendMessage30PAsync(chatID, usdt[l],
                              priceUsdt[l], xyz, lowUsdt[l], highUsdt[l]);

                                conn2.Open();
                                m = String.Empty;
                                sql = $"UPDATE Main SET plustreinta = 1 where crypto = '{usdt[l]}';";
                                cmd = new MySqlCommand(sql, conn2);
                                var rdr2 = cmd.ExecuteReader();
                                rdr2.Close();
                                conn2.Close();

                                conn2.Open();
                                m = String.Empty;
                                sql = $"UPDATE Main SET plusveinte = 1 where crypto = '{usdt[l]}';";
                                cmd = new MySqlCommand(sql, conn2);
                                rdr2 = cmd.ExecuteReader();
                                rdr2.Close();
                                conn2.Close();

                                conn2.Open();
                                m = String.Empty;
                                sql = $"UPDATE Main SET plusdiez = 1 where crypto = '{usdt[l]}';";
                                cmd = new MySqlCommand(sql, conn2);
                                rdr2 = cmd.ExecuteReader();
                                rdr2.Close();
                                conn2.Close();

                                var h = DateTime.Now.Day;
                                var j = DateTime.Now.Hour;

                                conn2.Open();
                                m = String.Empty;
                                sql = $"UPDATE Datetime SET day = {h}, hour = {j} where id = {id1};";
                                cmd = new MySqlCommand(sql, conn2);
                                rdr2 = cmd.ExecuteReader();
                                rdr2.Close();
                                conn2.Close();

                            }

                            else if (plus301 != 0)
                            {
                                conn2.Open();
                                m = String.Empty;
                                sql = $"SELECT * from Datetime where id = {id1};";
                                cmd = new MySqlCommand(sql, conn2);
                                var rdr2 = cmd.ExecuteReader();

                                if (rdr2.Read())
                                {
                                    id2 = (int)rdr2[0];
                                    day1 = (int)rdr2[1];
                                    hour1 = (int)rdr2[2];
                                }
                                rdr2.Close();
                                conn2.Close();

                                var suma = day1 + 1;
                                var resta = day1 - 2;

                                if (DateTime.Now.Day == suma && DateTime.Now.Hour >= hour1)
                                {
                                    await abc.SendMessage30PAsync(chatID, usdt[l],
                              priceUsdt[l], xyz, lowUsdt[l], highUsdt[l]);

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Main SET plustreinta = 1 where crypto = '{usdt[l]}';";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Main SET plusveinte = 1 where crypto = '{usdt[l]}';";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Main SET plusdiez = 1 where crypto = '{usdt[l]}';";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();

                                    var h = DateTime.Now.Day;
                                    var j = DateTime.Now.Hour;

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Datetime SET day = {h}, hour = {j} where id = {id1};";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();
                                }

                                else if (DateTime.Now.Day > suma)
                                {
                                    await abc.SendMessage30PAsync(chatID, usdt[l],
                              priceUsdt[l], xyz, lowUsdt[l], highUsdt[l]);

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Main SET plustreinta = 1 where crypto = '{usdt[l]}';";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Main SET plusveinte = 1 where crypto = '{usdt[l]}';";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Main SET plusdiez = 1 where crypto = '{usdt[l]}';";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();

                                    var h = DateTime.Now.Day;
                                    var j = DateTime.Now.Hour;

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Datetime SET day = {h}, hour = {j} where id = {id1};";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();
                                }

                                else if (DateTime.Now.Day <= resta)
                                {
                                    await abc.SendMessage30PAsync(chatID, usdt[l],
                              priceUsdt[l], xyz, lowUsdt[l], highUsdt[l]);

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Main SET plustreinta = 1 where crypto = '{usdt[l]}';";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Main SET plusveinte = 1 where crypto = '{usdt[l]}';";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Main SET plusdiez = 1 where crypto = '{usdt[l]}';";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();

                                    var h = DateTime.Now.Day;
                                    var j = DateTime.Now.Hour;

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Datetime SET day = {h}, hour = {j} where id = {id1};";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();
                                }
                            }
                        }

                        else if (z <= -30)
                        {
                            if (minus301 == 0)
                            {
                                await abc.SendMessage30NAsync(chatID, usdt[l],
                                 priceUsdt[l], xyz, lowUsdt[l], highUsdt[l]);

                                conn2.Open();
                                m = String.Empty;
                                sql = $"UPDATE Main SET mainnestreinta = 1 where crypto = '{usdt[l]}';";
                                cmd = new MySqlCommand(sql, conn2);
                                var rdr2 = cmd.ExecuteReader();
                                rdr2.Close();
                                conn2.Close();

                                conn2.Open();
                                m = String.Empty;
                                sql = $"UPDATE Main SET mainnesveinte = 1 where crypto = '{usdt[l]}';";
                                cmd = new MySqlCommand(sql, conn2);
                                rdr2 = cmd.ExecuteReader();
                                rdr2.Close();
                                conn2.Close();

                                conn2.Open();
                                m = String.Empty;
                                sql = $"UPDATE Main SET mainnesdiez = 1 where crypto = '{usdt[l]}';";
                                cmd = new MySqlCommand(sql, conn2);
                                rdr2 = cmd.ExecuteReader();
                                rdr2.Close();
                                conn2.Close();

                                var h = DateTime.Now.Day;
                                var j = DateTime.Now.Hour;

                                conn2.Open();
                                m = String.Empty;
                                sql = $"UPDATE Datetime SET day = {h}, hour = {j} where id = {id1};";
                                cmd = new MySqlCommand(sql, conn2);
                                rdr2 = cmd.ExecuteReader();
                                rdr2.Close();
                                conn2.Close();

                            }

                            else if (minus301 != 0)
                            {
                                conn2.Open();
                                m = String.Empty;
                                sql = $"SELECT * from Datetime where id = {id1};";
                                cmd = new MySqlCommand(sql, conn2);
                                var rdr2 = cmd.ExecuteReader();

                                if (rdr2.Read())
                                {
                                    id2 = (int)rdr2[0];
                                    day1 = (int)rdr2[1];
                                    hour1 = (int)rdr2[2];
                                }
                                rdr2.Close();
                                conn2.Close();

                                var suma = day1 + 1;
                                var resta = day1 - 2;

                                if (DateTime.Now.Day == suma && DateTime.Now.Hour >= hour1)
                                {
                                    await abc.SendMessage30NAsync(chatID, usdt[l],
                                  priceUsdt[l], xyz, lowUsdt[l], highUsdt[l]);

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Main SET mainnestreinta = 1 where crypto = '{usdt[l]}';";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Main SET mainnesveinte = 1 where crypto = '{usdt[l]}';";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Main SET mainnesdiez = 1 where crypto = '{usdt[l]}';";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();

                                    var h = DateTime.Now.Day;
                                    var j = DateTime.Now.Hour;

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Datetime SET day = {h}, hour = {j} where id = {id1};";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();
                                }

                                else if (DateTime.Now.Day > suma)
                                {
                                    await abc.SendMessage30NAsync(chatID, usdt[l],
                                             priceUsdt[l], xyz, lowUsdt[l], highUsdt[l]);

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Main SET mainnestreinta = 1 where crypto = '{usdt[l]}';";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Main SET mainnesveinte = 1 where crypto = '{usdt[l]}';";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Main SET mainnesdiez = 1 where crypto = '{usdt[l]}';";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();

                                    var h = DateTime.Now.Day;
                                    var j = DateTime.Now.Hour;

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Datetime SET day = {h}, hour = {j} where id = {id1};";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();
                                }

                                else if (DateTime.Now.Day <= resta)
                                {
                                    await abc.SendMessage30NAsync(chatID, usdt[l],
                                    priceUsdt[l], xyz, lowUsdt[l], highUsdt[l]);

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Main SET mainnestreinta = 1 where crypto = '{usdt[l]}';";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Main SET mainnesveinte = 1 where crypto = '{usdt[l]}';";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Main SET mainnesdiez = 1 where crypto = '{usdt[l]}';";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();

                                    var h = DateTime.Now.Day;
                                    var j = DateTime.Now.Hour;

                                    conn2.Open();
                                    m = String.Empty;
                                    sql = $"UPDATE Datetime SET day = {h}, hour = {j} where id = {id1};";
                                    cmd = new MySqlCommand(sql, conn2);
                                    rdr2 = cmd.ExecuteReader();
                                    rdr2.Close();
                                    conn2.Close();
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }

                int n = l + 1;
                string a = l.ToString();
                if (a != "0")
                {
                    if (a[a.Length - 1] == '0')
                    {
                        Thread.Sleep(5000);

                        if (a == "30" || a == "60" || a == "90")
                        {
                            Thread.Sleep(30000);
                        }
                    }
                }
            }                      

        }
    }
}
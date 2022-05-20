using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

using Newtonsoft.Json;

namespace the_Cryptocurrencies_bot
{
    public class ConeccionAPI
    {
        public async Task<int> Lenght()
        {
            var url = "https://api.kucoin.com/api/v1/market/allTickers";

            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Error conectando a la api");
                throw new Exception();
            }

            var json = await response.Content.ReadAsStringAsync();

            var info = JsonConvert.DeserializeObject<Root>(json);

            return info.Data.Ticker.Count;
        }

        public async Task<List<string>> APISymbol()
        {
            var url = "https://api.kucoin.com/api/v1/market/allTickers";

            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Error conectando a la api");
                throw new Exception();
            }

            var json = await response.Content.ReadAsStringAsync();

            var info = JsonConvert.DeserializeObject<Root>(json);

            List<string> symbols = new List<string>();

            for (int q = 0; q < info.Data.Ticker.Count; q++)
            {
                symbols.Add(info.Data.Ticker[q].SymbolName);
            }
            return symbols;


        }

        public async Task<List<string>> APIPrice()
        {
            var url = "https://api.kucoin.com/api/v1/market/allTickers";

            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Error conectando a la api");
                throw new Exception();
            }

            var json = await response.Content.ReadAsStringAsync();

            var info = JsonConvert.DeserializeObject<Root>(json);

            List<string> price = new List<string>();

            for (int q = 0; q < info.Data.Ticker.Count; q++)
            {
                price.Add(info.Data.Ticker[q].Buy);
            }

            return price;

        }

        public async Task<List<string>> APIChangeRate()
        {
            var url = "https://api.kucoin.com/api/v1/market/allTickers";

            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Error conectando a la api");
                throw new Exception();
            }

            var json = await response.Content.ReadAsStringAsync();

            var info = JsonConvert.DeserializeObject<Root>(json);

            //List<string> cambio = info.Data.Ticker.

            List<string> cambio = new List<string>();

            for (int d = 0; d < info.Data.Ticker.Count; d++)
            {
                cambio.Add(info.Data.Ticker[d].ChangeRate);
            }

            return cambio;
        }

        public async Task<List<string>> APILow()
        {
            var url = "https://api.kucoin.com/api/v1/market/allTickers";

            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Error conectando a la api");
                throw new Exception();
            }

            var json = await response.Content.ReadAsStringAsync();

            var info = JsonConvert.DeserializeObject<Root>(json);

            List<string> low = new List<string>();

            for (int d = 0; d < info.Data.Ticker.Count; d++)
            {
                low.Add(info.Data.Ticker[d].Low);
            }

            return low;

        }

        public async Task<List<string>> APIHigh()
        {
            var url = "https://api.kucoin.com/api/v1/market/allTickers";

            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Error conectando a la api");
                throw new Exception();
            }

            var json = await response.Content.ReadAsStringAsync();

            var info = JsonConvert.DeserializeObject<Root>(json);

            List<string> high = new List<string>();

            for (int d = 0; d < info.Data.Ticker.Count; d++)
            {
                high.Add(info.Data.Ticker[d].High);
            }

            return high;

        }

        public class Ticker
        {
            [JsonProperty("symbol")]
            public string Symbol { get; set; }

            [JsonProperty("symbolName")]
            public string SymbolName { get; set; }

            [JsonProperty("buy")]
            public string Buy { get; set; }

            [JsonProperty("sell")]
            public string Sell { get; set; }

            [JsonProperty("changeRate")]
            public string ChangeRate { get; set; }

            [JsonProperty("changePrice")]
            public string ChangePrice { get; set; }

            [JsonProperty("high")]
            public string High { get; set; }

            [JsonProperty("low")]
            public string Low { get; set; }

            [JsonProperty("vol")]
            public string Vol { get; set; }

            [JsonProperty("volValue")]
            public string VolValue { get; set; }

            [JsonProperty("last")]
            public string Last { get; set; }

            [JsonProperty("averagePrice")]
            public string AveragePrice { get; set; }

            [JsonProperty("takerFeeRate")]
            public string TakerFeeRate { get; set; }

            [JsonProperty("makerFeeRate")]
            public string MakerFeeRate { get; set; }

            [JsonProperty("takerCoefficient")]
            public string TakerCoefficient { get; set; }

            [JsonProperty("makerCoefficient")]
            public string MakerCoefficient { get; set; }
        }

        public class Data
        {
            [JsonProperty("time")]
            public long Time { get; set; }

            [JsonProperty("ticker")]
            public List<Ticker> Ticker { get; set; }
        }

        public class Root
        {
            [JsonProperty("code")]
            public string Code { get; set; }

            [JsonProperty("data")]
            public Data Data { get; set; }
        }


    }

    public class Chequeo
    {
        public async Task SendMessage10PAsync(string chatID, string Sysmbol,
                string Price, string ChangeRate, string Low, string High)
        {
            var botClient = new TelegramBotClient("5334575224:AAG2ZDMcPJidtBydNDdqz8PQh2IVPLSGv_4");
            Message message = await botClient.SendTextMessageAsync(
                chatId: chatID,
                text:
                $"Buen movimiento 🙂\n" +
                "\n" +
                $"👉 {Sysmbol} ha subido {ChangeRate}%" +
                " en las ultimas 24h\n" +
                "\n" +
                $"Teniendo un Low 📉 de {Low} y un High 📈 de {High}" +
                "\n" +
                "\n" +
                $"✍️ Precio actual: {Price}");
        }

        public async Task SendMessage10NAsync(string chatID, string Sysmbol,
            string Price, string ChangeRate, string Low, string High)
        {
            var botClient = new TelegramBotClient("5334575224:AAG2ZDMcPJidtBydNDdqz8PQh2IVPLSGv_4");
            Message message = await botClient.SendTextMessageAsync(
                chatId: chatID,
                text:
                $"Esto se pone interesante 🙃\n" +
                "\n" +
                $"👉 {Sysmbol} ha bajado {ChangeRate}%" +
                " en las ultimas 24h\n" +
                "\n" +
                $"Teniendo un Low 📉 de {Low} y un High 📈 de {High}" +
                "\n" +
                "\n" +
                $"✍️ Precio actual: {Price}");
        }

        public async Task SendMessage20PAsync(string chatID, string Sysmbol,
        string Price, string ChangeRate, string Low, string High)
        {
            var botClient = new TelegramBotClient("5334575224:AAG2ZDMcPJidtBydNDdqz8PQh2IVPLSGv_4");
            Message message = await botClient.SendTextMessageAsync(
                chatId: chatID,
                text:
                $"Preparen los motores 😉\n" +
                "\n" +
                $"👉 {Sysmbol} ha subido {ChangeRate}%" +
                " en las ultimas 24h\n" +
                "\n" +
                $"Teniendo un Low 📉 de {Low} y un High 📈 de {High}" +
                "\n" +
                "\n" +
                $"✍️ Precio actual: {Price}");
        }

        public async Task SendMessage20NAsync(string chatID, string Sysmbol,
        string Price, string ChangeRate, string Low, string High)
        {
            var botClient = new TelegramBotClient("5334575224:AAG2ZDMcPJidtBydNDdqz8PQh2IVPLSGv_4");
            Message message = await botClient.SendTextMessageAsync(
                chatId: chatID,
                text:
                $"Corre que se te va el tren 😂\n" +
                "\n" +
                $"👉 {Sysmbol} ha bajado {ChangeRate}%" +
                " en las ultimas 24h\n" +
                "\n" +
                $"Teniendo un Low 📉 de {Low} y un High 📈 de {High}" +
                "\n" +
                "\n" +
                $"✍️ Precio actual: {Price}");
        }

        public async Task SendMessage30PAsync(string chatID, string Sysmbol,
        string Price, string ChangeRate, string Low, string High)
        {
            var botClient = new TelegramBotClient("5334575224:AAG2ZDMcPJidtBydNDdqz8PQh2IVPLSGv_4");
            Message message = await botClient.SendTextMessageAsync(
                chatId: chatID,
                text:
                $"To the Moon 🚀🚀\n" +
                "\n" +
                $"👉 {Sysmbol} ha subido {ChangeRate}%" +
                " en las ultimas 24h\n" +
                "\n" +
                $"Teniendo un Low 📉 de {Low} y un High 📈 de {High}" +
                "\n" +
                "\n" +
                $"✍️ Precio actual: {Price}");
        }

        public async Task SendMessage30NAsync(string chatID, string Sysmbol,
        string Price, string ChangeRate, string Low, string High)
        {
            var botClient = new TelegramBotClient("5334575224:AAG2ZDMcPJidtBydNDdqz8PQh2IVPLSGv_4");
            Message message = await botClient.SendTextMessageAsync(
                chatId: chatID,
                text:
                $"Nos fuimos loma abajo y sin frenos 😜🤪\n" +
                "\n" +
                $"👉 {Sysmbol} ha bajado {ChangeRate}%" +
                " en las ultimas 24h\n" +
                "\n" +
                $"Teniendo un Low 📉 de {Low} y un High 📈 de {High}" +
                "\n" +
                "\n" +
                $"✍️ Precio actual: {Price}");
        }
    }
}

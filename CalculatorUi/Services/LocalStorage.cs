using Newtonsoft.Json;
using System.IO;

namespace TelegramCalculator.UI.Services
{
    internal class LocalStorage : ILocalStorage
    {
        private readonly string _fileName = "local.json";

        public LocalAuthData Get()
        {
            using var reader = new StreamReader(File.Open(_fileName, FileMode.OpenOrCreate));
            return JsonConvert.DeserializeObject<LocalAuthData>(reader.ReadToEnd());
        }

        public void Set(LocalAuthData value)
        {
            using var writer = new StreamWriter(File.Open(_fileName, FileMode.Create));
            writer.Write(JsonConvert.SerializeObject(value));
        }
    }

    internal class LocalAuthData
    {
        public string PhoneNumber { get; set; }
    }
}

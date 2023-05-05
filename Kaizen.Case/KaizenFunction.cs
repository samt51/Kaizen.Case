using CsvHelper;
using CsvHelper.Configuration;
using Newtonsoft.Json.Linq;
using System.IO;

namespace Kaizen.Case
{
    public static class KaizenFunction
    {
        public static string JsonConvertToCsv(string json)
        {
            var config = new CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture)
            {
                Delimiter = ",",
                HasHeaderRecord = true,
            };
            JArray jArray = JArray.Parse(json);

            using (StringWriter writer = new StringWriter())
            {
                // CsvWriter nesnesi oluştur
                using (CsvWriter csv = new CsvWriter(writer, config))
                {
                    // Header satırı için özellik isimlerini yaz
                    foreach (JProperty property in jArray.First.Children())
                    {
                        csv.WriteField(property.Name);
                    }
                    csv.NextRecord();

                    // Her öğe için satır yaz
                    foreach (JObject obj in jArray)
                    {
                        foreach (JProperty property in obj.Children())
                        {
                            csv.WriteField(property.Value.ToString());
                        }
                        csv.NextRecord();
                    }
                }

                // CSV dosyasını yaz

                return writer.ToString();
            }
           
        }
    }
}

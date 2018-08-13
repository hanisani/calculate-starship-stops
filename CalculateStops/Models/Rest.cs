using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace CalculateStops.Models
{
    public class Rest
    {
        public Rest()
        {
        }
        public static T Deserialize<T>(string input)
        {
            return JsonConvert.DeserializeObject<T>(input);
        }
        public GridDTO SendRequestion(string url)
        {
            var httpClient = new HttpClient();
            GridDTO gridDTO = new GridDTO();
            try
            {
                using (httpClient)
                {
                    httpClient.BaseAddress = new Uri(url);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "identity");

                    HttpResponseMessage response = new HttpResponseMessage();
                    response = httpClient.GetAsync(url).Result;

                    if (response.IsSuccessStatusCode)
                        return Deserialize<GridDTO>(response.Content.ReadAsStringAsync().Result);
                }
            }
            finally
            {
                if (httpClient != null)
                {
                    httpClient.Dispose();
                    httpClient = null;
                }
            }
            return gridDTO;
        }
    }
}
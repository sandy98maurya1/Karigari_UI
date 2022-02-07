using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Karigari.Integrations.Storage.User
{
    public static class ConsumeApiService
    {
        public static T ConsumeApi<T>(HttpMethod requestMethod, string requestUri, object inputs)
        {
            string Apiurl = "https://localhost:44395";
            Apiurl= Apiurl + requestUri;
            var request = new HttpRequestMessage();

            using (var client = new HttpClient())
            {
                request.Method = requestMethod;
                request.RequestUri = new UriBuilder(Apiurl).Uri;
                request.Content = new StringContent(JsonConvert.SerializeObject(inputs), Encoding.UTF8, "application/json");
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.SendAsync(request).Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    var output = System.Text.Json.JsonSerializer.Deserialize<T>(result, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }); ;
                    return output;
                }
            }
            return JsonConvert.DeserializeObject<T>(String.Empty);
        }
    }
}

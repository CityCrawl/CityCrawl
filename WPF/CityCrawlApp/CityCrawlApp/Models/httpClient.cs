using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CityCrawlApp.Models.Interfaces;


namespace CityCrawlApp.Models
{
    public class httpClient : IhttpClient
    {
        public User HttpClientGetUserFromServer(string email, string password)
        {
            string url = $"{Settings.baseUrl}/User?email={email}&password={password}"; // tages fra app settings
            HttpClient client = new HttpClient();
            try
            {
                Task<string> responseBody = client.GetStringAsync(url);
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                var user = JsonSerializer.Deserialize<User>(responseBody.Result, options);
                return user;
            }
            catch (Exception)
            {
                // show erro failed to talk to server...
                return null;
            }
        }

        public void HttpClientCreateUser(User user)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(user, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            using var httpRequest = new HttpRequestMessage(HttpMethod.Post, Settings.baseUrl + "/User/User");
            using var client = new HttpClient();
            using var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            httpRequest.Content = stringContent;

            var httpResponse = client.Send(httpRequest, HttpCompletionOption.ResponseHeadersRead);
            httpResponse.EnsureSuccessStatusCode();
        }

        public void HttpClientAddPubCrawls(NewPubcrawlRequest pubcrawl)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(pubcrawl, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            using var httpRequest = new HttpRequestMessage(HttpMethod.Post, Settings.baseUrl + $"/User/PubCrawl");
            using var client = new HttpClient();
            using var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            httpRequest.Content = stringContent;

            var httpResponse = client.Send(httpRequest, HttpCompletionOption.ResponseHeadersRead);
            httpResponse.EnsureSuccessStatusCode();
        }

    }
}

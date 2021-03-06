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
    public class CCHttpClient : ICCHttpClient
    {
        public User HttpClientGetUserFromServer(string email, string password)
        {
            string url = $"{Settings.baseUrl}/Account/Bruger?email={email}&password={password}"; // tages fra app settings
            HttpClient client = new HttpClient();
        
            Task<string> responseBody = client.GetStringAsync(url);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            var user = JsonSerializer.Deserialize<User>(responseBody.Result, options);
            return user;
        }

        public void HttpClientCreateUser(User user)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(user, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            using var httpRequest = new HttpRequestMessage(HttpMethod.Post, Settings.baseUrl + "/Account/register");
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
            
            using var httpRequest = new HttpRequestMessage(HttpMethod.Post, Settings.baseUrl + "/Account/Pubcrawl");
            using var client = new HttpClient();
            using var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            httpRequest.Content = stringContent;

            var httpResponse = client.Send(httpRequest, HttpCompletionOption.ResponseHeadersRead);
            httpResponse.EnsureSuccessStatusCode();
        }

    }
}

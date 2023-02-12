using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankClient
{
    public static class Utils
    {
        public static string GetRequestString(this HttpClient client, HttpMethod method, string requestUri, out bool success)
        {
            using var request = new HttpRequestMessage(method, requestUri);
            
            using var response = client.Send(request);
            
            var task = response.Content.ReadAsStringAsync();
            task.Wait();

            success = response.IsSuccessStatusCode;

            return task.Result;
        }

        public static bool SendRequest(this HttpClient client, HttpMethod method, string requestUri, string content)
        {
            using var request = new HttpRequestMessage(method, requestUri);

            request.Content = new StringContent(content, Encoding.UTF8, "application/json");

            using var response = client.Send(request);

            return response.IsSuccessStatusCode;
        }

        public static JsonNode? GetJSONValue(string s)
        {
            var node = JsonNode.Parse(s);

            var valueNode = node!["value"];

            return valueNode;
        }
    }
}

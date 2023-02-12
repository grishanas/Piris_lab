using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace BankClient
{
    public static class Utils
    {
        public static string GetRequestString(this HttpClient client, HttpMethod method, string requestUri)
        {
            using var request = new HttpRequestMessage(method, requestUri);
            
            using var response = client.Send(request);

            var task = response.Content.ReadAsStringAsync();
            task.Wait();

            return task.Result;
        }

        public static JsonNode? GetJSONValue(string s)
        {
            var node = JsonNode.Parse(s);

            var valueNode = node!["value"];

            return valueNode;
        }
    }
}

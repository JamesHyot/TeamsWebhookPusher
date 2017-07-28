using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TeamsWebhookPusher.CardBuilding;

namespace TeamsWebhookPusher.Pusher
{
    public static class TeamsWebhookPusher
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        public static async Task<bool> PushEvent(Uri webhookUrl, TeamsCard card)
        {
            var serializedCard = JsonConvert.SerializeObject(card);

            Console.WriteLine($"\nPushing this card : {serializedCard}\n");

            return await PushEvent(webhookUrl, serializedCard);
        }

        public static async Task<bool> PushEvent(Uri webhookUrl, string serializedCard)
        {
            var content = new StringContent(serializedCard, Encoding.UTF8, "application/json");

            var response = await HttpClient.PostAsync(webhookUrl, content);

            return response.IsSuccessStatusCode;
        }
    }
}

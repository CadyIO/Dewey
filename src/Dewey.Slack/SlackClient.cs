using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Http;

namespace Dewey.Slack
{
    public static class SlackClient
    {
        public static string Username { get; set; }
        public static string IconUrl { get; set; }
        public static string IconEmoji { get; set; }
        public static string WebhookUrl { get; set; }
        public static string Channel { get; set; }
        public static bool Enabled { get; set; }

        public static void PostMessage(string title, string text, params Attachment[] attachments)
        {
            if (!Enabled) {
                return;
            }

            var payload = new SlackPayload
            {
                Username = Username,
                IconEmoji = IconEmoji,
                IconUrl = IconUrl,
                Channel = Channel,
                Title = title,
                Text = text,
                Attachments = attachments.ToList()
            };

            PostMessage(payload);
        }

        private static void PostMessage(SlackPayload payload)
        {
            if (payload == null) {
                throw new ArgumentException(nameof(payload));
            }

            var payloadSerialized = JsonConvert.SerializeObject(payload);

            var data = new List<KeyValuePair<string, string>> {
                new KeyValuePair<string, string>("payload", payloadSerialized)
            };

            using (var client = new HttpClient()) {
                var content = new FormUrlEncodedContent(data);

                client.PostAsync(WebhookUrl, content)
                      .ContinueWith(
                          (postTask) => {
                              postTask.Result.EnsureSuccessStatusCode();
                          }
                      );
            }
        }
    }
}

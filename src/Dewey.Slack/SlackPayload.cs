using Newtonsoft.Json;
using System.Collections.Generic;

namespace Dewey.Slack
{
    public class SlackPayload
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("icon_url")]
        public string IconUrl { get; set; }

        [JsonProperty("icon_emoji")]
        public string IconEmoji { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("attachments")]
        public List<Attachment> Attachments { get; set; }
    }
}

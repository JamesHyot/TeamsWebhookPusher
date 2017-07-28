using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TeamsWebhookPusher.CardBuilding
{
    // https://messagecardplayground.azurewebsites.net/
    public class TeamsCard
    {
        [JsonRequired]
        [JsonProperty(PropertyName = "@type")]
        private const string Type = "MessageCard";

        [JsonRequired]
        [JsonProperty(PropertyName = "@context")]
        private const string Context = "http://schema.org/extensions";

        [JsonProperty(PropertyName = "summary")]
        public string Summary { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "themeColor")]
        public string ThemeColor { get; set; } = "19b5fe";

        [JsonRequired]
        [JsonProperty(PropertyName = "sections")]
        public List<Section> Sections { get; set; } = new List<Section>();

        public class Section
        {
            [JsonProperty(PropertyName = "title")]
            public string Title { get; set; }

            [JsonProperty(PropertyName = "activityImage")]
            public string ActivityImageUrl { get; set; }

            [JsonProperty(PropertyName = "activityTitle")]
            public string ActivityTitle { get; set; }

            [JsonProperty(PropertyName = "activitySubtitle")]
            public string ActivitySubtitle { get; set; }

            [JsonProperty(PropertyName = "facts")]
            public List<Fact> Facts { get; set; } = new List<Fact>();

            [JsonProperty(PropertyName = "text")]
            public string Text { get; set; }

            // Doesn't work ??
            [JsonProperty(PropertyName = "heroImage")]
            public Image HeroImage { get; set; }

            [JsonProperty(PropertyName = "images")]
            public List<Image> Images { get; set; } = new List<Image>();

            [JsonProperty(PropertyName = "potentialAction")]
            public List<Action> Actions { get; set; } = new List<Action>();

            public class Fact
            {
                [JsonProperty(PropertyName = "name")]
                public string Name { get; set; }

                [JsonProperty(PropertyName = "value")]
                public string Value { get; set; }
            }

            public class Image
            {
                [JsonProperty(PropertyName = "image")]
                public string ImageUrl { get; set; }

                public Image(string imageUrl)
                {
                    ImageUrl = imageUrl;
                }
            }

            public class Action
            {
                [JsonProperty(PropertyName = "@type")]
                public string ActionType { get; set; }

                [JsonProperty(PropertyName = "name")]
                public string Name { get; set; }

                [JsonProperty(PropertyName = "targets")]
                public List<Target> Targets { get; set; } = new List<Target>();

                public class Target
                {
                    [JsonProperty(PropertyName = "os")]
                    public string Os { get; set; } = "default";

                    [JsonProperty(PropertyName = "uri")]
                    public Uri Uri { get; set; }

                    public Target(Uri uri)
                    {
                        Uri = uri;
                    }
                }
            }
        }
    }
}

using System;
using TeamsWebhookPusher.CardBuilding;

namespace TeamsWebhookPusher
{
    class Program
    {
        static void Main(string[] args)
        {
            string uri;
            do
            {
                Console.WriteLine("Please provide a valid webhook uri :");
                uri = Console.ReadLine();
            } while (string.IsNullOrEmpty(uri) || !Uri.IsWellFormedUriString(uri, UriKind.RelativeOrAbsolute));

            do
            {
                Console.WriteLine("Pushing a card with a small image ...");
                Console.WriteLine(SendCardWithSmallImage(uri) ? "Success." : "Failed.");

                Console.WriteLine("Pushing a card with a hero image ...");
                Console.WriteLine(SendCardWithHeroImage(uri) ? "Success." : "Failed.");

                Console.WriteLine("Pushing a card with a hero image ...");
                Console.WriteLine(SendCardWithHeroImageInItsOwnSection(uri) ? "Success." : "Failed.");

                Console.WriteLine("Keep going ? y/N");
            } while (Console.ReadLine()?.ToLower() == "y");
        }

        private static bool SendCardWithSmallImage(string uri)
        {
            var section = new SectionBuilder()
                .SetActivityImage("https://pbs.twimg.com/profile_images/862653089916096512/ljJwcmFp_bigger.jpg")
                .SetActivityTitle("This is a card with a small image")
                .SetActivitySubtitle("This one works really well but I'd like a bigger image")
                .AddSmallImage("https://pbs.twimg.com/media/DFv74A0XkAEdwQ_.jpg")
                .AddAction(ActionType.OpenUri, "Open Microsoft's website",
                    new Uri("https://www.microsoft.com/fr-fr/"))
                .Build();

            var smallImageCard = new TeamsCardBuilder()
                .SetSummary("Small image card")
                .AddSection(section)
                .Build();

            return Pusher.TeamsWebhookPusher.PushEvent(new Uri(uri), smallImageCard).Result;
        }

        private static bool SendCardWithHeroImage(string uri)
        {
            var section = new SectionBuilder()
                .SetActivityImage("https://pbs.twimg.com/profile_images/862653089916096512/ljJwcmFp_bigger.jpg")
                .SetActivityTitle("This card has an hero image")
                .SetActivitySubtitle("This one should work but doesn't")
                .SetHeroImage("https://pbs.twimg.com/media/DFv74A0XkAEdwQ_.jpg")
                .AddAction(ActionType.OpenUri, "Open Microsoft's website",
                    new Uri("https://www.microsoft.com/fr-fr/"))
                .Build();

            var heroImageCard = new TeamsCardBuilder()
                .SetSummary("Hero image card")
                .AddSection(section)
                .Build();

            return Pusher.TeamsWebhookPusher.PushEvent(new Uri(uri), heroImageCard).Result;
        }

        private static bool SendCardWithHeroImageInItsOwnSection(string uri)
        {
            var section1 = new SectionBuilder()
                .SetActivityImage("https://pbs.twimg.com/profile_images/862653089916096512/ljJwcmFp_bigger.jpg")
                .SetActivityTitle("This card has an hero image in its second section")
                .SetActivitySubtitle("This is the first section")
                .AddAction(ActionType.OpenUri, "Open Microsoft's website",
                    new Uri("https://www.microsoft.com/fr-fr/"))
                .Build();

            var section2 = new SectionBuilder()
                .SetHeroImage("https://pbs.twimg.com/media/DFv74A0XkAEdwQ_.jpg")
                .Build();

            var heroImageCard = new TeamsCardBuilder()
                .SetSummary("Hero image card")
                .AddSection(section1)
                .AddSection(section2)
                .Build();

            return Pusher.TeamsWebhookPusher.PushEvent(new Uri(uri), heroImageCard).Result;
        }
    }
}
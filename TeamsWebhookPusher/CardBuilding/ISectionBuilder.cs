using System;

namespace TeamsWebhookPusher.CardBuilding
{
    // Please refer to https://messagecardplayground.azurewebsites.net/ to see each property's purpose
    public interface ISectionBuilder
    {
        TeamsCard.Section Build();

        ISectionBuilder SetActivityImage(string imageUrl);

        ISectionBuilder SetActivityTitle(string title);

        ISectionBuilder SetActivitySubtitle(string subTitle);

        ISectionBuilder SetActivityText(string text);

        ISectionBuilder AddFact(string factName, string factValue);

        ISectionBuilder AddSmallImage(string imageUrl);

        /// <summary>
        /// /!\ Doesn't seem to work atm
        /// </summary>
        /// <param name="imageUrl"></param>
        /// <returns></returns>
        ISectionBuilder SetHeroImage(string imageUrl);

        ISectionBuilder AddAction(ActionType type, string buttonText, Uri targetUrl);
    }
}
namespace TeamsWebhookPusher.CardBuilding
{
    // Please refer to https://messagecardplayground.azurewebsites.net/ to see each property's purpose
    public interface ICardBuilder
    {
        TeamsCard Build();

        ICardBuilder SetTitle(string title);

        ICardBuilder SetSummary(string summary);

        ICardBuilder SetText(string text);

        ICardBuilder SetThemeColor(string color);

        ICardBuilder AddSection(TeamsCard.Section section);
    }
}
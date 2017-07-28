namespace TeamsWebhookPusher.CardBuilding
{
    public class TeamsCardBuilder : ICardBuilder
    {
        private readonly TeamsCard _card = new TeamsCard();

        public TeamsCard Build()
        {
            return _card;
        }

        public ICardBuilder SetTitle(string title)
        {
            if (!string.IsNullOrEmpty(title))
            {
                _card.Title = title;
            }

            return this;
        }

        public ICardBuilder SetSummary(string summary)
        {
            if (!string.IsNullOrEmpty(summary))
            {
                _card.Summary = summary;
            }

            return this;
        }

        public ICardBuilder SetText(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                _card.Text = text;
            }

            return this;
        }

        public ICardBuilder SetThemeColor(string color)
        {
            if (!string.IsNullOrEmpty(color))
            {
                _card.ThemeColor = color;
            }

            return this;
        }

        public ICardBuilder AddSection(TeamsCard.Section section)
        {
            _card.Sections.Add(section);
            return this;
        }
    }
}

using System;
using System.Collections.Generic;

namespace TeamsWebhookPusher.CardBuilding
{
    public class SectionBuilder : ISectionBuilder
    {
        private readonly TeamsCard.Section _section = new TeamsCard.Section();

        public TeamsCard.Section Build()
        {
            return _section;
        }

        public ISectionBuilder SetActivityImage(string imageUrl)
        {
            if (!string.IsNullOrEmpty(imageUrl))
            {
                _section.ActivityImageUrl = imageUrl;
            }

            return this;
        }

        public ISectionBuilder SetActivityTitle(string title)
        {
            if (!string.IsNullOrEmpty(title))
            {
                _section.ActivityTitle = title;
            }

            return this;
        }

        public ISectionBuilder SetActivitySubtitle(string subTitle)
        {
            if (!string.IsNullOrEmpty(subTitle))
            {
                _section.ActivitySubtitle = subTitle;
            }

            return this;
        }

        public ISectionBuilder SetActivityText(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                _section.Text = text;
            }

            return this;
        }

        public ISectionBuilder AddFact(string factName, string factValue)
        {
            if (!string.IsNullOrEmpty(factName) && !string.IsNullOrEmpty(factValue))
            {
                _section.Facts.Add(new TeamsCard.Section.Fact
                {
                    Name = factName,
                    Value = factValue
                });

            }
            return this;
        }

        public ISectionBuilder AddSmallImage(string imageUrl)
        {
            if (!string.IsNullOrEmpty(imageUrl))
            {
                _section.Images.Add(new TeamsCard.Section.Image(imageUrl));
            }

            return this;
        }

        public ISectionBuilder SetHeroImage(string imageUrl)
        {
            if (!string.IsNullOrEmpty(imageUrl))
            {
                _section.HeroImage = new TeamsCard.Section.Image(imageUrl);
            }

            return this;
        }

        public ISectionBuilder AddAction(ActionType type, string buttonText, Uri targetUrl)
        {
            var action = new TeamsCard.Section.Action
            {
                ActionType = type.ToString(),
                Name = buttonText,
                Targets = new List<TeamsCard.Section.Action.Target>
                {
                    new TeamsCard.Section.Action.Target(targetUrl)
                }
            };

            _section.Actions.Add(action);
            return this;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TextAdventure.Exceptions;

namespace TextAdventure.Json
{
    class StoryDictionary
    {
        public Dictionary<string, Event> Events = new Dictionary<string, Event>();
        public Dictionary<string, string> ChoiceTexts = new Dictionary<string, string>();
        public string[] StartEvents = new string[0];

        public List<StoryElement> GetStartElements()
        {

            var storyDictionary = Events
                .ToDictionary(kv => kv.Key, kv => new StoryElement(kv.Value.Story));

            foreach (var item in storyDictionary)
            {
                Event e = Events[item.Key];
                var story = item.Value;

                foreach (var choice in e.Choices)
                {
                    if (!ChoiceTexts.TryGetValue(choice.Key, out string choiceText))
                    {
                        throw new StoryParseException($"Event '{item.Key}' has '{choice.Key}' listed in its choices but a choice text with that key doesnt exist.");
                    }
                    if (!storyDictionary.TryGetValue(choice.Value, out StoryElement nextChoiceKey))
                    {
                        throw new StoryParseException($"'{choice.Value}' was listed as choice result but there is no event with that key.");
                    }

                    story.Choices.Add(new StoryChoice(
                       choice: choiceText,
                       next: nextChoiceKey));
                }
            }

            var result = new List<StoryElement>();

            foreach (var key in StartEvents)
            {
                if (!storyDictionary.TryGetValue(key, out StoryElement story))
                {
                    throw new StoryParseException($"'{key}' was listed as start event but there is no event with that key.");
                }
                result.Add(storyDictionary[key]);

            }

            return result;
        }
    }
}

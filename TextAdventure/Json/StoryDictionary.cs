using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TextAdventure.Json
{
    class StoryDictionary
    {
        public Dictionary<string, Event> Events = new Dictionary<string, Event>();
        public Dictionary<string, string> ChoiceMappings = new Dictionary<string, string>();
        public string[] StartEvents = new string[0];

        public List<StoryElement> GetStartElements()
        {

            var storyDictionary = Events
                .ToDictionary(kv => kv.Key, kv => new StoryElement(kv.Value.Story));

            foreach (var item in storyDictionary)
            {
                Event e = Events[item.Key];
                var story = item.Value;

                foreach (var choice in e.ChoiceMappings)
                {
                    story.Choices.Add(new StoryChoice(
                       choice: ChoiceMappings[choice.Key],
                       next: storyDictionary[choice.Value]));
                }
            }

            var result = new List<StoryElement>();

            foreach (var key in StartEvents)
            {
                result.Add(storyDictionary[key]);
            }

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{
    class StoryChoice
    {
        public string Choice { get; set; }
        public StoryElement Next { get; set; }

        public StoryChoice(string choice, StoryElement next)
        {
            Choice = choice ?? throw new ArgumentNullException(nameof(choice));
            Next = next ?? throw new ArgumentNullException(nameof(next));
        }
    }
}

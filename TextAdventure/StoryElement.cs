using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{
    class StoryElement
    {
        public readonly string Story;

        public readonly List<StoryChoice> Choices = new List<StoryChoice>();

        public StoryElement(string story)
        {
            Story = story ?? throw new ArgumentNullException(nameof(story));
        }

        public StoryElement Display()
        {
            Console.WriteLine(Story);

            return SelectChoice().Next;
        }

        private StoryChoice SelectChoice()
        {
            while (true)
            {
                Console.WriteLine("What would you like to do?");

                PresentOptions();

                if (int.TryParse(Console.ReadKey().KeyChar + "", out int selectedOption)
                    && selectedOption > 0 && selectedOption <= Choices.Count)
                {
                    Console.WriteLine();
                    return Choices[selectedOption - 1];
                }
                else
                {
                    Console.WriteLine("Press a number key to make a choice");
                }
            }
        }

        private void PresentOptions()
        {

            for (int i = 0; i < Choices.Count; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"{i + 1}) {Choices[i].Choice}");
            }
        }
    }
}

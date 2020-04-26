using Newtonsoft.Json;
using System;
using System.IO;
using TextAdventure.Exceptions;
using TextAdventure.Json;

namespace TextAdventure
{
    class Program
    {
        static void Main()
        {
            var decisionPoint = GetStart();

            while (decisionPoint != null)
            {
                Console.Clear();
                decisionPoint = decisionPoint.Display();
            }
        }

        private static StoryElement GetStart()
        {
            try
            {
                var startElements = LoadDefaultStory().GetStartElements();

                int randomStartIndex = new Random().Next(startElements.Count);

                return startElements[randomStartIndex];
            }
            catch (StoryParseException ex)
            {
                Console.WriteLine($"Error loading story: {ex.Message}");
                return null;
            }
        }

        public static StoryDictionary LoadDefaultStory()
        {
            string appPath = System.Reflection.Assembly.GetExecutingAssembly().Location;

            string json = File.ReadAllText(Path.GetDirectoryName(appPath) + "/Story.json");

            return JsonConvert.DeserializeObject<StoryDictionary>(json);
        }
    }
}

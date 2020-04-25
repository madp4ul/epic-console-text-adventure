using Newtonsoft.Json;
using System;
using System.IO;
using TextAdventure.Json;

namespace TextAdventure
{
    class Program
    {
        static void Main()
        {
            var startElements = LoadDefaultStory().GetStartElements();

            int randomStartIndex = new Random().Next(startElements.Count);

            StoryElement decisionPoint = startElements[randomStartIndex];

            while (decisionPoint != null)
            {
                Console.Clear();
                decisionPoint = decisionPoint.Display();
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

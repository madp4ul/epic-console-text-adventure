using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure.Json
{
    class Event
    {
        public string Story { get; set; }
        public Dictionary<string, string> Choices { get; set; }
    }
}

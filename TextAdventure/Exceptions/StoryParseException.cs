using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure.Exceptions
{
    class StoryParseException : ApplicationException
    {
        public StoryParseException(string message) : base(message)
        {
        }
    }
}

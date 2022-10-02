using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Helper
{
    public static class RunntimeTemp
    {
        private static IUserMessage userMessage;

        public static IUserMessage UserMessage { get => userMessage; set => userMessage = value; }
    }
}

﻿using System;

namespace SteamToolkit
{
    public class ConsoleInputOutput : IUserInputOutputHandler
    {
        public string GetInput(string question, string title)
        {
            Console.Write(question);
            return Console.ReadLine();
        }

        public void OutputMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}

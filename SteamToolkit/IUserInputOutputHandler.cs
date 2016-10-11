﻿namespace SteamToolkit
{
    public interface IUserInputOutputHandler
    {
        string GetInput(string question, string title);
        void OutputMessage(string message);
    }
}

using System;

namespace SteamToolkit.Trading
{
    public class InventoryException : Exception
    {

        public InventoryException() { }

        public InventoryException(string message) : base(message) { }

        public InventoryException(string message, Exception inner) : base(message, inner){ }
    }
}
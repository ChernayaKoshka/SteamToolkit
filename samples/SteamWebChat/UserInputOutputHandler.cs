using System.Windows;
using SteamToolkit;

namespace SteamWebChat
{
    public class UserInputOutputHandler : IUserInputOutputHandler
    {
        public string GetInput(string question, string title)
        {
            string toReturn = null;
            Application.Current.Dispatcher.Invoke(()=>
            {
                var dialog = new InputDialogBox(question, title);
                toReturn = dialog.Result();
            });
            return toReturn;
        }

        public void OutputMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}

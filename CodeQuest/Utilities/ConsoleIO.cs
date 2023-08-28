using CodeQuest.Interfaces;

namespace CodeQuest.Utilities
{
    public class ConsoleIO : IConsoleIO
    {
        private ErrorMessages errorMessages = new ErrorMessages();

        public void PrintString(string output)
        {
            Console.WriteLine(output);
        }

        public string GetUserName()
        {
            // get all player names
            // check if name already exist
            // error message if it exist

            return Console.ReadLine();
        }

        public string GetUserInput()
        {
            return Console.ReadLine();
        }

        public void PrintPrompt()
        {
            Console.Write("> ");
        }

        public bool IsNumber(string userInput)
        {
            return Int32.TryParse(userInput, out _);
        }

        public int ConvertToInt(string userInput)
        {
            if (IsNumber(userInput))
            {
                return Convert.ToInt32(userInput);
            }

            //errorMessages.CouldNotConvertToInt(userInput);
            return 0;
        }

        public void PressAnyKey()
        {
            Console.ReadKey();
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void Exit()
        {
            Environment.Exit(0);
        }
    }
}

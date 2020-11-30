using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleChatApp
{
    public class ConsoleMenu<T>
    {
        public ConsoleMenuItem<T>[] MenuItems { get; set; }
        private string Description;
        private int selectedItemIndex = 0;
        private bool loopComplete = false;

        public ConsoleMenu(string description, IEnumerable<ConsoleMenuItem<T>> menuItems)
        {
            MenuItems = menuItems.ToArray();
            Description = description;
        }

        public void RunConsoleMenu()
        {
            //this will resize the console if the amount of elements in the list are too big
            if ((MenuItems.Count()) > Console.WindowHeight)
            {
                //TODO: Deal with console paging...
            }

            if (!string.IsNullOrEmpty(Description))
            {
                Console.WriteLine($"{Description}: {Environment.NewLine}");
            }

            var topOffset = Console.CursorTop;
            var bottomOffset = 0;
            ConsoleKeyInfo kb;
            Console.CursorVisible = false;


            while (!loopComplete)
            {
                for (var i = 0; i < MenuItems.Length; i++)
                {
                    WriteConsoleItem(i, selectedItemIndex);
                }

                bottomOffset = Console.CursorTop;
                kb = Console.ReadKey(true);
                HandleKeyPress(kb.Key);

                //Reset the cursor to the top of the screen
                Console.SetCursorPosition(0, topOffset);
            }

            //set the cursor just after the menu so that the program can continue after the menu
            Console.SetCursorPosition(0, bottomOffset);
            Console.CursorVisible = true;
            loopComplete = false;
            MenuItems[selectedItemIndex].CallBack.Invoke(MenuItems[selectedItemIndex].UnderlyingObject);
        }

        private void HandleKeyPress(ConsoleKey pressedKey)
        {
            switch (pressedKey)
            {
                case ConsoleKey.UpArrow:
                    selectedItemIndex = (selectedItemIndex == 0) ? MenuItems.Length - 1 : selectedItemIndex - 1;
                    break;

                case ConsoleKey.DownArrow:
                    selectedItemIndex = (selectedItemIndex == MenuItems.Length - 1) ? 0 : selectedItemIndex + 1;
                    break;

                case ConsoleKey.Enter:
                    loopComplete = true;
                    break;
            }
        }

        private void WriteConsoleItem(int itemIndex, int selectedItemIndex)
        {
            if (itemIndex == selectedItemIndex)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
            }

            Console.WriteLine(" {0,-20}", this.MenuItems[itemIndex].Name);
            Console.ResetColor();
        }
    }
}
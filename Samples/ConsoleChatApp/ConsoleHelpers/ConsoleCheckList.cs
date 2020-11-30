using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleChatApp
{
    public class ConsoleCheckList<T>
    {
        private Dictionary<int, bool> _selectedItems;
        public ConsoleCheckListItem<T>[] MenuItems { get; set; }
        private string Description;
        private int selectedItemIndex = 0;
        private bool loopComplete = false;

        public ConsoleCheckList(string description, IEnumerable<ConsoleCheckListItem<T>> menuItems)
        {
            MenuItems = menuItems.ToArray();
            _selectedItems = new Dictionary<int, bool>(MenuItems.Length);
            for(var i = 0; i <= MenuItems.Length; i++)
            {
                _selectedItems[i] = false;
            }
            Description = description;
        }

        public void RunConsoleCheckList()
        {
            //this will resise the console if the amount of elements in the list are too big
            if ((MenuItems.Count()) > Console.WindowHeight)
            {
                //TODO: Deal with console pagging...
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
            var selectedItems = _selectedItems
                .Where(i => i.Value == true)
                .Select(i => i.Key)
                .ToArray();
            MenuItems[selectedItemIndex].CallBack.Invoke(MenuItems[selectedItemIndex].UnderlyingObject, selectedItems);
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
					
                case ConsoleKey.Spacebar:
                    _selectedItems[selectedItemIndex] = !_selectedItems[selectedItemIndex];
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

            if(_selectedItems[itemIndex])
                Console.WriteLine(" {0,-20} [x]", this.MenuItems[itemIndex].Name);
            else
                Console.WriteLine(" {0,-20} [ ]", this.MenuItems[itemIndex].Name);          
            Console.ResetColor();
        }
    }
}
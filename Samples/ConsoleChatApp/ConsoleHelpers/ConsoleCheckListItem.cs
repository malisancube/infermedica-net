using System;

namespace ConsoleChatApp
{
    public class ConsoleCheckListItem<T>
    {
        public string Name { get; set; }
        public Action<T, int[]> CallBack { get; set; }
        public T UnderlyingObject { get; set; }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ UnderlyingObject.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            // Check for null values and compare run - time types.
            if (obj == null || GetType() != obj.GetType())
                return false;

            var item = (ConsoleMenuItem<T>)obj;
            return item.GetHashCode() == this.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Name} (data: {UnderlyingObject.ToString()})";
        }

        public ConsoleCheckListItem(string label, Action<T, int[]> callback, T underlyingObject)
        {
            Name = label;
            CallBack = callback;
            UnderlyingObject = underlyingObject;
        }
    }
}
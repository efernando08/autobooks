using System;

namespace GroceryStore.Domain
{
    public class Customer
    {
        private int id;
        private string name;

        public int Id
        {
            get { return id; }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length <= 64)
                    name = value;
                else
                    throw new ArgumentOutOfRangeException("Name", "Must be 64 characters or less");
            }
        }

        private Customer() { }

        internal Customer(int id, string name)
        {
            this.id = id;
            Name = name;
        }
    }
}

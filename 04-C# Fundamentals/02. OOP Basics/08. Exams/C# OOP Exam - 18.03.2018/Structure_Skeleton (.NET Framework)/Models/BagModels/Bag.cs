using DungeonsAndCodeWizards.Models.ItemModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonsAndCodeWizards.Models.BagModels
{
    public abstract class Bag
    {
        private int capacity;
        private ICollection<Item> items;

        protected Bag(int capacity = 100)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        public int Capacity
        {
            get { return capacity; }
            private set {  capacity = value; }
        }

        public IReadOnlyCollection<Item> Items
        {
            get { return (IReadOnlyCollection<Item>)items; }
        }

        public int Load => this.Items.Sum(i => i.Weight);

        public void AddItem(Item item)
        {
            if(this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if(this.items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            Item item = this.items.FirstOrDefault(i => i.GetType().Name == name);

            if(item == null)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            this.items.Remove(item);

            return item;
        }
    }
}

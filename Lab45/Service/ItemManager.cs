using Lab45.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab45.Service
{
    public class ItemManager
    {
        private List<Item> items = new List<Item>();

        public void AddItem(Item item)
        {
            items.Add(item);
        }

        public void UpdateItem(int id, string newName)
        {
            var item = items.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                item.Name = newName;
            }
        }

        public void DeleteItem(int id)
        {
            items.RemoveAll(i => i.Id == id);
        }     
    }
}

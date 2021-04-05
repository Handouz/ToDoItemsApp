using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoItems.Models;

namespace ToDoItems.Data
{
    public class ToDoItemsRepository : IToDoRepository
    {
        private readonly ToDoItemsContext context;

        public ToDoItemsRepository(ToDoItemsContext _context)
        {
            context = _context;
        }
        public ToDoItem GetToDoItemByID(int id)
        {
            return context.ToDoItems.FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<ToDoItem> GetAllToDoItems()
        {
            return context.ToDoItems.ToList();
        }

        public void CreateToDoItem(ToDoItem item)
        {
            if (item==null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            context.ToDoItems.Add(item);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() >= 0;
        }

        public void UpdateToDoItem(ToDoItem item)
        {
            //
        }
    }
}

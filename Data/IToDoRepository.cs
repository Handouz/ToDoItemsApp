using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoItems.Models;

namespace ToDoItems.Data
{
    public interface IToDoRepository
    {
        IEnumerable<ToDoItem> GetAllToDoItems();
        ToDoItem GetToDoItemByID(int id);
        void CreateToDoItem(ToDoItem item);
        bool SaveChanges();
        void UpdateToDoItem(ToDoItem item);

    }
}

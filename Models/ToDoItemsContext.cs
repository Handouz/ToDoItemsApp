using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoItems.Models
{
    public class ToDoItemsContext : DbContext
    {
        public ToDoItemsContext(DbContextOptions<ToDoItemsContext> options) : base(options)
        {
        }
        public DbSet<ToDoItem> ToDoItems { get; set; }
    }
}

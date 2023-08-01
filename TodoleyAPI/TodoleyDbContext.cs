using Microsoft.EntityFrameworkCore;
using TodoleyAPI.Models;

namespace TodoleyAPI
{
    public class TodoleyDbContext:DbContext
    {
        public TodoleyDbContext(DbContextOptions<TodoleyDbContext> options) : base(options)
        {

        }
        DbSet<TodoItem> TodoItems { get; set; }
        DbSet<TodoList> TodoList { get; set; }
    }
}

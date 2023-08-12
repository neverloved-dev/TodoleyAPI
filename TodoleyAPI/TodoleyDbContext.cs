using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TodoleyAPI.Models;

namespace TodoleyAPI
{
    public class TodoleyDbContext:DbContext
    {
        public TodoleyDbContext(DbContextOptions<TodoleyDbContext> options) : base(options)
        {

        }
        public DbSet<TodoItem> TodoItems { get; set; }
       public  DbSet<TodoList> TodoList { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

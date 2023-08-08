using Microsoft.Identity.Client;
using TodoleyAPI.DTO;
using TodoleyAPI.Models;

namespace TodoleyAPI.Services.TodoItemsService
{
    public class TodoItemsService : ITodoItemsService
    {
        TodoleyDbContext _dbContext;
        public TodoItemsService(TodoleyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<TodoItem> GetAll()
        {
            return _dbContext.TodoItems.ToList();
        }
        public TodoItem GetById(int id)
        {
            return _dbContext.TodoItems.Find(id);
        }

        public List<TodoItem> GetByDueDate(DateTime dueDate)
        {
            return _dbContext.TodoItems.Where(x => x.DueDate == dueDate).ToList();
        }

        public List<TodoItem> GetByTitle(string title)
        {
            return _dbContext.TodoItems.Where(x => x.Title == title).ToList();
        }

        public void Add(TodoItem item)
        {
            _dbContext.Add(item);
            _dbContext.SaveChanges();
        }
        public void Update(TodoItem item)
        {
            var _oldItem = _dbContext.TodoItems.FirstOrDefault(x => x.Id == item.Id);
            _oldItem = item;
            _dbContext.TodoItems.Update(_oldItem);
            _dbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            var item = _dbContext.TodoItems.FirstOrDefault(x=>x.Id == id);
            _dbContext.SaveChanges();
        }
    }
}

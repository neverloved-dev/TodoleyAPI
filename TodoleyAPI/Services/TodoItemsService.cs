using TodoleyAPI.Models;
using TodoleyAPI;
namespace TodoleyAPI.Services
{
    public class TodoItemsService
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

        public List<TodoItem>GetByTitle(string title) 
        {
            return _dbContext.TodoItems.Where(x=>x.Title == title).ToList();
        }

        public void Add(TodoItem item) 
        {
            _dbContext.Add(item);
        }
        public void Update(TodoItem item) 
        {
            // TO IMPLEMENT
        }
        public void Delete(int id) 
        {
            // TO IMPLEMENT
        }
    }
}

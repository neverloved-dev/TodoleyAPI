﻿using TodoleyAPI.DTO;
using TodoleyAPI.Models;

namespace TodoleyAPI.Services.TodoItemsService
{
    public interface ITodoItemsService
    {
        public List<TodoItem> GetAll();
        public void Add(TodoItem item);
        public void Update(TodoItem item);
        public void Delete(int id);
        public List<TodoItem>GetByDueDate(DateTime dueDate);
        public List<TodoItem> GetByTitle(string title);
        public TodoItem GetById(int id);
    }
}

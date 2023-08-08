using System.ComponentModel.DataAnnotations;

namespace TodoleyAPI.Models
{
    public class TodoList
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public List<TodoItem> Items { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }
    }
}

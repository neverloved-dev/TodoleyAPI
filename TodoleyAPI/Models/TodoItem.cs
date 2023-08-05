using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace TodoleyAPI.Models
{
    public class TodoItem
    {
        [Required]
        [NotNull]
        public int Id { get; set; }
        [Required]
        [NotNull]
        public string Title { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get;set; }
        [DataType(DataType.Date)]
        public DateTime DueDate { get;set; }
        public int TodoItemListId { get; set; }  
    }
}

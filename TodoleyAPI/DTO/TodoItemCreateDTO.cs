using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace TodoleyAPI.DTO
{
   public record struct TodoItemCreateDTO(string Title,string Description,DateTime createDate, DateTime dueDate, int listID);
}

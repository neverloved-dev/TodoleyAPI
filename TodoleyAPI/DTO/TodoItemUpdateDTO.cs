namespace TodoleyAPI.DTO
{
    public record struct TodoItemUpdateDTO(string Title,string Description, DateTime dueDate,int listID);
}

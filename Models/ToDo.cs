using System.ComponentModel.DataAnnotations;

namespace ToDoListApi.Models
{
    public class ToDo
    {
        public int Id { get; set; }

       // [Required]
        [MaxLength(30)]
        public string Title { get; set; }

        
        public ToDoStatus status { get; set; } = (ToDoStatus)0;
    }
}

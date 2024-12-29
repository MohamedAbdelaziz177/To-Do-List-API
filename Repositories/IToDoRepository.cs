using ToDoListApi.Models;

namespace ToDoListApi.Repositories
{
    public interface IToDoRepository
    {
        public List<ToDo> GetAll();
        public ToDo GetByName(string name);
        public void Insert(ToDo toDo);

        public void Complete(int id, ToDo todo);

        public void Delete(int id);
        
        

    }
}

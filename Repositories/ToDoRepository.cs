using ToDoListApi.Models;

namespace ToDoListApi.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly AppDbContext con;

        public ToDoRepository(AppDbContext con) 
        {
            this.con = con;
        }

        public List<ToDo> GetAll()
        {
            var lstOfToDo = con.toDos.ToList();
            return lstOfToDo;
        }

        public ToDo GetByName(string name) 
        {
            var toDo = con.toDos.FirstOrDefault(x => x.Title == name);
            return toDo;
        }

        public void Insert(ToDo toDo)
        {
            con.toDos.Add(toDo);
            con.SaveChanges();
        }

        public void Complete(int id, ToDo todo)
        {
            var toDo = con.toDos.Find(id);

            toDo.Title = todo.Title;
            toDo.status = (ToDoStatus)1;

            con.SaveChanges();

        }

        public void Delete(int id) 
        {
            var toDo = con.toDos.Find(id);
            con.toDos.Remove(toDo);

            con.SaveChanges();
        }

       
    }
}

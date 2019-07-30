using Microsoft.EntityFrameworkCore;

namespace ToDoList.Models
{
    public class ToDoListContext: DbContext
    {
        public ToDoListContext(DbContextOptions <ToDoListContext> options)
            :base(options)
        {
        }

        public DbSet<TaskModel> Task{get;set;}
    }
}
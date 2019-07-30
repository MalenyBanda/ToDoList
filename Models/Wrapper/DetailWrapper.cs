using ToDoList.Models;

namespace ToDoList.Wrapper
{
    public class DetailWrapper:BaseResponse
    {
        private TaskModel _task;
        public TaskModel Task{get;set;}

        public DetailWrapper() => _task = new TaskModel();
    }
}
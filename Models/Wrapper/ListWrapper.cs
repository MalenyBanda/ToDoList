using System.Collections.Generic;
using ToDoList.Models;

namespace ToDoList.Wrapper{
    public class ListWrapper:BaseResponse{
        public IEnumerable<TaskModel> Tasks{get;set;}
    }
}
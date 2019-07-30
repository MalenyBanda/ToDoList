using System.Collections.Generic;
using ToDoList.Models;
public interface IMySqlDataService
{
    IEnumerable<TaskModel> GetTasks();
    TaskModel GetTask(int id);
    TaskModel GetTask(string name);
    bool EditTask(TaskModel task);
    bool DeleteTask(int id);
    bool Add(TaskModel task);
    int MaxIndex();
    bool Exists(int id);
}
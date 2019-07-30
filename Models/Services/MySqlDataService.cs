using System.Collections.Generic;
using ToDoList.Models;
using System.Linq;
using System;
public class MySqlDataService : IMySqlDataService
{
    private readonly ToDoListContext _context;

    public MySqlDataService(ToDoListContext context) => _context = context;
    public bool Add(TaskModel task)
    {
        _context.Add(task);
        _context.SaveChanges();
        return true;
    }
    public bool DeleteTask(int id)
    {
        try{
            var taskToDelete=_context.Task.Where(task=>task.Id==id).First();
            if(taskToDelete !=null)
            {
                _context.Task.Remove(taskToDelete);
                _context.SaveChanges();
                return true;
            }
            else return false;
        }catch(Exception)
        {return false;}
    }

    public bool EditTask(TaskModel task)
    {
        var edit=_context.Task.Where(x=>x.Id==task.Id).FirstOrDefault();
        if(edit != null)
        {
            edit.Name=task.Name;
            edit.Content=task.Content;
            _context.Task.Update(edit);
            _context.SaveChanges();
            return true;
        }
        else
        return false;
        
    }

    public TaskModel GetTask(int id)
    {
        //var tasks= _context.Task.Where(x=>x.Id==id).Select(task=> new TaskModel{Name=task.Name,Id=task.Id,Content=task.Content}).FirstOrDefault();
        var tasks= _context.Task.Find(id);
        return tasks;

    }

    public TaskModel GetTask(string name)
    {
        throw new System.NotImplementedException();
    }

    public IEnumerable<TaskModel> GetTasks()
    {
        var tasks= _context.Task.Select(task=> new TaskModel{Name=task.Name,Id=task.Id,Content=task.Content});
        return tasks;
    }
    public int MaxIndex() =>_context.Task.OrderByDescending(x=>x.Id).FirstOrDefault().Id;

    public bool Exists(int id)
    {
        bool t=_context.Task.Any(e => e.Id == id);
        return t;
    }
    
}

using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Wrapper;
using System.Linq;

namespace ToDoList.Controllers
{
    [Produces("application/json")]
    public class TaskController: Controller{
        private readonly IMySqlDataService _myService;

        public TaskController(IMySqlDataService service) => _myService = service;

        [HttpGet]
        public JsonResult All() => Json(new ListWrapper(){ Tasks=_myService.GetTasks(),Error="OK",ErrorId=0});

        [HttpGet]
        public JsonResult Detail(int id) 
        {
            var response= new DetailWrapper();
            var task=_myService.GetTask(id);
            if(task!= null)
            {
                response.Task=task;
                response.ErrorId=0;
                response.Error="OK";
            }
            else{
                response.ErrorId=-1;
                response.Error="No existe";
            }
            return Json(response);
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var response = new BaseResponse();
            if (id >0)
            {
                Json(_myService.DeleteTask(id));
                response.ErrorId=0;
                response.Error="OK";
            }
            else
            {
                response.ErrorId=-1;
                response.Error="Id required";
            }
            return Json(response);
        }

        [HttpPost]
        public JsonResult Add([FromBody]TaskModel task)
        {
           var response= new AddWrapper();
            if (string.IsNullOrEmpty(task.Name) || string.IsNullOrEmpty(task.Content))
            {
                response.ErrorId=-1;
                response.Error="Error";
            }
            else
            {
                _myService.Add(task);
                response.Id=_myService.MaxIndex();
                response.ErrorId=0;
                response.Error="OK";
            }
            return Json(response);
        }

        [HttpPost]
        public JsonResult Edit ([FromBody] TaskModel task)
        {
            var response = new EditWrapper();
            if(task.Id==0)
            {
                response.ErrorId=-1;
                response.Error="Id requerido";
            }
            else{
                if(_myService.EditTask(task)){
                    response.TaskId=task.Id;
                    response.ErrorId=0;
                    response.Error="OK"; 
                }
                else{
                    response.ErrorId=-1;
                    response.Error="Error"; 
                }
                
                
            } 
            return Json(response);
        }
    }
}
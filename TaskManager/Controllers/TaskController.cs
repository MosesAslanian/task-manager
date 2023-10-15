using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        public static List<TaskModel> tasks = new();
        private static readonly object lockObject = new();
        private static int taskIdCounter = 0;

        [HttpPost]
        public IActionResult CreateTask(TaskModel task)
        {
            lock (lockObject)
            {
                task.Id = taskIdCounter++;
                tasks.Add(task);
            }
            var response = new
            {
                task.Id,
                Message = "Task created successfully"
            };

            var jsonResult = new JsonResult(response)
            {
                StatusCode = 201
            };

            return jsonResult;
        }
    }
}
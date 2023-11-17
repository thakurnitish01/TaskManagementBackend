using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using taskManagementBackend.Models;

namespace taskManagementBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TaskController : Controller
    {
        private readonly taskContext _taskContext;

        public TaskController(taskContext taskContext)
        {
            _taskContext = taskContext;
        }

        [HttpPost]
        public async Task<ActionResult<taskModel>> postTask(taskModel task)
        {
             _taskContext.taskModel.Add(task);
            await _taskContext.SaveChangesAsync();

            return task;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<taskModel>>> GetTask()
        {
            var data = await _taskContext.taskModel.ToListAsync();

            if (data == null || !data.Any())
            {
                return NotFound();
            }

            return Ok(data);
        }

    }
}

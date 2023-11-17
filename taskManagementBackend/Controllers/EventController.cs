using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using taskManagementBackend.Models;

namespace taskManagementBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EventController : Controller
    {
        private readonly eventContext _eventContext;

        public EventController(eventContext taskContext)
        {
            _eventContext = taskContext;
        }

        [HttpPost]
        public async Task<ActionResult<eventModel>> postTask(eventModel task)
        {
            _eventContext.eventModel.Add(task);
            await _eventContext.SaveChangesAsync();

            return task;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<eventModel>>> GetTask()
        {
            var data = await _eventContext.eventModel.ToListAsync();

            if (data == null || !data.Any())
            {
                return NotFound();
            }

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<eventModel>>> GetTaskbyId(int id)
        {
           var dataId =  await _eventContext.eventModel.FindAsync(id);
            if(dataId == null)
            {
                return NotFound();
            }
            await _eventContext.SaveChangesAsync();
            return Ok(dataId);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<IEnumerable<eventModel>>> updateTask(eventModel task, int id)
        {
            if(id != task.Id) 
            {
               return BadRequest(task.Id);
            }
            _eventContext.Update(task);
           await _eventContext.SaveChangesAsync();

            return Ok("SuccessFully update the Item..");
        }

        [HttpDelete]
        public async Task<ActionResult<List<eventModel>>> deleteTask(int id)
        {
            var deletedItem = await _eventContext.eventModel.FindAsync(id);
            var dataId = await _eventContext.eventModel.FindAsync(id);
            if (deletedItem != dataId) 
            {
                return NotFound();
            }
            _eventContext.eventModel.Remove(deletedItem);
            await _eventContext.SaveChangesAsync();
            return Ok("successfully Deleted..!");
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using WebApi.Dtos;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribersController : ControllerBase
    {
        private readonly DataContext _context;

        public SubscribersController(DataContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<ActionResult<SubscriberEntity>> PostSubscriber([FromBody] SubscriberDto subscriberDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingSubscriber = await _context.Subscribers.FirstOrDefaultAsync(s => s.Email == subscriberDto.Email);
            if (existingSubscriber != null)
            {
                return BadRequest("Subscriber already exists.");
            }

            var subscriber = new SubscriberEntity { Email = subscriberDto.Email };
            _context.Subscribers.Add(subscriber);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubscriber", new { id = subscriber.Id }, subscriber);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubscriberEntity>> GetSubscriber(int id)
        {
            var subscriber = await _context.Subscribers.FindAsync(id);

            if (subscriber == null)
            {
                return NotFound();
            }

            return subscriber;
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscriber(int id)
        {
            var subscriber = await _context.Subscribers.FindAsync(id);
            if (subscriber == null)
            {
                return NotFound();
            }

            _context.Subscribers.Remove(subscriber);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

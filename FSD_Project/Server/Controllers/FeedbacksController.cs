using FSD_Project.Server.IRepository;
using FSD_Project.Shared.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FSD_Project.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FeedbacksController : ControllerBase
	{
		//private readonly ApplicationDbContext _context;
		private readonly IUnitOfWork _unitOfWork;

		//public FeedbacksController(ApplicationDbContext context)
		public FeedbacksController(IUnitOfWork unitOfWork)
		{
			// _context = context;
			_unitOfWork = unitOfWork;
		}

		// GET: api/Feedbacks
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Feedback>>> GetFeedbacks()
		{
			//if (_context.Feedbacks == null)
			//{
			//    return NotFound();
			//}
			//  return await _context.Feedbacks.ToListAsync();
			var feedbacks = await _unitOfWork.Feedbacks.GetAll();
			return Ok(feedbacks);
		}

		// GET: api/Feedbacks/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Feedback>> GetFeedback(int id)
		{
			var feedback = await _unitOfWork.Feedbacks.Get(q => q.Id == id);

			if (feedback == null)
			{
				return NotFound();
			}
			return Ok(feedback);
		}

		// PUT: api/Feedbacks/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutFeedback(int id, Feedback feedback)
		{
			if (id != feedback.Id)
			{
				return BadRequest();
			}

			_unitOfWork.Feedbacks.Update(feedback);

			try
			{
				await _unitOfWork.Save(HttpContext);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await FeedbackExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/Feedbacks
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Feedback>> PostFeedback(Feedback feedback)
		{
			await _unitOfWork.Feedbacks.Insert(feedback);
			await _unitOfWork.Save(HttpContext);

			return CreatedAtAction("GetFeedback", new { id = feedback.Id }, feedback);
		}

		// DELETE: api/Feedbacks/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteFeedback(int id)
		{
			var feedback = await _unitOfWork.Feedbacks.Get(q => q.Id == id);
			if (feedback == null)
			{
				return NotFound();
			}

			await _unitOfWork.Feedbacks.Delete(id);
			await _unitOfWork.Save(HttpContext);

			return NoContent();
		}

		private async Task<bool> FeedbackExists(int id)
		{
			var feedback = await _unitOfWork.Feedbacks.Get(q => q.Id == id);
			return feedback != null;
		}
	}
}
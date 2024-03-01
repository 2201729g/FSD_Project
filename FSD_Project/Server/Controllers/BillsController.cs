using FSD_Project.Server.Data;
using FSD_Project.Server.IRepository;
using FSD_Project.Shared.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FSD_Project.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BillsController : ControllerBase
	{
		//private readonly ApplicationDbContext _context;
		private readonly IUnitOfWork _unitOfWork;

		//public BillsController(ApplicationDbContext context)
		public BillsController(IUnitOfWork unitOfWork)
		{
			// _context = context;
			_unitOfWork = unitOfWork;
		}

		// GET: api/Bills
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Bill>>> GetBills()
		{
			//if (_context.Bills == null)
			//{
			//    return NotFound();
			//}
			//  return await _context.Bills.ToListAsync();
			var bills = await _unitOfWork.Bills.GetAll();
			return Ok(bills);
		}

		// GET: api/Bills/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Bill>> GetBill(int id)
		{
			var bill = await _unitOfWork.Bills.Get(q => q.Id == id);

			if (bill == null)
			{
				return NotFound();
			}
			return Ok(bill);
		}

		// PUT: api/Bills/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutBill(int id, Bill bill)
		{
			if (id != bill.Id)
			{
				return BadRequest();
			}

			_unitOfWork.Bills.Update(bill);

			try
			{
				await _unitOfWork.Save(HttpContext);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await BillExists(id))
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

		// POST: api/Bills
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Bill>> PostBill(Bill bill)
		{
			await _unitOfWork.Bills.Insert(bill);
			await _unitOfWork.Save(HttpContext);

			return CreatedAtAction("GetBill", new { id = bill.Id }, bill);
		}

		// DELETE: api/Bills/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteBill(int id)
		{
			var bill = await _unitOfWork.Bills.Get(q => q.Id == id);
			if (bill == null)
			{
				return NotFound();
			}

			await _unitOfWork.Bills.Delete(id);
			await _unitOfWork.Save(HttpContext);

			return NoContent();
		}

		private async Task<bool> BillExists(int id)
		{
			var bill = await _unitOfWork.Bills.Get(q => q.Id == id);
			return bill != null;
		}
	}
}

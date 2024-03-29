﻿using FSD_Project.Server.IRepository;
using FSD_Project.Shared.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FSD_Project.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DriversController : ControllerBase
	{
		//private readonly ApplicationDbContext _context;
		private readonly IUnitOfWork _unitOfWork;

		//public DriversController(ApplicationDbContext context)
		public DriversController(IUnitOfWork unitOfWork)
		{
			// _context = context;
			_unitOfWork = unitOfWork;
		}

		// GET: api/Drivers
		[HttpGet]
		//public async Task<ActionResult<IEnumerable<Driver>>> GetDrivers()
		public async Task<IActionResult> GetDrivers()
		{
			//if (_context.Drivers == null)
			//{
			//    return NotFound();
			//}
			//  return await _context.Drivers.ToListAsync();
			var drivers = await _unitOfWork.Drivers.GetAll();
			return Ok(drivers);
		}

		// GET: api/Drivers/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetDriver(int id)
		{
			var driver = await _unitOfWork.Drivers.Get(q => q.Id == id);

			if (driver == null)
			{
				return NotFound();
			}
			return Ok(driver);
		}

		// PUT: api/Drivers/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutDriver(int id, Driver driver)
		{
			if (id != driver.Id)
			{
				return BadRequest();
			}

			_unitOfWork.Drivers.Update(driver);

			try
			{
				await _unitOfWork.Save(HttpContext);
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await DriverExists(id))
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

		// POST: api/Drivers
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Driver>> PostDriver(Driver driver)
		{
			await _unitOfWork.Drivers.Insert(driver);
			await _unitOfWork.Save(HttpContext);

			return CreatedAtAction("GetDriver", new { id = driver.Id }, driver);
		}

		// DELETE: api/Drivers/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteDriver(int id)
		{
			var driver = await _unitOfWork.Drivers.Get(q => q.Id == id);
			if (driver == null)
			{
				return NotFound();
			}

			await _unitOfWork.Drivers.Delete(id);
			await _unitOfWork.Save(HttpContext);

			return NoContent();
		}

		private async Task<bool> DriverExists(int id)
		{
			var driver = await _unitOfWork.Drivers.Get(q => q.Id == id);
			return driver != null;
		}
	}
}
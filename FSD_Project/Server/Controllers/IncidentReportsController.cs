using FSD_Project.Server.IRepository;
using FSD_Project.Shared.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FSD_Project.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentReportsController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //public IncidentReportsController(ApplicationDbContext context)
        public IncidentReportsController(IUnitOfWork unitOfWork)
        {
            // _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/IncidentReports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IncidentReport>>> GetIncidentReports()
        {
            //if (_context.IncidentReports == null)
            //{
            //    return NotFound();
            //}
            //  return await _context.IncidentReports.ToListAsync();
            var incidentReports = await _unitOfWork.IncidentReports.GetAll();
            return Ok(incidentReports);
        }

        // GET: api/IncidentReports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IncidentReport>> GetIncidentReport(int id)
        {
            var incidentReport = await _unitOfWork.IncidentReports.Get(q => q.Id == id);

            if (incidentReport == null)
            {
                return NotFound();
            }
            return Ok(incidentReport);
        }

        // PUT: api/IncidentReports/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncidentReport(int id, IncidentReport incidentReport)
        {
            if (id != incidentReport.Id)
            {
                return BadRequest();
            }

            _unitOfWork.IncidentReports.Update(incidentReport);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await IncidentReportExists(id))
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

        // POST: api/IncidentReports
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IncidentReport>> PostIncidentReport(IncidentReport incidentReport)
        {
            await _unitOfWork.IncidentReports.Insert(incidentReport);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetIncidentReport", new { id = incidentReport.Id }, incidentReport);
        }

        // DELETE: api/IncidentReports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncidentReport(int id)
        {
            var incidentReport = await _unitOfWork.IncidentReports.Get(q => q.Id == id);
            if (incidentReport == null)
            {
                return NotFound();
            }

            await _unitOfWork.IncidentReports.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> IncidentReportExists(int id)
        {
            var incidentReport = await _unitOfWork.IncidentReports.Get(q => q.Id == id);
            return incidentReport != null;
        }
    }
}
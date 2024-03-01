
using FSD_Project.Server.Data;
using FSD_Project.Server.IRepository;
using FSD_Project.Server.Models;
using FSD_Project.Shared.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;



namespace FSD_Project.Server.Repository
{
    public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _context;
		private IGenericRepository<Bill> _bills;
		private IGenericRepository<Customer> _customers;
		private IGenericRepository<Driver> _drivers;
		private IGenericRepository<Feedback> _feedbacks;
        private IGenericRepository<IncidentReport> _incidentReports;


        private UserManager<ApplicationUser> _userManager;

		public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
		{
			_context = context;
			_userManager = userManager;
		}

		public IGenericRepository<Bill> Bills
			=> _bills ??= new GenericRepository<Bill>(_context);
		public IGenericRepository<Driver> Drivers
			=> _drivers ??= new GenericRepository<Driver>(_context);
		public IGenericRepository<Customer> Customers
			=> _customers ??= new GenericRepository<Customer>(_context);
		public IGenericRepository<Feedback> Feedbacks
			=> _feedbacks ??= new GenericRepository<Feedback>(_context);
        public IGenericRepository<IncidentReport> IncidentReports
            => _incidentReports ??= new GenericRepository<IncidentReport>(_context);

       
        public void Dispose()
		{
			_context.Dispose();
			GC.SuppressFinalize(this);
		}

		public async Task Save(HttpContext httpContext)
		{
			//To be implemented
			string user = "System";

			var entries = _context.ChangeTracker.Entries()
				.Where(q => q.State == EntityState.Modified ||
					q.State == EntityState.Added);

			foreach (var entry in entries)
			{

			}

			await _context.SaveChangesAsync();
		}
	}
}
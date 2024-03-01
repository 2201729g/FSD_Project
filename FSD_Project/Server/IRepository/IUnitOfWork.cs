
using FSD_Project.Server.IRepository;
using FSD_Project.Shared.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.ConstrainedExecution;


namespace FSD_Project.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<Bill> Bills { get; }
        IGenericRepository<Driver> Drivers { get; }
        IGenericRepository<Customer> Customers { get; }
        IGenericRepository<Feedback> Feedbacks { get; }
        IGenericRepository<IncidentReport> IncidentReports { get; }


    }
}
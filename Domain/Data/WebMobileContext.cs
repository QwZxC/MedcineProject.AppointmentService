using MedicineProject.AppointmentService.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicineProject.AppointmentService.Domain.Context
{
    public sealed class WebMobileContext : DbContext
    {
        public DbSet<Appointment> Appointment { get; set; }

        public DbSet<Models.Type> Type { get; set; }

        public WebMobileContext(DbContextOptions<WebMobileContext> options) 
            : base(options) 
        {
        }
    }
}

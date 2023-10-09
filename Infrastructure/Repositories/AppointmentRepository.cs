using MedicineProject.AppointmentService.Domain.Context;
using MedicineProject.AppointmentService.Domain.Models;
using MedicineProject.AppointmentService.Domain.Repositories;

namespace MedicineProject.AppointmentService.Infrastructure.Repositories
{
    public class AppointmentRepository : BaseRepository, IAppointmentRepository
    {
        public AppointmentRepository(WebMobileContext context) : base(context) 
        { 
        }

        public async void DeleteTasks(List<Appointment> appointments)
        {
            appointments.ForEach(appointment =>
            {
                _context.Appointment.Remove(appointment);
            });
            await SaveChangesAsync();
        }
    }
}

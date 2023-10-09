using MedicineProject.AppointmentService.Domain.Models;

namespace MedicineProject.AppointmentService.Domain.Repositories
{
    public interface IAppointmentRepository : IBaseRepository
    {
        void DeleteTasks(List<Appointment> appointments);
    }
}

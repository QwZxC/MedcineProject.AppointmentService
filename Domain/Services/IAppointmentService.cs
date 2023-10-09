using MedicineProject.AppointmentService.Domain.Dtos;
using MedicineProject.AppointmentService.Domain.Models.Base;

namespace MedicineProject.AppointmentService.Domain.Services
{
    public interface IAppointmentService
    {
        /// <summary>
        /// Создаёт заявку.
        /// </summary>
        /// <param name="appointment"></param>
        /// <returns></returns>
        Task<AppointmentDto> CreateAsync(AppointmentDto appointment);
        
        Task<TModel> TryGetItemByIdAsync<TModel>(long id) where TModel : BaseModel;

        Task UpdateTasksAsync();
    }
}

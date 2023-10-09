using AutoMapper;
using MedicineProject.AppointmentService.Domain.Dtos;
using MedicineProject.AppointmentService.Domain.Models;
using MedicineProject.AppointmentService.Domain.Models.Base;
using MedicineProject.AppointmentService.Domain.Repositories;
using MedicineProject.AppointmentService.Domain.Services;

namespace MedicineProject.AppointmentService.Core.Services
{
    /// <summary>
    /// Сервис для работы с заявками.
    /// </summary>
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _repository;
        private readonly IMapper _mapper;

        public AppointmentService(IAppointmentRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<AppointmentDto> CreateAsync(AppointmentDto appointment)
        {
            Appointment appointmentToDb = _mapper.Map<Appointment>(appointment);

            await _repository.CreateItemAsync(appointmentToDb);

            appointment.Id = appointmentToDb.Id;

            return appointment;
        }

        public async Task<TModel> TryGetItemByIdAsync<TModel>(long id)
            where TModel : BaseModel
        {
            return await _repository.TryGetItemByIdAsync<TModel>(id);
        }

        public async Task UpdateTasksAsync()
        {
            List<Appointment> appointments = await _repository.GetItemListAsync<Appointment>();
            DeleteTasks(appointments);
        }

        private void DeleteTasks(List<Appointment> appointments)
        {
            List<Appointment> appointmentsToRemove = new List<Appointment>();

            appointments.ForEach(appointment =>
            {
                if (appointment.Date < DateTime.Now)
                {
                    appointmentsToRemove.Add(appointment);
                }
            });

            _repository.DeleteTasks(appointmentsToRemove);

            appointmentsToRemove.ForEach(appointment => appointments.Remove(appointment));
        }
    }
}

using AutoMapper;
using Hangfire;
using MedicineProject.AppointmentService.Domain.Context;
using MedicineProject.AppointmentService.Domain.Dtos;
using MedicineProject.AppointmentService.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace MedicineProject.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService appointmentService;
        public AppointmentsController(IAppointmentService appointmentService)
        {
            this.appointmentService = appointmentService;
        }

        [HttpPost("appointment")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> SendAppointment([FromBody] AppointmentDto appointment)
        {
            var type = await appointmentService.TryGetItemByIdAsync<AppointmentService.Domain.Models.Type>(appointment.TypeId);

            return Ok(appointment);
        }

        [HttpPost]
        [Route("new-appointment")]
        public async Task<ActionResult> FireAndForget()
        {
            RecurringJob.AddOrUpdate(() => appointmentService.UpdateTasksAsync(), Cron.Weekly);
            return Ok();   
        }
    }
}

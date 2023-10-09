using MedicineProject.AppointmentService.Domain.Dtos.Base;
using System.Text.Json.Serialization;

namespace MedicineProject.AppointmentService.Domain.Dtos
{
    public record AppointmentDto : BaseDto
    {
        [JsonPropertyName("time")]
        public DateTime Time { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("type_id")]
        public long TypeId { get; set; }

        [JsonPropertyName("patient_id")]
        public long PatientId { get; set; }

        [JsonPropertyName("doctor_id")]
        public long DoctorId { get; set; }

        [JsonPropertyName("is_open")]
        public bool IsOpen { get; set; }

        public AppointmentDto() { }
    }
}

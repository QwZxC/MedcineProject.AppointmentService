using System.Text.Json.Serialization;

namespace MedicineProject.AppointmentService.Domain.Dtos.Base
{
    public record BaseDto
    {
        [JsonPropertyName("name")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}

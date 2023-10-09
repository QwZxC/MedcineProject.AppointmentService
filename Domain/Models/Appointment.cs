using MedicineProject.AppointmentService.Domain.Models.Base;

namespace MedicineProject.AppointmentService.Domain.Models
{
    public class Appointment : BaseModel
    {
        public Appointment() { }

        public DateTime Time { get; set; }

        public DateTime Date { get; set; }
        
        public Type Type { get; set; }

        public long TypeId { get; set; }

        public long PatientId { get; set; }

        public long DoctorId { get; set; }

        public bool IsOpen { get; set; }
    }
}

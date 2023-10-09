using AutoMapper;
using MedicineProject.AppointmentService.Domain.Models;
using MedicineProject.AppointmentService.Domain.Dtos;

namespace MedicineProject.AppointmentService.Domain.Mapping
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile() 
        {
            CreateMap<Models.Type, TypeDto>().ReverseMap();
            CreateMap<Appointment, AppointmentDto>().ReverseMap();
        }
    }
}

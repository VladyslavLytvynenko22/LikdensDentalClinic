using AutoMapper;
using LikdensDentalClinic.Domain.Dto;
using LikdensDentalClinic.Domain.Models;

namespace LikdensDentalClinic.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Patient, PatientDto>();
            CreateMap<PatientDto, Patient>();

            CreateMap<Staff, StaffDto>();
            CreateMap<StaffDto, Staff>();

            CreateMap<Service, ServiceDto>();
            CreateMap<ServiceDto, Service>();
        }
    }
}
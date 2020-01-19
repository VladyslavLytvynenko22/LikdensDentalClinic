using AutoMapper;
using LikdensDentalClinic.Data;
using LikdensDentalClinic.Domain.Dto;
using LikdensDentalClinic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LikdensDentalClinic.Core.Services
{
    public class ServiceService
    {
        private readonly LikdensDentalClinicDbContext _dbContext;
        private readonly IMapper _mapper;

        public ServiceService(LikdensDentalClinicDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }

        public List<ServiceDto> GetServices()
        {
            return _mapper.Map<List<ServiceDto>>(_dbContext.Services.ToList());
        }

        public async Task<ServiceDto> GetServiceById(int id)
        {
            return _mapper.Map<ServiceDto>(await _dbContext.Services.FindAsync(id));
        }

        public async Task<ServiceDto> CreateService(ServiceDto ServiceDto)
        {
            Service service = _dbContext.Services.Add(_mapper.Map<Service>(ServiceDto))?.Entity;
            ServiceDto = _mapper.Map<ServiceDto>(service);

            await _dbContext.SaveChangesAsync();

            return ServiceDto;
        }

        public async Task<ServiceDto> UpdateService(int id, ServiceDto ServiceDto)
        {
            if (_dbContext.Services.FirstOrDefault(c => c.Id == id) == null)
            {
                throw new Exception($"Unable to update. Service id: {id} not found.");
            }
            Service newService = _mapper.Map<Service>(ServiceDto);

            newService = _dbContext.Services.Update(newService)?.Entity;

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<ServiceDto>(newService);
        }

        public async Task DeleteService(int id)
        {
            Service service = await _dbContext.Services.FindAsync(id);
            if (service == null)
            {
                throw new Exception("Unable to delete. Service not found.");
            }

            _dbContext.Services.Remove(service);

            await _dbContext.SaveChangesAsync();
        }
    }
}
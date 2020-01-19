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
    public class PatientService
    {
        private readonly LikdensDentalClinicDbContext _dbContext;
        private readonly IMapper _mapper;

        public PatientService(LikdensDentalClinicDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }

        public List<PatientDto> GetPatients()
        {
            return _mapper.Map<List<PatientDto>>(_dbContext.Patients.ToList());
        }

        public async Task<PatientDto> GetPatientById(int id)
        {
            return _mapper.Map<PatientDto>(await _dbContext.Patients.FindAsync(id));
        }

        public async Task<PatientDto> CreatePatient(PatientDto patientDto)
        {
            Patient patient = _dbContext.Patients.Add(_mapper.Map<Patient>(patientDto))?.Entity;
            patientDto = _mapper.Map<PatientDto>(patient);

            await _dbContext.SaveChangesAsync();

            return patientDto;
        }

        public async Task<PatientDto> UpdatePatient(int id, PatientDto patientDto)
        {
            if (_dbContext.Patients.FirstOrDefault(c => c.Id == id) == null)
            {
                throw new Exception($"Unable to update. Patient id: {id} not found.");
            }
            Patient newPatient = _mapper.Map<Patient>(patientDto);

            newPatient = _dbContext.Patients.Update(newPatient)?.Entity;

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<PatientDto>(newPatient);
        }

        public async Task DeletePatient(int id)
        {
            Patient patient = await _dbContext.Patients.FindAsync(id);
            if (patient == null)
            {
                throw new Exception("Unable to delete. Patient not found.");
            }

            _dbContext.Patients.Remove(patient);

            await _dbContext.SaveChangesAsync();
        }
    }
}
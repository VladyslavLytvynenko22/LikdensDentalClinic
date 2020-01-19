using AutoMapper;
using LikdensDentalClinic.Data;
using LikdensDentalClinic.Domain.Dto;
using LikdensDentalClinic.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LikdensDentalClinic.Core.Staffs
{
    public class StaffStaff
    {
        private readonly LikdensDentalClinicDbContext _dbContext;
        private readonly IMapper _mapper;

        public StaffStaff(LikdensDentalClinicDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }

        public List<StaffDto> GetStaffs()
        {
            return _mapper.Map<List<StaffDto>>(_dbContext.Staff.ToList());
        }

        public async Task<StaffDto> GetStaffById(int id)
        {
            return _mapper.Map<StaffDto>(await _dbContext.Staff.FindAsync(id));
        }

        public async Task<StaffDto> CreateStaff(StaffDto StaffDto)
        {
            Staff staff = _dbContext.Staff.Add(_mapper.Map<Staff>(StaffDto))?.Entity;
            StaffDto = _mapper.Map<StaffDto>(staff);

            await _dbContext.SaveChangesAsync();

            return StaffDto;
        }

        public async Task<StaffDto> UpdateStaff(int id, StaffDto StaffDto)
        {
            if (_dbContext.Staff.FirstOrDefault(c => c.Id == id) == null)
            {
                throw new Exception($"Unable to update. Staff id: {id} not found.");
            }
            Staff newStaff = _mapper.Map<Staff>(StaffDto);

            newStaff = _dbContext.Staff.Update(newStaff)?.Entity;

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<StaffDto>(newStaff);
        }

        public async Task DeleteStaff(int id)
        {
            Staff staff = await _dbContext.Staff.FindAsync(id);
            if (staff == null)
            {
                throw new Exception("Unable to delete. Staff not found.");
            }

            _dbContext.Staff.Remove(staff);

            await _dbContext.SaveChangesAsync();
        }
    }
}
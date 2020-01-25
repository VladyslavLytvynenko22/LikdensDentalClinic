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
    public class PriceService
    {
        private readonly LikdensDentalClinicDbContext _dbContext;
        private readonly IMapper _mapper;

        public PriceService(LikdensDentalClinicDbContext dbContext, IMapper mapper)
        {
            this._dbContext = dbContext;
            this._mapper = mapper;
        }

        public List<PriceDto> GetPrices()
        {
            return _mapper.Map<List<PriceDto>>(_dbContext.Prices.ToList());
        }

        public async Task<PriceDto> GetPriceById(int id)
        {
            return _mapper.Map<PriceDto>(await _dbContext.Prices.FindAsync(id));
        }

        public async Task<PriceDto> CreatePrice(PriceDto priceDto)
        {
            Price service = _dbContext.Prices.Add(_mapper.Map<Price>(priceDto))?.Entity;
            priceDto = _mapper.Map<PriceDto>(service);

            await _dbContext.SaveChangesAsync();

            return priceDto;
        }

        public async Task<PriceDto> UpdatePrice(PriceDto priceDto)
        {
            if (_dbContext.Prices.FirstOrDefault(c => c.Id == priceDto.Id) == null)
            {
                throw new Exception($"Unable to update. Price id: {priceDto.Id} not found.");
            }
            Price newPrice = _mapper.Map<Price>(priceDto);

            newPrice = _dbContext.Prices.Update(newPrice)?.Entity;

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<PriceDto>(newPrice);
        }

        public async Task DeletePrice(int id)
        {
            Price service = await _dbContext.Prices.FindAsync(id);
            if (service == null)
            {
                throw new Exception("Unable to delete. Price not found.");
            }

            _dbContext.Prices.Remove(service);

            await _dbContext.SaveChangesAsync();
        }
    }
}
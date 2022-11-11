using APIBackend.Database;
using APIBackend.Dto;
using APIBackend.Models;
using APIBackend.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIBackend.Repositories
{
    public class EnterpriseRepository : EnterpriseInterface
    {
        private readonly DatabaseContext _context;
        private IMapper _mapper;
        public EnterpriseRepository(DatabaseContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EnterpriseDto> CreateUpdateEnterprise(EnterpriseDto enterpriseDto)
        {
            Enterprise enterprise = _mapper.Map<EnterpriseDto,Enterprise>(enterpriseDto);
            if (enterprise.Id > 0)
            {
                _context.Enterprises.Update(enterprise);
            }
            else
            {
                await _context.Enterprises.AddAsync(enterprise);               
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<Enterprise, EnterpriseDto>(enterprise);
        }

        public async Task<EnterpriseDto> GetEnterpriseById(int id)
        {
            Enterprise enterprise = await _context.Enterprises.FindAsync(id);
            return _mapper.Map<EnterpriseDto>(enterprise);
        }

        public async Task<List<EnterpriseDto>> GetEnterprises()
        {
            List<Enterprise> enterpriseList = await _context.Enterprises.ToListAsync();
            return _mapper.Map<List<EnterpriseDto>>(enterpriseList);
        }
    }
}

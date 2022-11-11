using APIBackend.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIBackend.Repositories
{
    public interface EnterpriseInterface
    {
        Task<List<EnterpriseDto>> GetEnterprises();
        Task<EnterpriseDto> GetEnterpriseById(int id);
        Task<EnterpriseDto> CreateUpdateEnterprise(EnterpriseDto enterpriseDto);

    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using AsaniCRUD.Facade.Contract.Estate.DTOs;
using Framework.Core;

namespace AsaniCRUD.Facade.Contract.Estate.Services
{
    public interface IEstateFacadeQuery : IFacadeService
    {
        Task<EstateDto> GetById(long id);
        Task<List<EstateDto>> GetAll(int page, int count);
    }
}
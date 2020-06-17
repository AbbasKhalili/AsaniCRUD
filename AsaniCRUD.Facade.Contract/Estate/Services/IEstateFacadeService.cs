using System.Threading.Tasks;
using AsaniCRUD.Facade.Contract.Estate.ViewModels;
using Framework.Core;

namespace AsaniCRUD.Facade.Contract.Estate.Services
{
    public interface IEstateFacadeService : IFacadeService
    {
        Task Create(EstateViewModel model);
        Task Update(EstateViewModel model);
        Task Delete(long id);
    }
}

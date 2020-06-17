using System.Threading.Tasks;
using AsaniCRUD.Application.Commands.Estate;
using AsaniCRUD.Facade.Contract.Estate.Services;
using AsaniCRUD.Facade.Contract.Estate.ViewModels;
using Framework.Application;

namespace AsaniCRUD.Facade.Services
{
    public class EstateFacadeService : IEstateFacadeService
    {
        private readonly ICommandBus _bus;

        public EstateFacadeService(ICommandBus bus)
        {
            _bus = bus;
        }

        public async Task Create(EstateViewModel model)
        {
            await _bus.Dispatch(new CreateEstateCommand
            {
                Address = model.Address,
                Area = model.Area,
                Direction = model.Direction,
                Name = model.Name,
                OwnerId = model.OwnerId
            });
        }

        public async Task Update(EstateViewModel model)
        {
            await _bus.Dispatch(new ModifyEstateCommand
            {
                Id = model.Id,
                Address = model.Address,
                Area = model.Area,
                Direction = model.Direction,
                Name = model.Name,
                OwnerId = model.OwnerId
            });
        }

        public async Task Delete(long id)
        {
            await _bus.Dispatch(new DeleteEstateCommand
            {
                Id = id
            });
        }
    }
}

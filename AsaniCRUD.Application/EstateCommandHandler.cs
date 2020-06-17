using System.Threading.Tasks;
using AsaniCRUD.Application.Commands.Estate;
using AsaniCRUD.Domain;
using Framework.Application;

namespace AsaniCRUD.Application
{
    public class EstateCommandHandler : 
        ICommandHandler<CreateEstateCommand>,
        ICommandHandler<ModifyEstateCommand>,
        ICommandHandler<DeleteEstateCommand>
    {
        private readonly IEstateRepository _repository;

        public EstateCommandHandler(IEstateRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateEstateCommand command)
        {
            var id = await _repository.GetNextId();
            var estate = new Estate(id, command.Name,command.Area,command.Address,(DirectionKinds)command.Direction,command.OwnerId);

            await _repository.Create(estate);
        }

        public async Task Handle(ModifyEstateCommand command)
        {
            var estate = await _repository.GetBy(command.Id);
            estate?.Update(command.Name,command.Area,command.Address,(DirectionKinds)command.Direction,command.OwnerId);
        }

        public async Task Handle(DeleteEstateCommand command)
        {
            var estate = await _repository.GetBy(command.Id);
            if (estate == null) return;

            await _repository.Delete(estate);
        }
    }
}

using System.Threading.Tasks;
using AsaniCRUD.Facade.Contract.Estate.Services;
using AsaniCRUD.Facade.Contract.Estate.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AsaniCRUD.Controllers
{
    [ApiController]
    [Route("api/Estate")]
    public class EstateController : ControllerBase
    {
        private readonly IEstateFacadeService _service;

        public EstateController(IEstateFacadeService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task Post(EstateViewModel model)
        {
            await _service.Create(model);
        }

        [HttpPut]
        public async Task Put(EstateViewModel model)
        {
            await _service.Update(model);
        }

        [HttpDelete("{id}")]
        public async Task Delete(long id)
        {
            await _service.Delete(id);
        }
    }
}
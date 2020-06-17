using System.Collections.Generic;
using System.Threading.Tasks;
using AsaniCRUD.Facade.Contract.Estate.DTOs;
using AsaniCRUD.Facade.Contract.Estate.Services;
using Microsoft.AspNetCore.Mvc;

namespace AsaniCRUD.Controllers
{
    [ApiController]
    [Route("api/Estate")]
    public class EstateQueryController : ControllerBase
    {
        private readonly IEstateFacadeQuery _query;

        public EstateQueryController(IEstateFacadeQuery query)
        {
            _query = query;
        }

        [HttpGet("{page}/{count}")]
        public async Task<List<EstateDto>> Get(int page, int count)
        {
            if (count > 10) count = 10;
            return await _query.GetAll(page, count);
        }

        [HttpGet("{id}")]
        public async Task<EstateDto> Get(long id)
        {
            return await _query.GetById(id);
        }
    }
}

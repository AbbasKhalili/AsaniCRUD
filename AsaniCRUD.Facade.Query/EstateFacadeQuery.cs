using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsaniCRUD.Facade.Contract.Estate.DTOs;
using AsaniCRUD.Facade.Contract.Estate.Services;
using AsaniCRUD.Facade.Query.Mapping;
using AsaniCRUD.ReadModel;
using Microsoft.EntityFrameworkCore;

namespace AsaniCRUD.Facade.Query
{
    public class EstateFacadeQuery : IEstateFacadeQuery
    {
        private readonly AsaniContext _context;

        public EstateFacadeQuery(AsaniContext context)
        {
            _context = context;
        }

        public async Task<EstateDto> GetById(long id)
        {
            var estate = await _context.Estates.Include(a=>a.Owner).FirstOrDefaultAsync(a => a.Id == id);
            return EstateMapper.Map(estate);
        }

        public async Task<List<EstateDto>> GetAll(int page, int count)
        {
            var list = await _context.Estates.Include(a => a.Owner).Skip((page - 1) * count).Take(count).ToListAsync();
            return EstateMapper.Map(list);
        }
    }
}

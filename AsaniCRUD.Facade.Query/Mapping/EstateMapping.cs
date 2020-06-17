using System.Collections.Generic;
using System.Linq;
using AsaniCRUD.Facade.Contract.Estate.DTOs;
using AsaniCRUD.ReadModel.Models;

namespace AsaniCRUD.Facade.Query.Mapping
{
    public static class EstateMapper
    {
        public static EstateDto Map(Estate model)
        {
            if (model == null) return null;
            return new EstateDto
            {
                Id = model.Id,
                Name = model.Name,
                Area = model.Area,
                Address = model.Address,
                Direction = model.Direction,
                Owner = OwnerMapper.Map(model.Owner)
            };
        }

        public static List<EstateDto> Map(List<Estate> list)
        {
            return list.Select(Map).ToList();
        }
    }
}

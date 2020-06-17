using System.Collections.Generic;
using System.Linq;
using AsaniCRUD.Facade.Contract.Owner.DTOs;
using AsaniCRUD.ReadModel.Models;

namespace AsaniCRUD.Facade.Query.Mapping
{
    public static class OwnerMapper
    {
        public static OwnerDto Map(Owner model)
        {
            if (model == null) return null;
            return new OwnerDto
            {
                Id = model.Id,
                Name = model.Name,
                Phone = model.Phone,
                Family = model.Family
            };
        }

        public static List<OwnerDto> Map(List<Owner> list)
        {
            return list.Select(Map).ToList();
        }
    }
}
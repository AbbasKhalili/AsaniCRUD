using AsaniCRUD.Facade.Contract.Owner.DTOs;

namespace AsaniCRUD.Facade.Contract.Estate.DTOs
{
    public class EstateDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Area { get; set; }
        public string Address { get; set; }
        public int Direction { get; set; }
        public OwnerDto Owner { get; set; }
    }
}

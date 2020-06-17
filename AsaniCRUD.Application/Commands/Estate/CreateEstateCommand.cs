namespace AsaniCRUD.Application.Commands.Estate
{
    public class CreateEstateCommand
    {
        public string Name { get; set; }
        public double Area { get; set; }
        public string Address { get; set; }
        public int Direction { get; set; }
        public long OwnerId { get; set; }
    }
}

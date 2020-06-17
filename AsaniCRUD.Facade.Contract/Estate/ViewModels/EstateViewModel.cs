namespace AsaniCRUD.Facade.Contract.Estate.ViewModels
{
    public class EstateViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Area { get; set; }
        public string Address { get; set; }
        public int Direction { get; set; }
        public long OwnerId { get; set; }
    }
}

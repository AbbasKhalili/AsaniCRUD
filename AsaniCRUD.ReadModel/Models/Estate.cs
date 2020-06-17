namespace AsaniCRUD.ReadModel.Models
{
    public class Estate
    {
        public long Id { get; set; }
        public string Name { get;  set; }
        public double Area { get;  set; }
        public string Address { get;  set; }
        public int Direction { get;  set; }
        public long OwnerId { get;  set; }
        public Owner Owner { get; set; }
    }
}

using Framework.Domain;

namespace AsaniCRUD.Domain
{
    public class Estate : Entity<long>
    {
        public string Name { get; private set; }
        public double Area { get; private set; }
        public string Address { get; private set; }
        public DirectionKinds Direction { get; private set; }
        public long OwnerId { get; private set; }

        protected Estate() { }

        public Estate(long id, string name, double area, string address, DirectionKinds direction, long ownerId)
        {
            Id = id;
            SetProperties(name, area, address, direction, ownerId);
        }

        public void Update(string name, double area, string address, DirectionKinds direction, long ownerId)
        {
            SetProperties(name,area,address,direction,ownerId);
        }

        private void SetProperties(string name, double area, string address, DirectionKinds direction, long ownerId)
        {
            Name = name;
            Area = area;
            Address = address;
            Direction = direction;
            OwnerId = ownerId;
        }
    }
}

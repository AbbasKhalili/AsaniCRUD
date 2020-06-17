using Framework.Domain;

namespace AsaniCRUD.Domain
{
    public class Owner : Entity<long>
    {
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string Phone { get; private set; }

        protected Owner() { }
        public Owner(long id, string name, string family, string phone)
        {
            Id = id;
            SetProperties(name, family, phone);
        }

        public void Update(string name, string family, string phone)
        {
            SetProperties(name,family,phone);
        }

        private void SetProperties(string name, string family, string phone)
        {
            Name = name;
            Family = family;
            Phone = phone;
        }
    }
}
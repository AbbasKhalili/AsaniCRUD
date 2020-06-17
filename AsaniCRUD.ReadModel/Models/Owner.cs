using System.Collections.Generic;

namespace AsaniCRUD.ReadModel.Models
{
    public class Owner
    {
        public long Id { get; set; }
        public string Name { get;  set; }
        public string Family { get;  set; }
        public string Phone { get;  set; }
        public List<Estate> Estates { get; set; }
    }
}
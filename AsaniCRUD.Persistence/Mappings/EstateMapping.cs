using AsaniCRUD.Domain;
using NHibernate.Mapping.ByCode.Conformist;

namespace AsaniCRUD.Persistence.Mappings
{
    public class EstateMapping : ClassMapping<Estate>
    {
        public EstateMapping()
        {
            Table("Estates");
            Lazy(false);

            Id(a => a.Id);

            Property(x => x.Name, map => { map.Column("Name"); map.NotNullable(true); });
            Property(x => x.Address, map => { map.Column("Address"); map.NotNullable(true); });
            Property(x => x.Area, map => { map.Column("Area"); map.NotNullable(true); });
            Property(x => x.Direction, map => { map.Column("Direction"); map.NotNullable(true); });
            Property(x => x.OwnerId, map => { map.Column("OwnerId"); map.NotNullable(true); });
        }
    }
}

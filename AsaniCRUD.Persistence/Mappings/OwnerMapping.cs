using AsaniCRUD.Domain;
using NHibernate.Mapping.ByCode.Conformist;

namespace AsaniCRUD.Persistence.Mappings
{
    public class OwnerMapping : ClassMapping<Owner>
    {
        public OwnerMapping()
        {
            Table("Owners");
            Lazy(false);

            Id(a => a.Id);

            Property(x => x.Name, map => { map.Column("Name"); map.NotNullable(true); });
            Property(x => x.Family, map => { map.Column("Family"); map.NotNullable(true); });
            Property(x => x.Phone, map => { map.Column("Phone"); map.NotNullable(true); });
        }
    }
}
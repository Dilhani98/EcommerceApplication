namespace Ecommerce.Api.Customers.Profile
{
    public class Customerprofile : AutoMapper.Profile
    {
        public Customerprofile()
        {
            CreateMap<Db.DbCustomer, Models.Customer>();
        }
    }
}

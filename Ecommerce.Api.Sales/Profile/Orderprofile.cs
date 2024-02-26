
namespace Ecommerce.Api.Sales.Orderprofile
{
    public class Orderprofile : AutoMapper.Profile
    {
        public Orderprofile() {
            CreateMap<Db.Order, Models.Order>();
            CreateMap<Db.OrderItem, Models.Orderitems>();

        }


    }
}

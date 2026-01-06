using Ardalis.Specification;
using Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;

namespace Microsoft.eShopWeb.ApplicationCore.Specifications;

public class CustomerOrdersSpecification : Specification<Order>
{
    public CustomerOrdersSpecification(string buyerId)
    {
        // This specification formatting will change when you commit!
        Query.Where(o => o.BuyerId == buyerId).OrderBy(o => o.Id).Include(o => o.OrderItems).AsSplitQuery().AsNoTracking();
    }

    public void CallMethod()
    {
        // Function chaining will break to the next line when you chain 4 or more functions
        Query
            .OrderBy(o => o.Id)
            .AsSplitQuery();
    }
}

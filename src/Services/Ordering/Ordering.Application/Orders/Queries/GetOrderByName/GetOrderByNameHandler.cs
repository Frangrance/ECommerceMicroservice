using BuildingBlocks.CQRS;
using Microsoft.EntityFrameworkCore;
using Ordering.Application.Data;
using Ordering.Application.Extensions;
using Ordering.Application.Orders.Queries.GetOrdersByName;

namespace Ordering.Application.Orders.Queries.GetOrderByName;

public class GetOrderByNameHandler(IApplicationDbContext dbContext) : IQueryHandler<GetOrderByNameQuery, GetOrderByNameResult>
{
    public async Task<GetOrderByNameResult> Handle(GetOrderByNameQuery query, CancellationToken cancellationToken)
    {
        var orders = await dbContext.Orders
            .Include(o => o.OrderItems)
            .Where(o => o.OrderName.Value.Contains(query.Name))
            .OrderBy(o => o.OrderName.Value)
            .ToListAsync(cancellationToken);

        return new GetOrderByNameResult(orders.ToOrderDtoList());
    }

    
}

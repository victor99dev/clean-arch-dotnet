using Domain.Entities;
using MediatR;

namespace Application.Products.Queries
{
    public class GetProductQuery : IRequest<IEnumerable<Product>>
    {
    }
}

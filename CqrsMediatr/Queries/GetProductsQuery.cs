using MediatR;

namespace CqrsMediatr.Queries
{
    public record GetProductsQuery :  IRequest<IEnumerable<Product>>;
}

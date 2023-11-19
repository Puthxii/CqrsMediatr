using MediatR;

namespace CqrsMediatr.Queries
{
    public record GetProductByIdQuery(int Id) : IRequest<Product>;
}

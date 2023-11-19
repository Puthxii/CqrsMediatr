using MediatR;

namespace CqrsMediatr.Commands
{
    public record AddProductCommand(Product Product) : IRequest<Unit>;
}

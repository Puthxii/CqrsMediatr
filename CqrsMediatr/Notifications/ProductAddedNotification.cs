using MediatR;

namespace CqrsMediatr.Notifications;

public record ProductAddedNotification(Product Product) : INotification;

using Store.Domain.Commands.Iterfaces;

namespace Store.Domain.Handlers.Interfaces;

public interface IHandler<T> : ICommand
{
  ICommandResult Handle(T command);
}
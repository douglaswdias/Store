using Flunt.Notifications;
using Flunt.Validations;
using Store.Domain.Commands.Iterfaces;
using Store.Domain.Entities;

namespace Store.Domain.Commands;

public class CreateOrderItemCommand : Notifiable, ICommand
{
  public CreateOrderItemCommand() { }
  public CreateOrderItemCommand(Guid product, int quantity)
  {
    Product = product;
    Quantity = quantity;
  }

  public Guid Product { get; set; }
  public int Quantity { get; set; }

  public void Validate()
  {
    AddNotifications(new Contract()
      .Requires()
      .HasLen(Product.ToString(), 32, "Product", "Produto invalido")
      .IsGreaterThan(Quantity, 0, "Quantity", "Quantidade invalida"));
  }
}

using Flunt.Validations;

namespace Store.Domain.Entities;

public class OrderItem : Entity
{
  public OrderItem(Product product, int quantity)
  {
    AddNotifications(new Contract()
      .Requires()
      .IsNotNull(product, "Product", "Produto invalido")
      .IsGreaterThan(quantity, 0, "Quantity", "A quantidade dever ser maior que 0")
    );
    Product = product;
    Price = Product != null ? Product.Price : 0;
    Quantity = quantity;
  }

  public Product Product { get; private set; }
  public decimal Price { get; private set; }
  public int Quantity { get; private set; }
  
  public decimal Total()
  {
    return Price * Quantity;
  }
}
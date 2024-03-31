using Store.Domain.Entities;
using Store.Domain.Repositories;

namespace Store.Tests.Repositories;

public class FakeProductRepository : IProductRepository
{
  public IEnumerable<Product> Get(IEnumerable<Guid> ids)
  {
    IList<Product> products =
    [
      new Product("Produto 01", 10, true),
      new Product("Produto 02", 10, true),
      new Product("Produto 03", 10, true),
      new Product("Produto 04", 10, true),
      new Product("Produto 05", 10, true)
    ];

    return products;
  }
}
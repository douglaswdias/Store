using Store.Domain.Commands;
using Store.Domain.Handlers;
using Store.Domain.Repositories;
using Store.Tests.Repositories;

namespace Store.Tests.Handlers;

[TestClass]
public class OrderHandlerTests
{
  private readonly ICustomerRepository _customerRepository;
  private readonly IDeliveryFeeRepository _deliveryFeeRepository;
  private readonly IDiscountRepository _discountRepository;
  private readonly IOrderRepository _orderRepository;
  private readonly IProductRepository _productRepository;

  public OrderHandlerTests()
  {
    _customerRepository = new FakeCustomerRepository();
    _deliveryFeeRepository = new FakeDeliveryFeeRepository();
    _discountRepository = new FakeDiscountRepository();
    _orderRepository = new FakeOrderRepository();
    _productRepository = new FakeProductRepository();
  }

  [TestMethod]
  [TestCategory("Handlers")]
  public void ReturnErrorOnInvalidClient()
  {

  }

  [TestMethod]
  [TestCategory("Handlers")]
  public void ReturnErrorOnInvalidZipCode()
  {

  }

  [TestMethod]
  [TestCategory("Handlers")]
  public void ReturnErrorOnInvalidPromoCode()
  {

  }

  [TestMethod]
  [TestCategory("Handlers")]
  public void ReturnErrorOnOrderWithNoItem()
  {

  }

  [TestMethod]
  [TestCategory("Handlers")]
  public void ReturnErrorOnInvalidCommand()
  {

  }

  [TestMethod]
  [TestCategory("Handlers")]
  public void ReturnSuccesOnValidCommand()
  {
    var command = new CreateOrderCommand();
    command.Customer = "12345678";
    command.ZipCode = "12345678";
    command.PromoCode = "12345678";
    command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
    command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));

    var handler = new OrderHandler(
      _customerRepository,
      _deliveryFeeRepository,
      _discountRepository,
      _productRepository,
      _orderRepository
    );

    handler.Handle(command);

    Assert.AreEqual(handler.Valid, true);
  }
}
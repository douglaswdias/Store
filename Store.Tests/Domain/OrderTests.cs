using System;
using Store.Domain.Entities;
using Store.Domain.Enums;

namespace Store.Tests.Domain;

[TestClass]
public class OrderTests
{
  private readonly Customer _customer = new Customer("Douglas Dias", "douglas.wdias@hotmail.com");
  private readonly Product _product = new Product("Produto 1", 10, true);
  private readonly Discount _discount = new Discount(10, DateTime.Now.AddDays(5));

  [TestMethod]
  [TestCategory("Domain")]
  public void ReturnNewOrderWith8CharactersOnValidOrder()
  {
    var customer = _customer;
    var order = new Order(customer, 0, _discount);
    Assert.AreEqual(8, order.Number.Length);
  }

  [TestMethod]
  [TestCategory("Domain")]
  public void ReturnWaitingPaymentStatusOnNewOrder()
  {
    var order = new Order(_customer, 0, _discount);
    Assert.AreEqual(order.Status, EOrderStatus.waitingPayment);
  }

  [TestMethod]
  [TestCategory("Domain")]
  public void ReturnWaitingDeliveryStatusOnPayedOrder()
  {
    var order = new Order(_customer, 0, null);
    order.AddItem(_product, 1);
    order.Pay(10);
    Assert.AreEqual(order.Status, EOrderStatus.waitingDelivery);
  }

  [TestMethod]
  [TestCategory("Domain")]
  public void ReturnCanceledStatusOnOrder()
  {
    var order = new Order(_customer, 0, null);
    order.Cancel();
    Assert.AreEqual(order.Status, EOrderStatus.canceled);
  }

  [TestMethod]
  [TestCategory("Domain")]
  public void ReturnErrorOnInvalidItem()
  {
    var order = new Order(_customer, 0, null);
    order.AddItem(null, 10);
    Assert.AreEqual(order.Items.Count, 0);
  }

  [TestMethod]
  [TestCategory("Domain")]
  public void ReturnErrorOnInvalidQuantity()
  {
    var order = new Order(_customer, 0, null);
    order.AddItem(_product, 0);
    Assert.AreEqual(order.Items.Count, 0);
  }

  [TestMethod]
  [TestCategory("Domain")]
  public void Return50OnValidOrder()
  {
    var order = new Order(_customer, 0, null);
    order.AddItem(_product, 5);
    Assert.AreEqual(order.Total(), 50);
  }

  [TestMethod]
  [TestCategory("Domain")]
  public void Return60OnExpiredDiscount()
  {
    var discount = new Discount(10, DateTime.Now.AddDays(-6));
    var order = new Order(_customer, 10, discount);
    order.AddItem(_product, 5);
    Assert.AreEqual(order.Total(), 60);
  }

  [TestMethod]
  [TestCategory("Domain")]
  public void Return60OnInvalidDiscount()
  {
    var order = new Order(_customer, 10, null);
    order.AddItem(_product, 5);
    Assert.AreEqual(order.Total(), 60);
  }

  [TestMethod]
  [TestCategory("Domain")]
  public void ReturnSucessOnValidDiscount()
  {
    var order = new Order(_customer, 0, _discount);
    order.AddItem(_product, 5);
    Assert.AreEqual(order.Total(), 40);
  }

  [TestMethod]
  [TestCategory("Domain")]
  public void Return60OnValidDeliveryFee()
  {
    var order = new Order(_customer, 20, _discount);
    order.AddItem(_product, 5);
    Assert.AreEqual(order.Total(), 60);
  }

  [TestMethod]
  [TestCategory("Domain")]
  public void ReturnErrorOnOrderWithNoClient()
  {
    var order = new Order(null, 20, _discount);
    order.AddItem(_product, 5);
    Assert.AreEqual(order.Valid, false);
  }
}
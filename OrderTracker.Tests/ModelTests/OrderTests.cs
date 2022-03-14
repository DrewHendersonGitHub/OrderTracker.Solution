using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderTracker.Models;
using System.Collections.Generic;
using System;

namespace OrderTracker.Tests
{
  [TestClass]
  public class OrderTests : IDisposable
  {
    public void Dispose()
    {
      Order.ClearAll();
    }

    [TestMethod]
    public void OrderConstructor_CreatesInstanceOfOrder_Order()
    {
      Order newOrder = new Order("test");
      Assert.AreEqual(typeof(Order), newOrder.GetType());
    }

    [TestMethod]
    public void SetTitle_SetTitle_String()
    {
      Order newOrder = new Order("20 burgers.");
      newOrder.Title = "test order";
      Assert.AreEqual("test order", newOrder.Title);
    }

    [TestMethod]
    public void GetDescription_ReturnsDescription_String()
    {
      Order newOrder = new Order("20 burgers");
      Assert.AreEqual("20 burgers", newOrder.Title);
    }

    [TestMethod]
    public void SetDescription_SetDescription_String()
    {
      Order newOrder = new Order("20 burgers.");
      newOrder.Description = "30 burgers and fries";
      Assert.AreEqual("30 burgers and fries", newOrder.Description);
    }

    [TestMethod]
    public void SetPrice_SetPrice_Double()
    {
      Order newOrder = new Order("20 burgers.");
      newOrder.Price = 77.50;
      Assert.AreEqual(77.50, newOrder.Price);
    }

    [TestMethod]
    public void SetDate_SetDate_String()
    {
      Order newOrder = new Order("20 burgers.");
      newOrder.Date = "1-1-2022";
      Assert.AreEqual("1-1-2022", newOrder.Date);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_OrderList()
    {
      List<Order> newList = new List<Order> { };
      CollectionAssert.AreEqual(newList, Order.GetAll());
    }

    [TestMethod]
    public void GetAll_ReturnsOrders_OrderList()
    {
      Order newOrder1 = new Order("20 burgers");
      Order newOrder2 = new Order("30 burgers and fries");
      List<Order> newList = new List<Order> { newOrder1, newOrder2 };
      CollectionAssert.AreEqual(newList, Order.GetAll());
    }
  }
}
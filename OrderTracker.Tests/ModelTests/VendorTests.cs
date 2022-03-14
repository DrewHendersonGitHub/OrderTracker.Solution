using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderTracker.Models;
using System.Collections.Generic;
using System;

namespace OrderTracker.Tests
{
  [TestClass]
  public class VendorTests : IDisposable
  {
    public void Dispose()
    {
      Vendor.ClearAll();
    }

    [TestMethod]
    public void VendorConstructor_CreatesInstanceOfVendor_Vendor()
    {
      Vendor newVendor = new Vendor("test vendor");
      Assert.AreEqual(typeof(Vendor), newVendor.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      Vendor newVendor = new Vendor("mcdonalds");
      Assert.AreEqual("mcdonalds", newVendor.Name);
    }

    [TestMethod]
    public void GetDescription_ReturnsDescription_String()
    {
      Vendor newVendor = new Vendor("mcdonalds");
      newVendor.Description = "Burger store";
      Assert.AreEqual("Burger store", newVendor.Description);
    }

    [TestMethod]
    public void GetId_ReturnsVendorId_Int()
    {
      Vendor newVendor = new Vendor("mcdonalds");
      Assert.AreEqual(1, newVendor.Id);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_VendorList()
    {
      List<Vendor> newList = new List<Vendor> { };
      CollectionAssert.AreEqual(newList, Vendor.GetAll());
    }

    [TestMethod]
    public void GetAll_ReturnsAllVendorObjects_VendorList()
    {
      Vendor newVendor1 = new Vendor("mcdonalds");
      Vendor newVendor2 = new Vendor("subway");
      List<Vendor> newList = new List<Vendor> { newVendor1, newVendor2 };
      CollectionAssert.AreEqual(newList, Vendor.GetAll());
    }

    [TestMethod]
    public void Find_ReturnsCorrectVendor_Vendor()
    {
      Vendor newVendor1 = new Vendor("mcdonalds");
      Vendor newVendor2 = new Vendor("subway");
      Assert.AreEqual(newVendor2, Vendor.Find(2));
    }

    [TestMethod]
    public void AddOrder_AssociatesOrderWithVendor_OrderList()
    {
      Order newOrder = new Order("7 burgers");
      List<Order> newList = new List<Order> { newOrder };
      Vendor newVendor = new Vendor("mcdonalds");
      newVendor.AddOrder(newOrder);
      CollectionAssert.AreEqual(newList, newVendor.Orders);
    }    
  }
}
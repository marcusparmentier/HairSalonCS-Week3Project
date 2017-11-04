using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Test
{
  [TestClass]
  public class StylistTests : IDisposable
  {
    public StylistTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=marcus_parmentier_test;";
    }

    public void Dispose()
    {
      Stylist.DeleteAll();
      Client.DeleteAll();
    }

    [TestMethod]
    public void GetAll_StylistsEmptyAtFirst_0()
    {
      //Arrange, Act
      int result = Stylist.GetAll().Count;

      //Assert
      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueForSameName_Stylist()
    {
      //Arrange, Act
      Stylist firstStylist = new Stylist("Sara", "Station 2");
      Stylist secondStylist = new Stylist("Sara", "Station 2", 0);
      Stylist failStylist = new Stylist("Wendy", "Station 5", 3);

      //Assert
      Assert.AreEqual(firstStylist, secondStylist);
    }

    [TestMethod]
    public void Save_SavesStylistToDatabase_StylistList()
    {
      //Arrange
      Stylist testStylist = new Stylist("Sara", "Station 2");
      Stylist failStylist = new Stylist("Wendy", "Station 5", 3);
      testStylist.Save();

      //Act
      List<Stylist> result = Stylist.GetAll();
      List<Stylist> testList = new List<Stylist>{testStylist};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Find_FindsStylistInDatabase_Stylist()
    {
      //Arrange
      Stylist testStylist = new Stylist("Sara", "Station 2");
      Stylist failStylist = new Stylist("Wendy", "Station 5", 3);
      testStylist.Save();

      //Act
      Stylist foundStylist = Stylist.Find(testStylist.GetId());

      //Assert
      Assert.AreEqual(testStylist, foundStylist);
    }

    [TestMethod]
    public void GetClients_RetrievesAllClientsWithStylist_ClientList()
    {
      Stylist testStylist = new Stylist("Sara", "Station 2");
      testStylist.Save();

      Client firstClient = new Client("Paul", "4 on top, 2 on the sides", testStylist.GetId());
      firstClient.Save();
      Client secondClient = new Client("Simon", "Light trim, keep sideburns", testStylist.GetId());
      secondClient.Save();
      Client failClient = new Client("Roger", "High and tight", testStylist.GetId());
      // failClient.Save();


      List<Client> testClientList = new List<Client> {firstClient, secondClient};
      List<Client> resultClientList = testStylist.GetClient();

      CollectionAssert.AreEqual(testClientList, resultClientList);
    }
  }
}

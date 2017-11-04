using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using HairSalon.Models;

namespace HairSalon.Tests
{

    [TestClass]
    public class ClientTests : IDisposable
    {
        public void Dispose()
        {
            Client.DeleteAll();
        }
        public ClientTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=marcus_parmentier_test;";
        }

        [TestMethod]
        public void GetAll_DatabaseEmptyAtFirst_0()
        {
          //Arrange, Act
          int result = Client.GetAll().Count;

          //Assert
          Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Equals_OverRideTrueForSameName_Client()
        {
          // Arrange, Act
          Client firstClient = new Client("Paul", "4 on top, 2 on the sides", 3);
          Client secondClient = new Client("Paul", "4 on top, 2 on the sides", 3);

          // Assert
          Assert.AreEqual(firstClient, secondClient);
        }

        [TestMethod]
        public void Save_SavesToDatabase_ClientList()
        {
          //Arrange
          Client testClient = new Client("Paul", "4 on top, 2 on the sides", 3);
          testClient.Save();

          //Act
          List<Client> result = Client.GetAll();
          List<Client> testList = new List<Client>{testClient};

          //Assert
          CollectionAssert.AreEqual(testList, result);
        }

        [TestMethod]
        public void Save_DatabaseAssignsIdToObject_Id()
        {
          //Arrange
          Client testClient = new Client("Paul", "4 on top, 2 on the sides", 3);
          testClient.Save();

          //Act
          Client savedClient = Client.GetAll()[0];

          int result = savedClient.GetId();
          int testId = testClient.GetId();

          //Assert
          Assert.AreEqual(testId, result);
        }

        [TestMethod]
        public void Find_FindsClientInDatabase_Client()
        {
          //Arrange
          Client testClient = new Client("Paul", "4 on top, 2 on the sides", 3);
          testClient.Save();
          // Client failClient = new Client("Fail", "2 on all");
          // failClient.Save();

          //Act
          Client foundClient = Client.Find(testClient.GetId());

          //Assert
          Assert.AreEqual(testClient, foundClient);
        }
    }
}

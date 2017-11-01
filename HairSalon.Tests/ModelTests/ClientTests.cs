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
          Client firstClient = new Client("Paul", "4 on top, 2 on the sides");
          Client secondClient = new Client("Paul", "4 on top, 2 on the sides");

          // Assert
          Assert.AreEqual(firstClient, secondClient);
        }

        [TestMethod]
        public void Save_SavesToDatabase_ClientList()
        {
          //Arrange
          Client testClient = new Client("Paul", "4 on top, 2 on the sides");
          testClient.Save();

          //Act
          List<Client> result = Client.GetAll();
          List<Client> testList = new List<Client>{testClient};

          //Assert
          CollectionAssert.AreEqual(testList, result);
        }
    }
}

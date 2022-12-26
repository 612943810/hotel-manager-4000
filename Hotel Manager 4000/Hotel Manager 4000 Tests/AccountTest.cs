using Hotel_Manager_4000.Controllers;
using Hotel_Manager_4000.Models;
using Hotel_Manager_4000.Service;
using Microsoft.AspNetCore.Components.Forms;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static  NUnit.Framework.Assert;
namespace Hotel_Manager_4000_Tests
{
    public class AccountTest
    {
        User users;
        private static Repository accountService;
        private static Mock<Repository> accountServiceMock;
        [SetUp]
        public void SetUp()
        {
          accountServiceMock= new Mock<Repository>();
        }
        [Test]
        public void findAll()
        {
        List<User> users = accountService.findAll();
            AreEqual(1, users.Count);
        }
        [Test]
       public void  GetUser(String id)
        {
            
        User GetUserById(String id);
        void InsertUser(User user)
            {
                User user = accountService.InsertUser(accountServiceMock.Object);
            }
        }
        void UpdateUser(User user);
        void DeleteUser(String id);
    }
}

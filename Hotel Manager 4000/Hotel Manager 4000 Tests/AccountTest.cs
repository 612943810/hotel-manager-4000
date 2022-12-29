using Hotel_Manager_4000.Controllers;
using Hotel_Manager_4000.Models;
using Hotel_Manager_4000.Repository;
using Hotel_Manager_4000.Service;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
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
        private User user;
        private static Mock<IRepository<User>>userMock;
        [SetUp]
        public void SetUp()
        {
            var userName= new User() {Email="test@test.com" ,FirstName="Apple",LastName="Pie",UserName="cooly"};
        }
        [Test]
        public void findAll()
        {
      //  List<IRepository<User>> users = 
            //AreEqual(1, users.Count);
        }
       // [Test]
        public void GetUser(String id)
        {
        }   
        void GetUserById(String id)
        {

        }
        void InsertUser(User user)
            {
               // User user = accountService.InsertUser(accountServiceMock.Object);
            }
        }
      //  void UpdateUser(User user);
       // void DeleteUser(String id);
  }


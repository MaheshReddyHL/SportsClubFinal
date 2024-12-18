using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Sports2.Models;
using System.Linq;


namespace SportsUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var context = new FinalcaseEntities())
            {
                var user = new User
                {
                    FullName ="Mahesh reddy",
                    Email = "mahesh2@gmail.com",
                    Password = "Mahesh@123",
                    MobileNumber="9980327764"
                };

                // Act
                context.Users.Add(user);
                context.SaveChanges();  // This commits the changes to the database

                // Assert - Check if the data was inserted
                var insertedAdmin = context.Users.SingleOrDefault(a => a.Email == "mahesh2@gmail.com");  
                Assert.IsNotNull(insertedAdmin);  // Check that the user was successfully inserted
                Assert.AreEqual("Mahesh reddy", insertedAdmin.FullName);
                Assert.AreEqual("mahesh2@gmail.com", insertedAdmin.Email);  
                Assert.AreEqual("Mahesh@123", insertedAdmin.Password);
                Assert.AreEqual("9980327764", insertedAdmin.MobileNumber);
            }
        }
    }
}

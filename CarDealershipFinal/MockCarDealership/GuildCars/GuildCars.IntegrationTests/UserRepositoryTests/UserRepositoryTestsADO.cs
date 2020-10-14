using GuildCars.Data.Repositories.ADO;
using GuildCars.Models.Tables;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;

namespace GuildCars.IntegrationTests.UserRepositoryTests
{
    [TestFixture]
    public class UserRepositoryTestsADO
    {


        //[OneTimeTearDown]
        //public void TearDown()
        //{
        //    var dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        //    try
        //    {
        //        using (dbConnection)
        //        {
        //            var cmd = new SqlCommand();
        //            cmd.CommandText = "GuildCarsDBReset";
        //            cmd.CommandType = System.Data.CommandType.StoredProcedure;

        //            cmd.Connection = dbConnection;
        //            dbConnection.Open();

        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string errorMessage = String.Format(CultureInfo.CurrentCulture,
        //                  "Exception Type: {0}, Message: {1}{2}",
        //                  ex.GetType(),
        //                  ex.Message,
        //                  ex.InnerException == null ? String.Empty :
        //                  String.Format(CultureInfo.CurrentCulture,
        //                               " InnerException Type: {0}, Message: {1}",
        //                               ex.InnerException.GetType(),
        //                               ex.InnerException.Message));

        //        System.Diagnostics.Debug.WriteLine(errorMessage);

        //        dbConnection.Close();
        //    }
        //}

        [Test]
        public void CanGetAllUsers()
        {
            UserRepositoryADO repo = new UserRepositoryADO();

            List<User> users = repo.GetUsers().ToList();

            Assert.AreEqual(5, users.Count);

            Assert.AreEqual("12f5d975-e90a-4260-be16-5c4476c5e506", users[0].Id);
            Assert.AreEqual("Admin", users[0].UserRole);
            

        }

        [Test]
        public void CanGetUserById()
        {
            UserRepositoryADO repo = new UserRepositoryADO();

            User user = repo.GetUserById("56a4b914-53ca-4fac-99df-0c9ec57e1088");

            Assert.AreEqual("56a4b914-53ca-4fac-99df-0c9ec57e1088", user.Id);
            Assert.AreEqual("Sales", user.UserRole);
            Assert.AreEqual("barb@test.test", user.Email);
            
        }

        [Test]
        public void CanAddUser()
        {
            User user = new User
            {
                Id = "Added-Test-User",
                UserName = "Added User",
                Email = "addeduser@test.com",
                AccessFailedCount = 0,
                TwoFactorEnabled = false,
                EmailConfirmed = false,
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                LockoutEndDateUtc = null,
                LockoutEnabled = false,
                PasswordHash = null,
                SecurityStamp = null,
                UserRole = "Admin"
            };

            UserRepositoryADO repo = new UserRepositoryADO();
            repo.Insert(user);

            List<User> users = repo.GetUsers().ToList();
            Assert.AreEqual(5, users.Count);

            Assert.AreEqual("9ed0222e-fb31-4d51-b18d-1992a9f91161", users[4].Id);
            Assert.AreEqual("coby.kelly.ck@gmail.com", users[4].UserName);
            

        }

        [Test]
        public void CanUpdateUser()
        {
            User user = new User
            {
                Id = "Added-Test-User",
                UserName = "Added User",
                Email = "addeduser@test.com",
                AccessFailedCount = 0,
                TwoFactorEnabled = false,
                EmailConfirmed = false,
                PhoneNumber = null,
                PhoneNumberConfirmed = false,
                LockoutEndDateUtc = null,
                LockoutEnabled = false,
                PasswordHash = null,
                SecurityStamp = null,
                UserRole = "Admin"
            };

            UserRepositoryADO repo = new UserRepositoryADO();
            repo.Insert(user);

            user.UserName = "Updated User";
            user.Email = "updateduser@test.com";
            user.TwoFactorEnabled = true;
            user.PhoneNumber = "804-555-5555";
            user.PhoneNumberConfirmed = true;
            user.UserRole = "Sales";
            user.PasswordHash = "APTyyq+Bp99LHIKp2XOeOiLot5b/Li+db4pQdafI6FN6xfBhCkfOKzl/s0SQ5CjOfg==";

            repo.Update(user);

            List<User> users = repo.GetUsers().ToList();
            Assert.AreEqual(5, users.Count);

            Assert.AreEqual("9ed0222e-fb31-4d51-b18d-1992a9f91161", users[4].Id);
  
        }
    }
}


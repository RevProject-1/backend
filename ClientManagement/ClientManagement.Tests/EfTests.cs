﻿using ClientManagement.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ClientManagement.Tests
{
  public class EfTests
  {
    [Fact]
    public void Test_InsertClient()
    {
      var data = new EfData();
      var expected = new Client() { Name = "Derek Geter", Address = new Address() {Street = "1234 main", City = "Reston", State = "VA", Zip = "20190" }, Email = "test@test.com", PhoneNumber = "1234567890" , UserId = "60d9002e-667f-4794-a9dd-670c0ecf56c9" };

      var actual = data.AddClient(expected);

      Assert.True(actual);
    }

    [Fact]
    public void Test_InsertAddress()
    {
      var data = new EfData();
      var expected = new Address() { Street = "123 main", City = "Reston", State = "VA", Zip = "20190" };
      var actual = data.AddAddress(expected);

      Assert.True(actual);
    }

    [Fact]
    public void Test_GetUserName()
    {
      var data = new EfData();
      var expected = data.GetUsers().ToList();
      Assert.NotEmpty(expected);
    }

    [Fact]
    public void Test_Register()
    {
      var data = new EfData();
      var expected = new AspNetUser
      {
        Id = "djkfhieur55-3i3kj-kkl",
        Email = "test6@test.com",
        EmailConfirmed = true,
        Name = "Fred",
        StreetAddress = "123 Here",
        City = "Reston",
        State = "VA",
        Zip = "20190",
        PhoneNumber = "1234567890",
        AccessFailedCount = 0,
        LockoutEnabled = false,
        PasswordHash = "ddddddddddddddddddddd",
        SecurityStamp = null,
        TwoFactorEnabled = false,
        PhoneNumberConfirmed = false,
        LockoutEndDateUtc = null,
        UserName = "test6@test.com"
      };
      var actual = data.AddUser(expected);

      Assert.True(actual);
    }

    [Fact]
    public void Test_AddType()
    {
      var data = new EfData();
      
      var expected = new ServiceType
      {
        Name = "Butcher",
        Rate = 8.00M,
        UserId = "60d9002e-667f-4794-a9dd-670c0ecf56c9"
      };
      var actual = data.AddType(expected);

      Assert.True(actual);
    }

    [Fact]
    public void Test_AddJob()
    {
      var data = new EfData();
      var client = data.GetClients().Where(c => c.Id == 4).FirstOrDefault();
      var user = data.GetUsers().Where(c => c.Id == "60d9002e-667f-4794-a9dd-670c0ecf56c9").FirstOrDefault();
      var st = data.GetTypes().Where(c => c.Id == 1).FirstOrDefault();

      var expected = new ScheduleJob
      {
        
        ServiceType = st,
        
        Client = client,
       
        UserID = user.Id,
        
      };
      var actual = data.AddJob(expected);
      Assert.True(actual);
    }

    [Fact]
    public void Test_UpdateJob()
    {
      var data = new EfData();
      
      var expected = data.GetJobs().Where(x => x.Id == data.GetJobs().Max(a => a.Id)).FirstOrDefault();
      expected.EstimatedDuration = 33;
      expected.Hours = 50;
      expected.Complete = true;
      var actual = data.UpdateJob(expected);
      
      Assert.True(actual);
    }

    [Fact]
    public void InsertExpense()
    {
      var data = new EfData();

      var expected = new Expense
      {
        Name = "Tape",
        Cost = 4.99M
      };
      var result = data.AddExpense(expected);
      Assert.True(result);
    }

    [Fact]
    public void TestInsertJobExpense()
    {
      var data = new EfData();

      var expe = data.GetExpenses().FirstOrDefault();

      var jb = data.GetJobs().FirstOrDefault();

      var result = data.AddJobExpense(jb, expe);
      Assert.True(result);
    }
  }
}

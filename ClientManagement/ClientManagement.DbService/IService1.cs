﻿using ClientManagement.DbService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ClientManagement.DbService
{
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
  [ServiceContract]
  public interface IService1
  {

    [OperationContract]
    bool Register(UserDAO user);

    [OperationContract]
    List<UserDAO> GetUserNames();

    [OperationContract]
    void Login(UserDAO user);
  }
}

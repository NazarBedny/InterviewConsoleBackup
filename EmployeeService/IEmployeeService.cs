﻿using EmployeeService.Models;
using System.ServiceModel;
using System.ServiceModel.Web;


namespace EmployeeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    //http://localhost:64014/EmployeeService.svc/GetEmployeeById?id={id}
    [ServiceContract]
    public interface IEmployeeService
    {
        [OperationContract]
        [WebGet(UriTemplate = "GetEmployeeById?id={id}", ResponseFormat = WebMessageFormat.Json)]
        Response<Employee> GetEmployeeById(int id);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "EnableEmployee?id={id}&enable={enable}", BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        void EnableEmployee(int id, int enable);
    }
}

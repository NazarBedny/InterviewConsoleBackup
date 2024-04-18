using EmployeeService.Managers;
using EmployeeService.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace EmployeeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    // 
    public class ServiceClient : IEmployeeService
    {
        private readonly IEmploeeManager _empoleeManager;

        public ServiceClient(IEmploeeManager empoleeManager)
        {
            _empoleeManager = empoleeManager;
        }

        public void EnableEmployee(int id, int enable)
        {
            _empoleeManager.EnableEmployee(id,enable);
        }

        public Response<Employee> GetEmployeeById(int id)
        {
            var response = new Response<Employee>();
            var empolee = _empoleeManager.GetEmployeeById(id);
            if (empolee != null) 
            {
                response.Success = true;
                response.Data = empolee;
                return response;
            }
            else 
            {
                response.Success = false;
                response.Data = null;
                return response;
            }
        }
    }




}

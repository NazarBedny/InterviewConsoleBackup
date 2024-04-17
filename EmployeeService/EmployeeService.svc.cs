using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Newtonsoft.Json;

namespace EmployeeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IEmployeeService
    {
        private const string ConnectionString = "Data Source=(local);Initial Catalog=Test;User ID=sa;Password=pass@word1; ";

        public bool GetEmployeeById(int id)
        {
            var query = "SELECT * FROM Employee WHERE ID = @Id";
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Create Employee object from reader
                            var employee = new Employee
                            {
                                ID = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                ManagerID = reader.IsDBNull(2) ? null : (int?)reader.GetInt32(2),
                                Enable = reader.GetBoolean(3)
                            };
                            // Serialize Employee object to JSON and return
                            var json = JsonConvert.SerializeObject(employee);
                            return json;
                        }
                    }
                }
            }
            return null; // Employee with given ID not found
        }

        public void EnableEmployee(int id, int enable)
        {
            var query = "UPDATE Employee SET Enable = @Enable WHERE ID = @Id";
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Enable", enable);
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }

    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int? ManagerID { get; set; }
        public bool Enable { get; set; }
    }


}
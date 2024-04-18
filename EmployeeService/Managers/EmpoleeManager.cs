using EmployeeService.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Managers
{
    //
    public class EmploeeManager : IEmploeeManager
    {
        private const string ConnectionString = "Server=DESKTOP-HHVNHEO; Database=EmploeeDB;Trusted_Connection=True;";
        public Employee GetEmployeeById(int id)
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
                            return employee;
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

    public interface IEmploeeManager
    {
         Employee GetEmployeeById(int id);

         void EnableEmployee(int id, int enable);
    }

}

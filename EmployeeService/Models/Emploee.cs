using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeService.Models
{
    [DataContract]
    public class Employee
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int? ManagerID { get; set; }
        [DataMember]
        public bool Enable { get; set; }
    }
}

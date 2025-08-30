using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.BLL.ModelVM
{
    public class DeleteEmployeeVM
    {   
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? DepartmentName { get; set; }
    }
}

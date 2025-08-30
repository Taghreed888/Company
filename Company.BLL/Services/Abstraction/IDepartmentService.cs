using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.BLL.Services.Abstraction
{
    public interface IDepartmentService
    {
        public (Boolean fail, string? ErrorMSG, List<Department> departments) GetAllDepartments();
    }
}

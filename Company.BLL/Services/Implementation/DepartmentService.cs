using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.BLL.Services.Implementation
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepo departmentRepo;

        public DepartmentService(IDepartmentRepo departmentRepo)
        {
            this.departmentRepo = departmentRepo;
        }

        public (Boolean fail, string? ErrorMSG, List<Department> departments) GetAllDepartments()
        {
            var temp = departmentRepo.GetAllDepartments();
            if (temp != null)
            {
                return (false, null, temp);
            }
            return (true, "There're not any departemt", null);
        }
    }
}

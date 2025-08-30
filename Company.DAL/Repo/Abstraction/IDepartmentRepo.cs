using Company.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DAL.Repo.Abstraction
{
    public interface IDepartmentRepo
    {
        public List<Department> GetAllDepartments();
    }
}

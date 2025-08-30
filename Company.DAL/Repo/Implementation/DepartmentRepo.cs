using Company.DAL.DataBase;
using Company.DAL.Entity;
using Company.DAL.Repo.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Company.DAL.Repo.Implementation
{
    public class DepartmentRepo :IDepartmentRepo
    {
        private readonly CompanyDbContext db;
        public DepartmentRepo(CompanyDbContext _db)
        {
            db = _db;
        }
        public List<Department> GetAllDepartments()
        {
            return db.Departments.ToList();
        }
    }
}

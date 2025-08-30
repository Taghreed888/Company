using Castle.Components.DictionaryAdapter.Xml;
using Company.DAL.DataBase;
using Company.DAL.Entity;
using Company.DAL.Repo.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Company.DAL.Repo.Implementation
{
    public class EmployeeRepo :IEmployeeRepo
    {
        private readonly CompanyDbContext db;
        public EmployeeRepo(CompanyDbContext _db)
        {
            db = _db;
        }

        public List<Employee> Find (Expression<Func<Employee,bool>> predicate)
        {
            return db.Employees.Where(predicate).ToList();


        }
        public Employee? GetById(int id)
        {
            return db.Employees.FirstOrDefault(s=>s.Id==id);
        }
        public bool  Create(Employee emp)
        {
            if(emp == null) throw new ArgumentNullException(nameof(emp));
                var res= db.Employees.Add(emp);
            db.SaveChanges();
            if (res.Entity.Id > 0)
                return true;
            return false;  
        }

        public bool Delete(Employee emp, string Deletedby="system")
        {  
            if(emp ==null) return false;
            db.Employees.Remove(emp);
            if (emp.togglestatus(Deletedby))
            {
                return db.SaveChanges() > 0;
            }
            return false;
        }

        public bool update(Employee emp,string updatedby="system")
        {
           
            var found =db.Employees.FirstOrDefault(s =>s.Id==emp.Id);
            if(found ==null) throw new ArgumentNullException(nameof(emp));
            if (found.Update(updatedby, emp.Name, emp.Age))
            {
                return db.SaveChanges() > 0;
            }
            return false;
        }
        public List<Employee>GetAllEmployee()
        {
            var found =db.Employees.Include(s=>s.Department).ToList();
            if (found == null) throw new ArgumentNullException();
            return found ;

        }
        
    }
}

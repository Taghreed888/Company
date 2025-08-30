
using Company.DAL.Entity;
using System.Linq.Expressions;

namespace Company.DAL.Repo.Abstraction
{
    public interface IEmployeeRepo
    {
        public bool update(Employee emp, string updatedby = "system");
        public bool Delete(Employee emp, string Deletedby = "system");

        public bool Create(Employee emp);
        public Employee? GetById(int id);

        public List<Employee> Find(Expression<Func<Employee, bool>> predicate);
        public List<Employee> GetAllEmployee();

       



    }
}

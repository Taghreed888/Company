using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.BLL.Services.Abstraction
{
    public interface IEmployeeService
    {
        public (Boolean success, string ErrorMessage) Create(CreateEmployeeVM emp);
        public (Boolean fail, string? ErrorMSG, List<IndexEmployeeVM> employees) GetAllEmployees();

        public (Boolean? success, string? ErrorMessage) Delete(int id);
        public DeleteEmployeeVM? GetByIdForDisplay(int id);
        public EditEmployeeVM? GetByIdForEdit(int id);
        public (Boolean success, string ErrorMessage) Update(EditEmployeeVM employeeVM);
    }
}

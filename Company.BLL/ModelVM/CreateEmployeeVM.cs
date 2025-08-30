using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.BLL.ModelVM
{
    public class CreateEmployeeVM
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is Required")]
        [StringLength(100,MinimumLength =3,ErrorMessage ="Name must be between 3 and 100")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Age is Required")]
        [Range(18,60,ErrorMessage ="Age must be 18 and 60")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Department is Required")]
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }

        public IFormFile ImageFile { get; set; }
        
    }
}

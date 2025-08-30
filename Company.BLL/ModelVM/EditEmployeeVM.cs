using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.BLL.ModelVM
{
    public class EditEmployeeVM
    {
        // In Company.BLL.ModelVM folder
      
            public int Id { get; set; }

            [Required]
            [MaxLength(50)]
            public string Name { get; set; }

            public int Age { get; set; }
            public decimal Salary { get; set; }

            [Display(Name = "Department")]
            public int DepartmentId { get; set; }

            // Used to show the current image
            public string? ExistingImageUrl { get; set; }

            // Used to accept a new image file
            [Display(Name = "New Profile Image")]
            public IFormFile? NewImageFile { get; set; }
        }
    }


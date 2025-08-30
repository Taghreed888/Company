using AutoMapper;
using Company.BLL.ModelVM;
using Company.BLL.Helper;



using Company.DAL.Entity;
using Company.DAL.Repo.Implementation;
using Microsoft.Identity.Client;

namespace Company.BLL.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepo _employeeRepo;
        private readonly IMapper _mapper;
        public EmployeeService(IEmployeeRepo employeeRepo, IMapper mapper)
        {
            _employeeRepo = employeeRepo;
            _mapper = mapper;
        }
        public (Boolean success, string ErrorMessage) Create(CreateEmployeeVM emp)
        {
            var imagePath = Upload.UploadFile("Files", emp.ImageFile);

            var mappedEmplyoee = _mapper.Map<Employee>(emp);
            mappedEmplyoee.ImageURL = imagePath;
            var createEmployee = _employeeRepo.Create(mappedEmplyoee);

            if (createEmployee)
            {
                return (true, null);
            }
            return (false, "Failed to create Employee");
        }
        public (Boolean fail, string? ErrorMSG, List<IndexEmployeeVM> employees) GetAllEmployees()
        {
            var temp = _employeeRepo.GetAllEmployee();
            if (temp != null)
            {
                var mappedUsers = _mapper.Map<List<IndexEmployeeVM>>(temp);
                return (false, null, mappedUsers);
            }
            return (true, "There're not any employee", null);
        }
        public (Boolean? success, string? ErrorMessage) Delete(int id)
        {
            var emptodelete = _employeeRepo.GetById(id);
            if (emptodelete == null)
            {
                return (false, "Employee not Found");

            }
            try
            {
                bool wasDeleted = _employeeRepo.Delete(emptodelete);

                return (wasDeleted ? (true, null) : (false, "Failed to delete the employee from the database."));
            }
            catch (Exception ex)
            {

                return (false, "An unexpected error occurred while deleting the employee.");
            }

        }



        public DeleteEmployeeVM? GetByIdForDisplay(int id)
        {
            var employee = _employeeRepo.GetById(id);
            return _mapper.Map<DeleteEmployeeVM>(employee);
        }

        public EditEmployeeVM? GetByIdForEdit(int id)
        {
            var employee = _employeeRepo.GetById(id);
            return _mapper.Map<EditEmployeeVM>(employee);
        }

        public (Boolean success, string ErrorMessage) Update(EditEmployeeVM employeeVM)
        {
            // === VALIDATION 1: Find the original employee record ===
            var existingEmployee = _employeeRepo.GetById(employeeVM.Id);
            if (existingEmployee == null)
            {
                return ( false,  "Employee not found." );
            }

            
            string newImageUrl = existingEmployee.ImageURL; // Keep old image by default
            if (employeeVM.NewImageFile != null)
            {
                // 1. Delete the old file if it exists
                if (!string.IsNullOrEmpty(existingEmployee.ImageURL))
                {
                    var oldFilePath = Path.Combine("wwwroot", "Files", existingEmployee.ImageURL);
                    if (File.Exists(oldFilePath))
                    {
                        File.Delete(oldFilePath);
                    }
                }

                // 2. Upload the new file
                newImageUrl = Upload.UploadFile("Files", employeeVM.NewImageFile);
            }

            // === Map and Save ===
            // Map the updated scalar properties from the VM to the entity
            _mapper.Map(employeeVM, existingEmployee);
            existingEmployee.ImageURL = newImageUrl; // Manually set the new image URL

            try
            {
                bool wasUpdated = _employeeRepo.update(existingEmployee);
                if (wasUpdated)
                {
                    return (true ,null);
                }
                return (  false,  "Database failed to update the record." );
            }
            catch (Exception ex)
            {
                // Log ex
                return  ( false, "An unexpected error occurred." );
            }
        }
    }
}
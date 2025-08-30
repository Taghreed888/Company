using Company.BLL.ModelVM;
using Company.BLL.Services.Abstraction;
using Company.BLL.Services.Implementation;
using Company.DAL.Repo.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
namespace Company.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;
        private readonly IDepartmentService departmentService;
     
        public EmployeeController(IEmployeeService _employeeService, IDepartmentService departmentService)
        {
            this.employeeService = _employeeService;
            this.departmentService = departmentService;
           
        }
        public IActionResult Index()
        {
            var EmployeeResult = employeeService.GetAllEmployees();
            if (EmployeeResult.fail)
            {
                TempData["ErrorMessage"] = EmployeeResult.ErrorMSG;
            }
            return View(EmployeeResult.employees);

        }

        public IActionResult Create()
        {
            var departmentsResult = departmentService.GetAllDepartments();
            if (!departmentsResult.fail && departmentsResult.departments != null)
            {

                ViewBag.Departments = new SelectList(departmentsResult.departments, "Id", "Name");
            }
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateEmployeeVM model)
        {
            if (ModelState.IsValid)
            {
                var result = employeeService.Create(model);

                if (result.success)
                {
                    TempData["SuccessMessage"] = "Employee created successfully!";
                    return RedirectToAction("Index", "Employee"); // go to list page
                }

                ModelState.AddModelError("", result.ErrorMessage ?? "An error occurred");
            }

            var departmentsResult = departmentService.GetAllDepartments();
            if (!departmentsResult.fail && departmentsResult.departments != null)
            {
                // Convert your List<Department> to a SelectList for the view
                ViewBag.Departments = new SelectList(departmentsResult.departments, "Id", "Name");
            }
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            var employee = employeeService.GetByIdForDisplay(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var result = employeeService.Delete(id);

            if (result.success == true)
            {
                TempData["SuccessMessage"] = "Employee was deleted successfully.";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                // Show the error message from the service
                TempData["ErrorMessage"] = result.ErrorMessage;
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult Edit(int id)
        {
            var employeeVM = employeeService.GetByIdForEdit(id);
            if (employeeVM == null)
            {
                return NotFound();
            }
            var departmentsResult = departmentService.GetAllDepartments();
            if (!departmentsResult.fail && departmentsResult.departments != null)
            {
                // Convert your List<Department> to a SelectList for the view
                ViewBag.Departments = new SelectList(departmentsResult.departments, "Id", "Name");
            }
            return View(employeeVM);
        }

    
    [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EditEmployeeVM employeeVM)
        {
            if (id != employeeVM.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var result = employeeService.Update(employeeVM);
                if (result.success)
                {
                    TempData["SuccessMessage"] = "Employee updated successfully!";
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.ErrorMessage ?? "An error occurred.");
            }

            // If we got this far, something failed, redisplay form
            var departmentsResult = departmentService.GetAllDepartments();
            if (!departmentsResult.fail && departmentsResult.departments != null)
            {
                // Convert your List<Department> to a SelectList for the view
                ViewBag.Departments = new SelectList(departmentsResult.departments, "Id", "Name");
            } ;
            return View(employeeVM);
        }
    }
    }


using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My_Employee_App.Data;
using My_Employee_App.Entities;
using My_Employee_App.Models;

namespace My_Employee_App.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly MyDbContext _dbContext;
        public EmployeesController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employees = await _dbContext.Employees.ToListAsync();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddEmployeeViewModel addEmployeeRequest)
        {
            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Name = addEmployeeRequest.Name,
                Department = addEmployeeRequest.Department,
                Email = addEmployeeRequest.Email,
                Salary = addEmployeeRequest.Salary,
                DateOfBirth = addEmployeeRequest.DateOfBirth
            };
            await _dbContext.Employees.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == id);
            
            
            return View(employee);
        }

        //[HttpGet]
        //public async Task<IActionResult> Edit(Guid id)
        //{
        //    var employee = await _dbContext.Employees.FindAsync(id);
        //    var editEmployeeViewModel = new EditEmployeeViewModel()
        //    {
        //        Id = employee.Id,
        //        Name = employee.Name,
        //        Department = employee.Department,
        //        Email = employee.Email,
        //        Salary = employee.Salary,
        //        DateOfBirth = employee.DateOfBirth
        //    };
        //    return View(editEmployeeViewModel);
        //}
        //[HttpPost]
        //public async Task<IActionResult> Edit(EditEmployeeViewModel editEmployeeRequest)
        //{
        //    var employee = await _dbContext.Employees.FindAsync(editEmployeeRequest.Id);
        //    employee.Name = editEmployeeRequest.Name;
        //    employee.Department = editEmployeeRequest.Department;
        //    employee.Email = editEmployeeRequest.Email;
        //    employee.Salary = editEmployeeRequest.Salary;
        //    employee.DateOfBirth = editEmployeeRequest.DateOfBirth;
        //    await _dbContext.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}
    }
}

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

        public async Task<IActionResult> Index()
        {
            var employees = await _dbContext.Employees.ToListAsync();
            return View(employees);
        }

        public MyDbContext DbContext { get; }

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
    }
}

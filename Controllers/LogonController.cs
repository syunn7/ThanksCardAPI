using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ThanksCardAPI.Models;

namespace ThanksCardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogonController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public LogonController(ApplicationContext context)
        {
            _context = context;

            if (_context.Employees.Count() == 0)
            {
                // Usersテーブルが空なら初期データを作成する。
                _context.Employees.Add(new Employee { EmployeeCd = "a0001",EmployeeName = "admin", Password = "admin"  });
                _context.Employees.Add(new Employee { EmployeeCd = "u0001", EmployeeName = "user", Password = "user" });
                _context.SaveChanges();
            }
        }

        // POST api/logon
        [HttpPost]
        public ActionResult<Employee> Post([FromBody] Employee employee)
        {
            var authorizedUser = _context.Employees.SingleOrDefault(x => x.EmployeeCd == employee.EmployeeCd && x.Password == employee.Password);
            if (authorizedUser == null)
            {
                return NotFound();
            }
            return authorizedUser;
        }
    }
}

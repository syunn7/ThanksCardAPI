using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThanksCardAPI.Models;

namespace ThanksCardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationUsersController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public OrganizationUsersController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/DepartmentUsers/5
        [HttpGet("{OrganizationId?}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetDepartmentUsers(long? OrganizationId = null)
        {
            if (OrganizationId == null)
            {
                return await _context.Employees
                                        .ToListAsync();
            }
            else
            {
                return await _context.Employees
                                        .Where(u => u.OrganizationId == OrganizationId)
                                        .ToListAsync();
            }
        }
    }
}
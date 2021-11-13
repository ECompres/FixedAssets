using Fixed_Assets.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixedAssetsAPI.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public EmployeeController(ApplicationDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAll()
        {
            return await context.Employee.ToListAsync();
        }

        [HttpGet("{id}", Name = "GetEmployee")]
        public async Task<ActionResult<Employee>> Get(int id)
        {
            var employee = await context.Employee.FirstOrDefaultAsync(x => x.id == id);

            if (employee == null)
            {
                return NotFound("Employee not found");
            }
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Employee employee)
        {
            if (ModelState.IsValid)
            {
                context.Employee.Add(employee);
                await context.SaveChangesAsync();
                return new CreatedAtRouteResult("GetEmployee", new { id = employee.id }, employee);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Employee employee)
        {
            if (id == employee.id)
            {
                context.Entry(employee).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(employee);
            }
            return NotFound("Id doesn't match");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var employee = await context.Employee.FirstOrDefaultAsync(a => a.id == id);
            if (employee == null)
            {
                return NotFound("Employee doesn't exist");
            }
            context.Employee.Remove(employee);
            await context.SaveChangesAsync();
            return Ok(employee);
        }
    }
}
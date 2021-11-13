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
    [Route("api/department")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public DepartmentController(ApplicationDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetAll()
        {
            return await context.Department.ToListAsync();
        }

        [HttpGet("{id}", Name = "GetDepartment")]
        public async Task<ActionResult<Department>> Get(int id)
        {
            var department = await context.Department.FirstOrDefaultAsync(x => x.id == id);

            if (department == null)
            {
                return NotFound("Department not found");
            }
            return Ok(department);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Department department)
        {
            if (ModelState.IsValid)
            {
                context.Department.Add(department);
                await context.SaveChangesAsync();
                return new CreatedAtRouteResult("GetDepartment", new { id = department.id }, department);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Department department)
        {
            if (id == department.id)
            {
                context.Entry(department).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(department);
            }
            return NotFound("Id doesn't match");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var department = await context.Department.FirstOrDefaultAsync(a => a.id == id);
            if (department == null)
            {
                return NotFound("ActiveType doesn't exist");
            }
            context.Department.Remove(department);
            await context.SaveChangesAsync();
            return Ok(department);
        }
    }
}
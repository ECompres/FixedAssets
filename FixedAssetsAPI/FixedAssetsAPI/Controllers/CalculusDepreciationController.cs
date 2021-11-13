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
    [Route("api/calculusDepreciation")]
    [ApiController]
    public class CalculusDepreciationController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public CalculusDepreciationController(ApplicationDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CalculusDepreciation>>> GetAll()
        {
            return await context.CalculusDepreciation.ToListAsync();
        }

        [HttpGet("{id}", Name = "GetCalculusDepreciation")]
        public async Task<ActionResult<CalculusDepreciation>> Get(int id)
        {
            var calculusDepreciation = await context.CalculusDepreciation.FirstOrDefaultAsync(x => x.id == id);

            if (calculusDepreciation == null)
            {
                return NotFound("Calculus Depreciation not found");
            }
            return Ok(calculusDepreciation);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CalculusDepreciation calculusDepreciation)
        {
            if (ModelState.IsValid)
            {
                context.CalculusDepreciation.Add(calculusDepreciation);
                await context.SaveChangesAsync();
                return new CreatedAtRouteResult("GetCalculusDepreciation", new { id = calculusDepreciation.id }, calculusDepreciation);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CalculusDepreciation calculusDepreciation)
        {
            if (id == calculusDepreciation.id)
            {
                context.Entry(calculusDepreciation).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(calculusDepreciation);
            }
            return NotFound("Id doesn't match");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var calculusDepreciation = await context.CalculusDepreciation.FirstOrDefaultAsync(a => a.id == id);
            if (calculusDepreciation == null)
            {
                return NotFound("Calculus Depreciation doesn't exist");
            }
            context.CalculusDepreciation.Remove(calculusDepreciation);
            await context.SaveChangesAsync();
            return Ok(calculusDepreciation);
        }
    }

}

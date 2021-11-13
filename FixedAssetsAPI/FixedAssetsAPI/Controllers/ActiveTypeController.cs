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
    [Route("api/activeType")]
    [ApiController]
    public class ActiveTypeController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ActiveTypeController(ApplicationDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActiveType>>> GetAll()
        {
            return await context.ActiveType.ToListAsync();
        }

        [HttpGet("{id}", Name = "GetActiveType")]
        public async Task<ActionResult<ActiveType>> Get(int id)
        {
            var activeType = await context.ActiveType.FirstOrDefaultAsync(x => x.id == id);

            if (activeType == null)
            {
                return NotFound("ActiveType not found");
            }
            return Ok(activeType);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ActiveType activeType)
        {
            if (ModelState.IsValid)
            {
                context.ActiveType.Add(activeType);
                await context.SaveChangesAsync();
                return new CreatedAtRouteResult("GetActiveType", new { id = activeType.id }, activeType);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ActiveType activeType)
        {
            if(id == activeType.id)
            {
                context.Entry(activeType).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(activeType);
            }
            return NotFound("Id doesn't match");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var activeType = await context.ActiveType.FirstOrDefaultAsync(a => a.id == id);
            if (activeType == null)
            {
                return NotFound("ActiveType doesn't exist");
            }
            context.ActiveType.Remove(activeType);
            await context.SaveChangesAsync();
            return Ok(activeType);
        }
    }
}

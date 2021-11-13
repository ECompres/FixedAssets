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
    [Route("api/fixedAsset")]
    [ApiController]
    public class FixedAssetController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public FixedAssetController(ApplicationDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FixedAsset>>> GetAll()
        {
            return await context.FixedAsset.ToListAsync();
        }

        [HttpGet("{id}", Name = "GetFixedAsset")]
        public async Task<ActionResult<FixedAsset>> Get(int id)
        {
            var fixedAsset = await context.FixedAsset.FirstOrDefaultAsync(x => x.id == id);

            if (fixedAsset == null)
            {
                return NotFound("Fixed Asset not found");
            }
            return Ok(fixedAsset);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] FixedAsset fixedAsset)
        {
            if (ModelState.IsValid)
            {
                context.FixedAsset.Add(fixedAsset);
                await context.SaveChangesAsync();
                return new CreatedAtRouteResult("GetFixedAsset", new { id = fixedAsset.id }, fixedAsset);
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] FixedAsset fixedAsset)
        {
            if (id == fixedAsset.id)
            {
                context.Entry(fixedAsset).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(fixedAsset);
            }
            return NotFound("Id doesn't match");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var fixedAsset = await context.FixedAsset.FirstOrDefaultAsync(a => a.id == id);
            if (fixedAsset == null)
            {
                return NotFound("Fixed Asset doesn't exist");
            }
            context.FixedAsset.Remove(fixedAsset);
            await context.SaveChangesAsync();
            return Ok(fixedAsset);
        }
    }
}
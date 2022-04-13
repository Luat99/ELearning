#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ELearning.DataContext;
using ELearning.Models;
using Microsoft.AspNetCore.Authorization;

namespace ELearning.Controllers.ModelsController
{
    [Authorize(Roles = "Admin,Administrators,Teacher,Students")]

    [Route("api/[controller]")]
    [ApiController]
    public class ManageTeachingMaterialsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ManageTeachingMaterialsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ManageTeachingMaterials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ManageTeachingMaterials>>> GetManageTeachingMaterialss()
        {
            return await _context.ManageTeachingMaterialss.ToListAsync();
        }

        // GET: api/ManageTeachingMaterials/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ManageTeachingMaterials>> GetManageTeachingMaterials(Guid id)
        {
            var manageTeachingMaterials = await _context.ManageTeachingMaterialss.FindAsync(id);

            if (manageTeachingMaterials == null)
            {
                return NotFound();
            }

            return manageTeachingMaterials;
        }

        // PUT: api/ManageTeachingMaterials/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManageTeachingMaterials(Guid id, ManageTeachingMaterials manageTeachingMaterials)
        {
            if (id != manageTeachingMaterials.ID)
            {
                return BadRequest();
            }

            _context.Entry(manageTeachingMaterials).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManageTeachingMaterialsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ManageTeachingMaterials
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ManageTeachingMaterials>> PostManageTeachingMaterials(ManageTeachingMaterials manageTeachingMaterials)
        {
            _context.ManageTeachingMaterialss.Add(manageTeachingMaterials);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetManageTeachingMaterials", new { id = manageTeachingMaterials.ID }, manageTeachingMaterials);
        }

        // DELETE: api/ManageTeachingMaterials/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManageTeachingMaterials(Guid id)
        {
            var manageTeachingMaterials = await _context.ManageTeachingMaterialss.FindAsync(id);
            if (manageTeachingMaterials == null)
            {
                return NotFound();
            }

            _context.ManageTeachingMaterialss.Remove(manageTeachingMaterials);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ManageTeachingMaterialsExists(Guid id)
        {
            return _context.ManageTeachingMaterialss.Any(e => e.ID == id);
        }
    }
}

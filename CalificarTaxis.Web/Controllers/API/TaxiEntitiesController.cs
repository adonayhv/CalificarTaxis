using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CalificarTaxis.Web.Entiries.Data;
using CalificarTaxis.Web.Helpers;

namespace CalificarTaxis.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxiEntitiesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConverterHelper _converterHelper;

        public TaxiEntitiesController(DataContext context,
            IConverterHelper converterHelper
)
        {
            _context = context;
            _converterHelper = converterHelper;
        }

        // GET: api/TaxiEntities
        [HttpGet]
        public IEnumerable<TaxiEntity> GetTaxiEntities()
        {
            return _context.TaxiEntities;
        }

        // GET: api/TaxiEntities/5
        [HttpGet("{plaque}")]
        public async Task<IActionResult> GetTaxiEntity([FromRoute] string plaque)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            plaque = plaque.ToUpper();
            TaxiEntity taxiEntity = await _context.TaxiEntities
                .Include(t => t.User) //driver
                .Include(t => t.trips)
                .ThenInclude(t => t.tripDetails)
                .Include(t => t.trips)
                .ThenInclude(t => t.User) //pasajero
                .FirstOrDefaultAsync(t => t.Plaque == plaque);


            if (taxiEntity == null)
            {
                return NotFound();
            }

            return Ok(_converterHelper.ToTaxiResponse(taxiEntity));

        }

        // PUT: api/TaxiEntities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaxiEntity([FromRoute] int id, [FromBody] TaxiEntity taxiEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != taxiEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(taxiEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaxiEntityExists(id))
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

        // POST: api/TaxiEntities
        [HttpPost]
        public async Task<IActionResult> PostTaxiEntity([FromBody] TaxiEntity taxiEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TaxiEntities.Add(taxiEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaxiEntity", new { id = taxiEntity.Id }, taxiEntity);
        }

        // DELETE: api/TaxiEntities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaxiEntity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var taxiEntity = await _context.TaxiEntities.FindAsync(id);
            if (taxiEntity == null)
            {
                return NotFound();
            }

            _context.TaxiEntities.Remove(taxiEntity);
            await _context.SaveChangesAsync();

            return Ok(taxiEntity);
        }

        private bool TaxiEntityExists(int id)
        {
            return _context.TaxiEntities.Any(e => e.Id == id);
        }
    }
}
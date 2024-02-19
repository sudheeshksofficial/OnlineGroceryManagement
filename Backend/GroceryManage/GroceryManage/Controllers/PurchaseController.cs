using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GroceryManage.DataAccess;
using GroceryManage.models;
using Microsoft.Extensions.Logging;
using log4net;

namespace GroceryManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly GroceryDbContext _context;
        private readonly ILogger<PurchaseController> _logger;
        private readonly ILog log;

        public PurchaseController(GroceryDbContext context, ILogger<PurchaseController> logger)
        {
            _context = context;
            _logger = logger;
            log = LogManager.GetLogger(typeof(PurchaseController));

        }

        // GET: api/Purchase
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Purchase>>> Getpurchase()
        {
            log.Warn("Log4Net: Wirting some information : get purchase");
            return await _context.purchase.ToListAsync();
        }

        // GET: api/Purchase/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Purchase>> GetPurchase(int id)
        {
            var purchase = await _context.purchase.FindAsync(id);

            if (purchase == null)
            {
                return NotFound();
            }

            return purchase;
        }

        // PUT: api/Purchase/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchase(int id, Purchase purchase)
        {
            if (id != purchase.Id)
            {
                return BadRequest();
            }

            _context.Entry(purchase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseExists(id))
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

        // POST: api/Purchase
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Purchase>> PostPurchase(Purchase purchase)
        {
            _context.purchase.Add(purchase);
            await _context.SaveChangesAsync();
            log.Info("Log4Net: Wirting some information :one purchase added");
            return CreatedAtAction("GetPurchase", new { id = purchase.Id }, purchase);

        }

        // DELETE: api/Purchase/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchase(int id)
        {
            var purchase = await _context.purchase.FindAsync(id);
            if (purchase == null)
            {
                return NotFound();
            }

            _context.purchase.Remove(purchase);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PurchaseExists(int id)
        {
            return _context.purchase.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GroceryManage.DataAccess;
using GroceryManage.models;
using GroceryManage.services;

namespace GroceryManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
   
        IStock _stockservice;
      //  private readonly GroceryDbContext _context;

        //public StockController(GroceryDbContext context)
        //{
        //    _context = context;
        //}
        public StockController(IStock _contexts)
        {
            
            _stockservice = _contexts;

        }

        // GET: api/Stock
        [HttpGet]
        public async Task<IActionResult> Getstocks()
        {
            try
            {
                //    var stocllist = _stockservice.GetStocksList();
                //    if (stocllist == null) return NotFound();
                //    return Ok(stocllist);
                var result = _stockservice.GetStocksList();
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET: api/Stock/5
        [HttpGet("{id}")]

        public IActionResult GetStocks(int id)
        {
            //  var stocks = await _context.stocks.FindAsync(id);
            try
            {
                var stocklist = _stockservice.GetStockDetailsById(id);
                if (stocklist == null) return NotFound();
                return Ok(stocklist);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/Stock/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutStocks(int id, Stocks stocks)
        //{

        //    if (id != stocks.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(stocks).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        throw;
        //    }

        //    return NoContent();
        //}

        // POST: api/Stock
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostStocks(Stocks stocks)
        {
            //_context.stocks.Add(stocks);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetStocks", new { id = stocks.Id }, stocks);
            try
            {
                var model = _stockservice.SaveStock(stocks);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE: api/Stock/5
        [HttpDelete("{id}")]
        public IActionResult DeleteStocks(int id)
        {
            //var stocks = await _context.stocks.FindAsync(id);
            try
            {
                var model = _stockservice.DeleteStock(id);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

      
    }
}

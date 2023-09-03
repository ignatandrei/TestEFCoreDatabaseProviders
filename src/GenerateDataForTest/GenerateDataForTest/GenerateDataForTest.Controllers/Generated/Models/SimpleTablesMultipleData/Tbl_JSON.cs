﻿//4.this was autogenerated by a tool. Do not modify! Use partial
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Generated;
[ApiController]
[Route("api/[controller]")]    
public partial class REST_SimpleTablesMultipleData_Tbl_JSONController : Controller
{
    private SimpleTablesMultipleData _context;
    public REST_SimpleTablesMultipleData_Tbl_JSONController(SimpleTablesMultipleData context)
	{
        _context=context;
	}
    [HttpGet]
    public async Task<Tbl_JSON_Table[]> Get(){
        var data= await _context.Tbl_JSON.ToArrayAsync();
        var ret = data.Select(it => (Tbl_JSON_Table)it!).ToArray();
        return ret;

        
    }
    
        [HttpGet("{id}")]
    public async Task<ActionResult<Tbl_JSON_Table>> GetTbl_JSON(int id)
    {
        if (_context.Tbl_JSON == null)
        {
            return NotFound();
        }
        var item = await _context.Tbl_JSON.FirstOrDefaultAsync(e => e.ID==id);

        if (item == null)
        {
            return NotFound();
        }

        return (Tbl_JSON_Table)item!;
    }


    [HttpPatch("{id}")]
        public async Task<IActionResult> PutTbl_JSON(int id, Tbl_JSON value)
        {
            if (id != value.ID)
            {
                return BadRequest();
            }

            _context.Entry(value).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tbl_JSONExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Tbl_JSON>> PostTbl_JSON(Tbl_JSON_Table value)
        {
          
            var val = new Tbl_JSON();
            val.CopyFrom(value);
            _context.Tbl_JSON.Add(val);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbl_JSON", new { id = val.ID }, val);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbl_JSON(int id)
        {
            if (_context.Tbl_JSON == null)
            {
                return NotFound();
            }
            var item = await _context.Tbl_JSON.FirstOrDefaultAsync(e => e.ID==id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Tbl_JSON .Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Tbl_JSONExists(int id)
        {
            return (_context.Tbl_JSON.Any(e => e.ID  == id));
        }

    }    

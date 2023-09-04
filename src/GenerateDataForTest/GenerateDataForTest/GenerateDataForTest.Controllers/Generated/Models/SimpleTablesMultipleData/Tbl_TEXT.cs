﻿//4.this was autogenerated by a tool. Do not modify! Use partial
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Generated;
[ApiController]
[Route("api/[controller]")]    
public partial class REST_SimpleTablesMultipleData_Tbl_TEXTController : Controller
{
    private SimpleTablesMultipleData _context;
    public REST_SimpleTablesMultipleData_Tbl_TEXTController(SimpleTablesMultipleData context)
	{
        _context=context;
	}
    [HttpGet]
    public async Task<Tbl_TEXT_Table[]> Get(){
        var data= await _context.Tbl_TEXT.ToArrayAsync();
        var ret = data.Select(it => (Tbl_TEXT_Table)it!).ToArray();
        return ret;

        
    }
    
        [HttpGet("{id}")]
    public async Task<ActionResult<Tbl_TEXT_Table>> GetTbl_TEXT(int id)
    {
        if (_context.Tbl_TEXT == null)
        {
            return NotFound();
        }
        var item = await _context.Tbl_TEXT.FirstOrDefaultAsync(e => e.ID==id);

        if (item == null)
        {
            return NotFound();
        }

        return (Tbl_TEXT_Table)item!;
    }


    [HttpPatch("{id}")]
        public async Task<IActionResult> PutTbl_TEXT(int id, Tbl_TEXT value)
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
                if (!Tbl_TEXTExists(id))
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
        public async Task<ActionResult<Tbl_TEXT>> PostTbl_TEXT(Tbl_TEXT_Table value)
        {
          
            var val = new Tbl_TEXT();
            val.CopyFrom(value);
            _context.Tbl_TEXT.Add(val);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbl_TEXT", new { id = val.ID }, val);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbl_TEXT(int id)
        {
            if (_context.Tbl_TEXT == null)
            {
                return NotFound();
            }
            var item = await _context.Tbl_TEXT.FirstOrDefaultAsync(e => e.ID==id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Tbl_TEXT .Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Tbl_TEXTExists(int id)
        {
            return (_context.Tbl_TEXT.Any(e => e.ID  == id));
        }

    }    
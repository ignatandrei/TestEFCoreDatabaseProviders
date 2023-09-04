﻿//4.this was autogenerated by a tool. Do not modify! Use partial
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Generated;
[ApiController]
[Route("api/[controller]")]    
public partial class REST_SimpleTablesMultipleData_Tbl_NVARCHARController : Controller
{
    private SimpleTablesMultipleData _context;
    public REST_SimpleTablesMultipleData_Tbl_NVARCHARController(SimpleTablesMultipleData context)
	{
        _context=context;
	}
    [HttpGet]
    public async Task<Tbl_NVARCHAR_Table[]> Get(){
        var data= await _context.Tbl_NVARCHAR.ToArrayAsync();
        var ret = data.Select(it => (Tbl_NVARCHAR_Table)it!).ToArray();
        return ret;

        
    }
    
        [HttpGet("{id}")]
    public async Task<ActionResult<Tbl_NVARCHAR_Table>> GetTbl_NVARCHAR(int id)
    {
        if (_context.Tbl_NVARCHAR == null)
        {
            return NotFound();
        }
        var item = await _context.Tbl_NVARCHAR.FirstOrDefaultAsync(e => e.ID==id);

        if (item == null)
        {
            return NotFound();
        }

        return (Tbl_NVARCHAR_Table)item!;
    }


    [HttpPatch("{id}")]
        public async Task<IActionResult> PutTbl_NVARCHAR(int id, Tbl_NVARCHAR value)
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
                if (!Tbl_NVARCHARExists(id))
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
        public async Task<ActionResult<Tbl_NVARCHAR>> PostTbl_NVARCHAR(Tbl_NVARCHAR_Table value)
        {
          
            var val = new Tbl_NVARCHAR();
            val.CopyFrom(value);
            _context.Tbl_NVARCHAR.Add(val);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbl_NVARCHAR", new { id = val.ID }, val);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbl_NVARCHAR(int id)
        {
            if (_context.Tbl_NVARCHAR == null)
            {
                return NotFound();
            }
            var item = await _context.Tbl_NVARCHAR.FirstOrDefaultAsync(e => e.ID==id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Tbl_NVARCHAR .Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Tbl_NVARCHARExists(int id)
        {
            return (_context.Tbl_NVARCHAR.Any(e => e.ID  == id));
        }

    }    
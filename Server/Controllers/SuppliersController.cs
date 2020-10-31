using BlazorCRUD.Server.Data;
using BlazorCRUD.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorCRUD.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private IConfiguration Configuration;
        private readonly SuppliersContext SuppCtx;

        public SuppliersController(IConfiguration _config, SuppliersContext supplierContext)
        {
            Configuration = _config;
            this.SuppCtx = supplierContext;
        }


        // GET: api/<SuppliersController>
        [HttpGet]
        public IEnumerable<Supplier> Get()
        {
            var suppliers = SuppCtx.Suppliers.ToList();

            return suppliers;
        }

        // GET api/<SuppliersController>/5
        [HttpGet("{id}")]
        public async Task<Supplier> Get(int id)
        {
            var SelSupplier = await SuppCtx.Suppliers.FindAsync(id);
            return SelSupplier;
        }

        // POST api/<SuppliersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                if (SuppCtx.Suppliers.Count() < 50)
                {
                    SuppCtx.Suppliers.Add(supplier);
                    await SuppCtx.SaveChangesAsync();
                }
                return Ok("\"Customer created successfully!\"");
            }
            else
            {
                return BadRequest("\"Error while updating supplier!\"");
            }
        }

        // PUT api/<SuppliersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                if (id != supplier.SupplierID)
                {
                    return BadRequest();
                }
                SuppCtx.Suppliers.Update(supplier);
                await SuppCtx.SaveChangesAsync();
                return Ok("\"Customer updated successfully!\"");
            }
            else
            {
                return BadRequest("\"Error while updating supplier!\"");
            }
        }

        // DELETE api/<SuppliersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

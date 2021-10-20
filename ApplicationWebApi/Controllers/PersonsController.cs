using ApplicationWebApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApplicationWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly PersondbContext _db; // privatno polje ili privatno svojstvo kontoler klase
        public PersonsController(PersondbContext db)
        {
            _db = db;
        }
        // GET: api/<PersonsController>
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            // pristupi bazi i povuci rezultat iz baze
            var persons = await _db.Persons.ToListAsync();

            // napravi objekat json rezultata i daj mu vrednost vracenu iz baze
            var jsonResult = new JsonResult(new { data = persons });

            // return/ vrati rezultat korisniku koji ga je zatrazio u JSON obliku
            return jsonResult;
        }

        // GET api/<PersonsController>/5
        [HttpGet("{id}")]
        public async Task<JsonResult> Get(int id)
        {
            // pristupi bazi i povuci rezultat iz baze
            var person = _db.Persons.Where(x => x.Id == id).SingleOrDefault();

            // napravi objekat json rezultata i daj mu vrednost vracenu iz baze
            var jsonResult = new JsonResult(new { data = person });

            // return/ vrati rezultat korisniku koji ga je zatrazio u JSON obliku
            return jsonResult;
        }

        // POST api/<PersonsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PersonsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PersonsController>/5
        [HttpDelete("{id}")]
        public async Task<JsonResult> Delete(int id)
        {
            var person = await _db.Persons.FirstOrDefaultAsync(u => u.Id == id);
            _db.Persons.Remove(person);
            await _db.SaveChangesAsync();
            return new JsonResult(new { success = true, message = "Delete successful" });
        }
    }
}

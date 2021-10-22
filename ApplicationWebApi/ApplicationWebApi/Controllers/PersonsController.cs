using ApplicationWebApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationWebApi.ApiModels;
using ApplicationWebApi.Models;

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
        public void Post([FromBody] PersonApiModel personApiModel)
        {
            // ako zelis ovde mozes da imas neki vid validacije 
            // nesto tipa da proveris da li su svi parametri uredno popunjeni itd.

            _db.Persons.Add(new Persons
            {
                Name = personApiModel.Name,
                LastName = personApiModel.LastName,
                JMBG = personApiModel.Jmbg
            });

            _db.SaveChangesAsync();

            // u zavnosti kako zelis da isprogramis odgovor od apija ti mozes ili ne moras da -
            // vratis json odgovor da je operacija prosla uspesno
            // trenutno tvoj api ne vraca nikakav rezultat kada pozoves ovu akciju
            // primer kako api vraca neki odgovor imas u nekoj od drugih metoda ove controller klase
        }

        // PUT api/<PersonsController>/5
        [HttpPut("{id}")]
        public async Task PutAsync(int id, [FromBody] PersonApiModel personApiModel)
        {
            // pristupi bazi i povuci rezultat iz baze
            var person = await _db.Persons.FirstOrDefaultAsync(u => u.Id == id);

            person.Name = personApiModel.Name;
            person.LastName = personApiModel.LastName;
            person.JMBG = personApiModel.Jmbg;

            // izvrisi funkcio za update podatka iz baze
            _db.Persons.Update(person);
            // pozovi funkciju koja izvrsava promene nad bazom
            await _db.SaveChangesAsync();


            // u zavnosti kako zelis da isprogramis odgovor od apija ti mozes ili ne moras da -
            // vratis json odgovor da je operacija prosla uspesno
            // trenutno tvoj api ne vraca nikakav rezultat kada pozoves ovu akciju
            // primer kako api vraca neki odgovor imas u nekoj od drugih metoda ove controller klase
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

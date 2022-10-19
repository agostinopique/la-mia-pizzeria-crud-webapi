using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PizzasController : ControllerBase
    {
        public PizzeriaContext _db;

        public PizzasController()
        {
            _db = new PizzeriaContext();
        }


        [HttpGet]
        public IActionResult Get(string? name)
        {
            IQueryable<Pizza> pizze;
            if(name != null)
            {
                pizze = _db.Pizze.Where(pizza => pizza.Name.ToLower() == name.ToLower());
            }
            else
            {
                pizze = _db.Pizze;
            }

            return Ok(pizze.ToList<Pizza>());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int? id)
        {

            if (id != null)
            {
                Pizza pizza = _db.Pizze.Where(pizza => pizza.Id == id).FirstOrDefault();
                return Ok(pizza);
            }
            else
            {
                List<Pizza> pizze = _db.Pizze.ToList();
                return Ok(pizze);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetPizza(int id)
        {
            PizzeriaContext _db = new PizzeriaContext();
            Pizza pizza = _db.Pizze.Find(id);
            return Ok(pizza);
        }

        [HttpPut("{id}")]
        public IActionResult EditPizza(int id, [FromBody] Pizza pizza)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            PizzeriaContext _db = new PizzeriaContext();
            Pizza pizzaToUpdate = _db.Pizze.Find(id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePizza(int id)
        {
            PizzeriaContext _db = new PizzeriaContext();

            Pizza pizzaToDelete = _db.Pizze.Find(id);

            if(pizzaToDelete != null)
            {
                _db.Pizze.Remove(pizzaToDelete);
                _db.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

    }
}
 
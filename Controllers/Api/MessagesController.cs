using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_static.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        public IActionResult Post([FromBody] Message message)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            else
            {
                PizzeriaContext db = new PizzeriaContext();
                db.Message.Add(message);
                db.SaveChanges();
                return Ok();
            }
        }
    }
}

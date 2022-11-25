using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TecnicalTestLibrary.Api.Infrastructure.Context;
using TecnicalTestLibrary.Api.Infrastructure.Entities;
using TecnicalTestLibrary.Api.Responses;

namespace TecnicalTestLibrary.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public UsersController(ApplicationDbContext context) 
        {
            _context= context;
        }

        [HttpGet]
        public ActionResult<Response> Login(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(x => x.Username == username && x.Pass == password);

            if (username == null && password == null)
            {
                return BadRequest(new Response { Message = "Debe ingresar el usuario y contraseña." });
            }

            if (user == null)
            {
                return BadRequest(new Response { Message = "Usuario o contraseña incorrectos. Ingrese nuevamente." });
            }

            return Ok(new Response { Message = "Exitoso" });
        }

        [HttpPost]
        public ActionResult CreateUser(User user)
        {
            var _user = _context.Users.Where(x => x.Username == user.Pass && x.Pass == user.Pass).FirstOrDefault();

            if (_user != null)
            {
                return Ok(new Response { Message = "Usuario Existe" });
            }

            _context.Add(user);
            _context.SaveChanges();

            return Ok(new Response { Message = "Usuario creado éxitosamente." });
        }

        [HttpDelete]
        public ActionResult DeleteUser(string username)
        {
            var user = _context.Users.Where(x => x.Username == username).FirstOrDefault();

            if (user == null)
            {
                return NotFound(new Response { Message = "Usuario no existe."});
            }

            _context.Remove(user);
            _context.SaveChanges();

            return Ok(new Response { Message = "Usuario eliminado con éxito." });
        }

        [HttpPut]
        public ActionResult UpdateUser(User user)
        {
            var _user = _context.Users.Where(x => x.Username == user.Username).FirstOrDefault();

            if (_user == null)
            {
                return NotFound(new Response { Message = "Usuario no existe." });
            }

            _context.Update(user);
            _context.SaveChanges();

            return Ok(new Response { Message = "Se cambió la contraseña correctamente." });
        }
    }
}

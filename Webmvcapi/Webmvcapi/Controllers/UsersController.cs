using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Webmvcapi.Models;
using Webmvcapi.Services;
using System.Net.Mail;
using MongoDB.Driver;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace Webmvcapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        //OBTENER TODOS LOS USUARIOS
        [HttpGet("getall", Name = "GetAll")]
        public ActionResult<List<users>> Get() =>
        _userService.Get();

        //OBTENER UN USUARIO
        [HttpGet("getuser{Id:length(24)}", Name = "GetUser")]
        public ActionResult<users> Get(string Id)
        {
            var user = _userService.Get(Id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        //CREAR UN USUARIO
        [HttpPost("create")]
        public ActionResult<users> Create(users user)
        {
            _userService.Create(user);
            return CreatedAtRoute("GetUser", user, null);
        }


        //ACTUALIZAR
        [HttpPut("update/{Id:length(24)}")]
        public IActionResult Update(string Id)
        {

            var user = _userService.Get(Id);
            if (user == null)
            {
                return NotFound();
            }

            if (user.status == "PrimerRecordatorio")
            {
                user.status = "SegundoRecordatorio";
            }else if (user.status == "SegundoRecordatorio")
            {
                user.status = "Desactivado";
            }
            _userService.Update(Id, user);

            _userService.sendEmail(user.email);
            return NoContent();
            

        }

        //DELETE BORRAR
        [HttpDelete("delete{Id:length(24)}")]
        public IActionResult Delete(string Id)
        {
            var user = _userService.Get(Id);
            if (user == null)
            {
                return NotFound();
            }
            _userService.Remove(Id);
            return NoContent();
        }
        
    }
}

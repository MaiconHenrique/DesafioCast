using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioCast.Context;
using DesafioCast.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioCast.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly BibliotecaContexto _bibliotecContexto;

        public ClienteController(BibliotecaContexto bibliotecaContexto)
        {
            this._bibliotecContexto = bibliotecaContexto;
        }

        public ActionResult Index()
        {
            return View(_bibliotecContexto.Clientes.ToList());
        }

        [HttpGet]
        public ActionResult Cliente()
        {

            return View(_bibliotecContexto.Clientes.ToList());
        }

        [HttpGet]
        [Route("CadastroCliente")]
        public ActionResult CadastroCliente()
        {
            return View("CadastroCliente");
        }

        [HttpPost]
        [Route("CadastroCliente")]
        public ActionResult CadastroCliente([FromForm]Cliente cliente)
        {
            var cpf = cliente.Cpf;
            cliente.Cpf = cpf.Replace(".", string.Empty).Replace("-", string.Empty);
            _bibliotecContexto.Clientes.Add(cliente);
            _bibliotecContexto.SaveChanges();
            return View();
        }

        [HttpGet]
        [Route("DetalharCliente")]
        public ActionResult DetalharCliente(int id)
        {
            var cliente = _bibliotecContexto.Clientes.FirstOrDefault(x => x.Id == id);
            if (cliente == null) return NotFound();
            return View(cliente);
        }

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var cliente = _bibliotecContexto.Clientes.Find(id);
            _bibliotecContexto.Remove(cliente);
            _bibliotecContexto.SaveChanges();
            return RedirectToAction("Cliente");
        }


        [HttpGet]
        [Route("EditarCliente/{id}")]
        public ActionResult EditarCliente(int id)
        {
            return View("EditarCliente", _bibliotecContexto.Clientes.Find(id));
        }

        [HttpPost]
        [Route("EditarCliente/{id?}")]
        public ActionResult EditarCliente(int id, [FromForm]Cliente cliente)
        {
            _bibliotecContexto.Entry(cliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _bibliotecContexto.SaveChanges();
            return View();
        }
    }
}
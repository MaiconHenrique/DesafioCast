using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioCast.Context;
using DesafioCast.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BibliotecaASPCore.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmprestimoController : Controller
    {
        private readonly BibliotecaContexto bibliotecaContexto;

        public EmprestimoController(BibliotecaContexto bibliotecaContexto)
        {
            this.bibliotecaContexto = bibliotecaContexto;
        }


        public ActionResult Index()
        {
            return View(bibliotecaContexto.Aluguels.ToList());
        }

        [HttpGet]
        public ActionResult Emprestimo()
        {
            return View(bibliotecaContexto.Aluguels.ToList());
        }

        [HttpGet]
        [Route("CadastroEmprestimo")]
        public ActionResult CadastroEmprestimo()
        {

            return View("CadastroEmprestimo");
        }

        [HttpPost]
        [Route("CadastroEmprestimo")]
        public ActionResult CadastroEmprestimo([FromForm]Emprestimo aluguel)
        {


            aluguel.DataAluguel = DateTime.Now;

            bibliotecaContexto.Aluguels.Add(aluguel);
            var status = bibliotecaContexto.Livros.SingleOrDefault(x => x.Id == aluguel.IdLivro); 
            var nomeDoCliente = bibliotecaContexto.Clientes.SingleOrDefault(x => x.Id == aluguel.IdCliente);

            IEnumerable<Emprestimo> clientes = bibliotecaContexto.Aluguels.ToList();
 
            ViewBag.listofitems = new SelectList(clientes, "IdCliente", "nomeDoCliente.Nome");
            

            if (status.Status == DesafioCast.Models.Enum.Status.Alugado)
            {
                return NotFound();
            }

            if(aluguel.DataEntrega < aluguel.DataAluguel)
            {
                return NoContent();
            }

            if (status != null)
            {
                status.Status = DesafioCast.Models.Enum.Status.Alugado;
                bibliotecaContexto.SaveChanges();
            }
            bibliotecaContexto.SaveChanges();

            return View();
        }

        [HttpGet]
        [Route("DevolverLivro/{id}")]
        public ActionResult DevolverLivro(int id)
        {

            var emprestimo = bibliotecaContexto.Aluguels.FirstOrDefault(x => x.Id == id);

            if (emprestimo == null) return NoContent();

            var status = bibliotecaContexto.Livros.SingleOrDefault(x => x.Id == emprestimo.IdLivro);
            if (status != null)
            {
                status.Status = DesafioCast.Models.Enum.Status.Disponivel;
                bibliotecaContexto.SaveChanges();
            }

            bibliotecaContexto.Aluguels.Remove(emprestimo);
            bibliotecaContexto.SaveChanges();
            return RedirectToAction("Emprestimo");
        }




    }
}
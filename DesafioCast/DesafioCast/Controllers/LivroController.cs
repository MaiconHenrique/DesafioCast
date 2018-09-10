using DesafioCast.Context;
using DesafioCast.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BibliotecaASPCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : Controller
    {
        private readonly BibliotecaContexto bibliotecaContexto;

        public LivroController(BibliotecaContexto bibliotecaContexto)
        {
            this.bibliotecaContexto = bibliotecaContexto;
        }


        public ActionResult Index()
        {
            return View(bibliotecaContexto.Livros.ToList());
        }

        [HttpGet]
        public ActionResult Livro()
        {
            return View(bibliotecaContexto.Livros.ToList());
        }
        [HttpGet]
        [Route("CadastroLivro")]
        public ActionResult CadastroLivro()
        {
            return View("CadastroLivro");
        }

        [HttpPost]
        [Route("CadastroLivro")]
        public ActionResult CadastroLivro([FromForm]Livro livro)
        {
            bibliotecaContexto.Livros.Add(livro);
            bibliotecaContexto.SaveChanges();
            return View();
        }

        [HttpGet]
        [Route("DetalharLivro")]
        public ActionResult DetalharLivro(int id)
        {
            var livro = bibliotecaContexto.Livros.FirstOrDefault(x => x.Id == id);
            if (livro == null) return NotFound();
            return View(livro);
        }

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var livro = bibliotecaContexto.Livros.Find(id);
            bibliotecaContexto.Remove(livro);
            bibliotecaContexto.SaveChanges();
            return RedirectToAction("Livro");
        }


        [HttpGet]
        [Route("EditarLivro/{id}")]
        public ActionResult EditarLivro(int id)
        {
            return View("EditarLivro", bibliotecaContexto.Livros.Find(id));
        }

        [HttpPost]
        [Route("EditarLivro/{id?}")]
        public ActionResult EditarLivro(int id, [FromForm]Livro livro)
        {
            bibliotecaContexto.Entry(livro).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            bibliotecaContexto.SaveChanges();
            return View();
        }
    }
}
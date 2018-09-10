using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioCast.Models
{
    public class Emprestimo
    {
        public int Id { get; set; }

        public int IdCliente { get; set; }
        [Key]
        public Cliente Cliente { get; set; }

        [Key]
        public int IdLivro { get; set; }
        public Livro Livro { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataAluguel { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataEntrega { get; set; }

    }
}

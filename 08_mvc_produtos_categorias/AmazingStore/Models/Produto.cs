using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AmazingStore.Models
{
    public class Produto
    {
        public int Id { get; set; }
        [Display(Name="Produto")]
        [Required(ErrorMessage ="Deve indicar um nome para o produto.")]
        public string Nome { get; set; }

        public int QtdStock { get; set; }
        
        public int Preco { get; set; }

        [Required(ErrorMessage = "Deve selecionar uma categoria para o produto.")]
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }

    }
}
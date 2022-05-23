using Domain.Models;
using System.Collections.Generic;

namespace Application.ViewModels
{
    public class ProdutoViewModel
    {
        public Produto Produto { get; set; }
        public List<Produto> Lista { get; set; }
    }
}

using Blog.DAO;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.ViewComponents
{
    public class ListaCategoriasViewComponent : ViewComponent
    {
        private readonly PostDAO dao;
        public ListaCategoriasViewComponent(PostDAO dao)
        {
            this.dao = dao;
        }
        public IViewComponentResult Invoke()
        {
            var posts = dao.ListaPublicados();
            CategoriaComQuantidadeViewModel categoriaQuantidade = new CategoriaComQuantidadeViewModel(posts);
            return View(categoriaQuantidade);
        }
    }
}

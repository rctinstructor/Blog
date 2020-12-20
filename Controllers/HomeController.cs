using Blog.DAO;
using Blog.Infra;
using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        //private BlogContext contexto;
        private PostDAO dao;
        public HomeController(PostDAO dao)
        {
            this.dao = dao;
        }
        //public HomeController()
        //{
        //    contexto = new BlogContext();
        //    dao = new PostDAO(contexto);
        //}
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        contexto.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //Action
        public IActionResult Index()
        {
            //PostDAO dao = new PostDAO();
            IList<Post> publicados = dao.ListaPublicados();
            return View(publicados);
        }

        public IActionResult Busca(string termo)
        {
            //PostDAO dao = new PostDAO();
            IList<Post> posts = dao.BuscaPeloTermo(termo);
            return View("Index", posts);
        }

        public IActionResult Categoria([Bind(Prefix = "id")] string categoria)
        {
            IList<Post> posts = dao.FiltraPorCategoria(categoria);
            return View("Index", posts);
        }
    }
}

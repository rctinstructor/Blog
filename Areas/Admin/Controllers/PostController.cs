using Blog.DAO;
using Blog.Filters;
using Blog.Infra;
using Blog.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Areas.Admin.Controllers
{
	[Area("Admin")]
	[AutorizacaoFilter]
	public class PostController : Controller
    {
	
		private PostDAO dao;
		public PostController(PostDAO dao)
		{
			this.dao = dao;
		}

	
		public IActionResult Index()
		{
			//PostDAO dao = new PostDAO();
			IList<Post> lista = dao.Lista();
			return View(lista);
		}
		public IActionResult Novo()
		{
			var model = new Post();
			return View(model);
		}

		[HttpPost]
		public IActionResult Adiciona(Post post)
		{
			if (ModelState.IsValid)
			{
				string usuarioJson = HttpContext.Session.GetString("usuario");
				Usuario logado = JsonConvert.DeserializeObject<Usuario>(usuarioJson);
				dao.Adiciona(post, logado);
				return RedirectToAction("Index");
			}
			else
			{
				return View("Novo", post);
			}
		}


		public IActionResult Categoria([Bind(Prefix = "id")] string categoria)
		{
			//PostDAO dao = new PostDAO();
			IList<Post> lista = dao.FiltraPorCategoria(categoria);
			return View("Index", lista);
		}


		public IActionResult RemovePost(int id)
		{
			//PostDAO dao = new PostDAO();
			dao.Remove(id);
			return RedirectToAction("Index");
		}


		public IActionResult Visualiza(int id)
		{
			//PostDAO dao = new PostDAO();
			Post post = dao.BuscaPorId(id);
			return View(post);
		}


		[HttpPost]
		public IActionResult EditaPost(Post post)
		{
			if (ModelState.IsValid)
			{
				//PostDAO dao = new PostDAO();
				dao.Atualiza(post);
				return RedirectToAction("Index");
			}
			else
			{
				return View("Visualiza", post);
			}
		}


		public IActionResult PublicaPost(int id)
		{
			//PostDAO dao = new PostDAO();
			dao.Publica(id);
			return RedirectToAction("Index");
		}


		[HttpPost]
		public ActionResult CategoriaAutocomplete(string termoDigitado)
		{
			//PostDAO dao = new PostDAO();
			var model = dao.ListaCategoriasQueContemTermo(termoDigitado);
			return Json(model);
		}

		public ActionResult Publica(int id)
		{
			Post post = dao.BuscaPorId(id);
			post.Publicado = true;
			post.DataPublicacao = DateTime.Now;
			dao.Atualiza(post);
			return new EmptyResult();
		}



	}
}

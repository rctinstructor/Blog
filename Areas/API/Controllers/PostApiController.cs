using Blog.DAO;
using Blog.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Areas.API.Controllers
{
    [Area("Api")]
    [ApiController]
    [Route("/api/post")]
    public class PostApiController : ControllerBase
    {
        private readonly PostDAO dao;
        public PostApiController(PostDAO dao)
        {
            this.dao = dao;
        }

        [HttpGet]
        [Route("lista")]
        public IActionResult BuscaTodosPosts()
        {
            IList<Post> posts = dao.Lista();
            return Ok(posts);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult BuscaPostPorId(int id)
        {
            return Ok(dao.BuscaPorId(id));
        }

        [Route("novo")]
        [HttpPost]
        public IActionResult CadastraPost([FromBody] Post post)
        {
            dao.Adiciona(post);
            return CreatedAtAction("BuscaPostPorId", new { id = post.Id }, post);
        }

        [Route("{id}")]
        [HttpPut]
        public IActionResult AtualizaPost(int id, [FromBody] Post post)
        {
            Post postBanco = dao.BuscaPorId(id);
            if (postBanco == null)
            {
                return NotFound();
            }
            postBanco.Titulo = post.Titulo;
            postBanco.Resumo = post.Resumo;
            postBanco.Categoria = post.Categoria;
            postBanco.Publicado = post.Publicado;
            postBanco.DataPublicacao = post.DataPublicacao;
            dao.Atualiza(postBanco);
            return NoContent();
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeletaPost(int id)
        {
            if (dao.BuscaPorId(id) == null)
            {
                return NotFound();
            }
            dao.Remove(id);
            return NoContent();
        }


    }
}

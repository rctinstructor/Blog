using Blog.Infra;
using Blog.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.DAO
{
    public class PostDAO
    {
        private BlogContext contexto;
        public PostDAO(BlogContext contexto)
        {
            this.contexto = contexto;
        }

        public IList<Post> Lista()
        {
            //using (BlogContext contexto = new BlogContext())
            //{
                var lista = contexto.Posts.ToList();
                return lista;
            //}
        }


        public void Adiciona(Post post)
        {
            //using (BlogContext contexto = new BlogContext())
            //{
                contexto.Posts.Add(post);
                contexto.SaveChanges();
            //}
        }


        public IList<Post> FiltraPorCategoria(string categoria)
        {
            //using (BlogContext contexto = new BlogContext())
            //{
                var lista = contexto.Posts.Where(post => post.Categoria.Contains(categoria)).ToList();
                return lista;
                //var lista = from p in contexto.Posts where p.Categoria.Contains(categoria) select p;
                //return lista.ToList();
            //}
        }


        public void Remove(int id)
        {
            //using (BlogContext contexto = new BlogContext())
            //{
                Post post = contexto.Posts.Find(id);
                contexto.Posts.Remove(post);
                contexto.SaveChanges();
            //}
        }


        public Post BuscaPorId(int id)
        {
            //using (BlogContext contexto = new BlogContext())
            //{
                Post post = contexto.Posts.Find(id);
                return post;
            //}
        }

        public void Atualiza(Post post)
        {
            //using (BlogContext contexto = new BlogContext())
            //{
                contexto.Entry(post).State = EntityState.Modified;
                contexto.SaveChanges();
            //}
        }


        public void Publica(int id)
        {
            //using (BlogContext contexto = new BlogContext())
            //{
                Post post = contexto.Posts.Find(id);
                post.Publicado = true;
                post.DataPublicacao = DateTime.Now;
                contexto.SaveChanges();
            //}
        }


        public IList<string> ListaCategoriasQueContemTermo(string termo)
        {
            //using (var contexto = new BlogContext())
            //{
                return contexto.Posts
                .Where(p => p.Categoria.Contains(termo))
                .Select(p => p.Categoria)
                .Distinct()
                .ToList();
            //}
        }


        public IList<Post> ListaPublicados()
        {
            //using (BlogContext contexto = new BlogContext())
            //{
                return contexto.Posts.Where(p => p.Publicado)
                .OrderByDescending(p => p.DataPublicacao).ToList();
            //}
        }


        public IList<Post> BuscaPeloTermo(string termo)
        {
            //using (var contexto = new BlogContext())
            //{
                return contexto.Posts
                .Where(p => (p.Publicado) && (p.Titulo.Contains(termo) || p.Resumo.Contains(termo)))
                .ToList();
            //}
        }


        public void Adiciona(Post post, Usuario usuario)
        {
            contexto.Usuarios.Attach(usuario);
            post.Autor = usuario;
            contexto.Posts.Add(post);
            contexto.SaveChanges();
        }

    }
}




/*
        public IList<Post> Lista()
{
    var lista = new List<Post>();
    using (SqlConnection cnx = ConnectionFactory.CriaConexaoAberta())
    {
        SqlCommand comando = cnx.CreateCommand();
        comando.CommandText = "select * from Posts";
        SqlDataReader leitor = comando.ExecuteReader();
        while (leitor.Read())
        {
            Post post = new Post()
            {
                Id = Convert.ToInt32(leitor["id"]),
                Titulo = Convert.ToString(leitor["titulo"]),
                Resumo = Convert.ToString(leitor["resumo"]),
                Categoria = Convert.ToString(leitor["categoria"])
            };
            lista.Add(post);
        }
    }
    return lista;
}

*/

/*
public void Adiciona(Post post)
{
    using (SqlConnection cnx = ConnectionFactory.CriaConexaoAberta())
    {
        SqlCommand comando = cnx.CreateCommand();
        comando.CommandText = "insert into Posts (Titulo, Resumo, Categoria) values (@titulo, @resumo, @categoria)";
        comando.Parameters.Add(new SqlParameter("titulo", post.Titulo));
        comando.Parameters.Add(new SqlParameter("resumo", post.Resumo));
        comando.Parameters.Add(new SqlParameter("categoria", post.Categoria));
        comando.ExecuteNonQuery();
    }
}

*/
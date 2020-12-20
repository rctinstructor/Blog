using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace Blog.Infra
{
    public class BlogContext : DbContext
    {
        //Log opcional Exercicio 4.8
        public static readonly ILoggerFactory consoleLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });


        public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }
        public DbSet<Post> Posts { get; set; }

        // Adicionado no capitulo 10
        public DbSet<Usuario> Usuarios { get; set; }

        //public DbSet<Post> Posts { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var builder = new ConfigurationBuilder()
        //            .SetBasePath(Directory.GetCurrentDirectory())
        //            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        //            .AddEnvironmentVariables();
        //    IConfiguration configuration = builder.Build();
        //    string stringConexao = configuration.GetConnectionString("Blog");
        //    optionsBuilder.UseSqlServer(stringConexao);
        //}

    }
}

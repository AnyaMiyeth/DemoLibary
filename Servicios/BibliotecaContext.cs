using Entidades;
using Microsoft.EntityFrameworkCore;
using System;

namespace Servicios
{
    public class BibliotecaContext : DbContext

    {
        public BibliotecaContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Editorial> Editorials { get; set; }

    }
}

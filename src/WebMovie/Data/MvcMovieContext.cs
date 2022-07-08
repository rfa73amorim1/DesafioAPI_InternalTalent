using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Data
{
    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext()
        {

        }
        public MvcMovieContext (DbContextOptions<MvcMovieContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MvcMovie.Models.Movie>? Movies { get; set; }

        public virtual DbSet<MvcMovie.Models.Categoria>? Categorias { get; set; }

        public virtual void  SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }
    }
}


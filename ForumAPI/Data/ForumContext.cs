using ForumAPI.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI.Data
{
    public class ForumContext : DbContext
    {
        public ForumContext(DbContextOptions<ForumContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Resposta>()
                .HasOne(resposta => resposta.Topico)
                .WithMany(topico => topico.Respostas);

            builder.Entity<Topico>()
                .HasOne(topico => topico.Curso)
                .WithMany(curso => curso.Topicos);

            builder.Entity<Topico>()
                .Property(e => e.Status)
                .HasConversion(
                    v => v.ToString(),
                    v => (StatusTopico)Enum.Parse(typeof(StatusTopico), v));

        }

        public DbSet<Curso> Cursos{ get; set; }
        public DbSet<Topico> Topicos { get; set; }

    }
}

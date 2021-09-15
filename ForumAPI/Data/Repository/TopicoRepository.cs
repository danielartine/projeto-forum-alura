using ForumAPI.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI.Data.Repository
{
    public class TopicoRepository
    {
        private ForumContext _context;

        public TopicoRepository(ForumContext context)
        {
            _context = context;
        }

        public Topico FindById(int id) => _context.Topicos.FirstOrDefault(t => t.Id == id);

        public Topico FindByCursoNome(string nome) => _context.Topicos.FirstOrDefault(t => t.Curso.Nome == nome);

        public List<Topico> FindAll() => _context.Topicos.ToList();

        public void Atualizar() => _context.SaveChanges();

        public void Save(Topico topico)
        {
            _context.Topicos.Add(topico);
            _context.SaveChanges();
        }

        public void Delete(Topico topico)
        {
            _context.Remove(topico);
            _context.SaveChanges();
        }

        
    }
}

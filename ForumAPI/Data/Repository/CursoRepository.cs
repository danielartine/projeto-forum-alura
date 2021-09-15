using ForumAPI.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI.Data.Repository
{
    public class CursoRepository
    {
        private ForumContext _context;

        public CursoRepository(ForumContext context)
        {
            _context = context;
        }

        public Curso FindByNome(string nome) => _context.Cursos.FirstOrDefault(c => c.Nome == nome);
    }
}

using ForumAPI.Data.Repository;
using ForumAPI.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI.Forms
{
    public class TopicoForm
    {
        [Required]
        [MinLength(5)]
        public string Titulo { get; set; }
        [Required]
        [MinLength(10)]
        public string Mensagem { get; set; }
        [Required]
        public string NomeCurso { get; set; }

        public Topico Converter(CursoRepository cursoRepository)
        {
            Curso curso = cursoRepository.FindByNome(NomeCurso);
            return new Topico(Titulo, Mensagem, curso);
        }
    }
}

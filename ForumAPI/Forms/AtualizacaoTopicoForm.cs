using ForumAPI.Data.Repository;
using ForumAPI.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI.Forms
{
    public class AtualizacaoTopicoForm
    {
        [Required]
        [MinLength(5)]
        public string Titulo { get; set; }
        [Required]
        [MinLength(10)]
        public string Mensagem { get; set; }

        public Topico Atualizar(int id, TopicoRepository topicoRepository)
        {
            Topico topico = topicoRepository.FindById(id);
            topico.Titulo = Titulo;
            topico.Mensagem = Mensagem;
            return topico;
        }
    }
}

using ForumAPI.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI.Dtos
{
    public class DetalhesDoTopicoDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Mensagem { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Status { get; set; }
        public List<Resposta> Respostas { get; set; }

        public DetalhesDoTopicoDto(Topico topico)
        {
            Id = topico.Id;
            Titulo = topico.Titulo;
            Mensagem = topico.Mensagem;
            DataCriacao = topico.DataCriacao;
            Status = topico.Status.ToString();
            Respostas = new List<Resposta>();
            Respostas.AddRange(topico.Respostas);

        }

        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI.Dtos
{
    public class RespostaDto
    {
        public int Id { get; set; }
        public string Mensagem { get; set; }
        public DateTime DataCriacao { get; set; }
        public string NomeAutor { get; set; }

        public RespostaDto(RespostaDto resposta)
        {
            Id = resposta.Id;
            Mensagem = resposta.Mensagem;
            DataCriacao = resposta.DataCriacao;
            NomeAutor = resposta.NomeAutor;
        }



        
    }
}

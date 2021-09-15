using ForumAPI.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI.Dtos
{
    public class TopicoDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Mensagem { get; set; }
        public DateTime DataCriacao { get; set; }

        public TopicoDto(Topico topico)
        {
            Id = topico.Id;
            Titulo = topico.Titulo;
            Mensagem = topico.Mensagem;
            DataCriacao = topico.DataCriacao;
        }
        public static List<TopicoDto> Converter(List<Topico> topicos)
        {
            List<TopicoDto> topicosDto = new List<TopicoDto>();
            foreach(Topico topico in topicos)
            {
                TopicoDto topicoDto = new TopicoDto(topico);
                topicosDto.Add(topicoDto);
            }

            return topicosDto;
        }
    }
}

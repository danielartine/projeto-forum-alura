using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI.Modelos
{
    public class Topico
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Mensagem { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public StatusTopico Status { get; set; } = StatusTopico.NAO_RESPONDIDO;
        public virtual Curso Curso { get; set; }
        public virtual List<Resposta> Respostas { get; set; }

        public Topico()
        {

        }

        public Topico(string titulo, string mensagem, Curso curso)
        {
            Titulo = titulo;
            Mensagem = mensagem;
            Curso = curso;
        }

        public override int GetHashCode() {
            const int prime = 31;
            int result = 1;
            result = prime * result + ((Id == null) ? 0 : Id.GetHashCode());
            return result;
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            if (obj == null)
                return false;
            if (GetType() != obj.GetType())
                return false;
            Topico other = (Topico)obj;
            if (Id == null)
            {
                if (other.Id != null)
                    return false;
            }
            else if (!Id.Equals(other.Id))
                return false;
            return true;
        }
    }
}

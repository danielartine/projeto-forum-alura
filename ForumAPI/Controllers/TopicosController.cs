using ForumAPI.Data.Repository;
using ForumAPI.Dtos;
using ForumAPI.Forms;
using ForumAPI.Modelos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TopicosController : ControllerBase
    {

        private TopicoRepository _topicoRepository;
        private CursoRepository _cursoRepository;

        public TopicosController(TopicoRepository topicoRepository, CursoRepository cursoRepository)
        {
            _topicoRepository = topicoRepository;
            _cursoRepository = cursoRepository;
        }

        [HttpGet]
        public List<TopicoDto> Lista([FromQuery] string? nomeCurso = null)
        {

            List<Topico> topicos = new List<Topico>();
            if (nomeCurso == null)
            {
                topicos = _topicoRepository.FindAll();

            }
            else
            {
                topicos.Add(_topicoRepository.FindByCursoNome(nomeCurso));
            }
            return TopicoDto.Converter(topicos);

        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] TopicoForm form)
        {
            Topico topico = form.Converter(_cursoRepository);
            _topicoRepository.Save(topico);
            var topicoDto = new TopicoDto(topico);
            return CreatedAtAction(nameof(Detalhar), new { Id = topicoDto.Id }, topicoDto);
        }

        [HttpGet("{id}")]

        public IActionResult Detalhar(int id)
        {
            Topico topico = _topicoRepository.FindById(id);
            if (topico == null)
            {
                return NotFound();
            }

            return Ok(new DetalhesDoTopicoDto(topico));
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] AtualizacaoTopicoForm form)
        {
            Topico topico = _topicoRepository.FindById(id);
            if (topico == null)
            {
                return NotFound();
            }

            Topico topicoAtualizado = form.Atualizar(id, _topicoRepository);
            _topicoRepository.Atualizar();
            return Ok(new TopicoDto(topicoAtualizado));
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            Topico topico = _topicoRepository.FindById(id);
            if (topico == null)
            {
                return NotFound();
            }
            _topicoRepository.Delete(topico);
            return Ok();
        }
    }
}

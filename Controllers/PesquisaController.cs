using Microsoft.AspNetCore.Mvc;
using PesquisaSatisfacaoApi.Data;
using PesquisaSatisfacaoApi.Models;

namespace PesquisaSatisfacaoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PesquisaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PesquisaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Post([FromBody] PesquisaResposta pesquisa)
        {
            if (pesquisa == null)
                return BadRequest("Dados inválidos.");

            try
            {
                _context.Respostas?.Add(pesquisa);
                _context.SaveChanges();
                return Ok(new { mensagem = "Dados salvos com sucesso!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao salvar dados: {ex.Message}");
            }
        }
        [HttpGet]
        public IActionResult Get()
        {
            var respostas = _context.Respostas?.ToList();
            return Ok(respostas);
        }
    }
}

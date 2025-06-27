using Microsoft.AspNetCore.Mvc;
using PesquisaSatisfacaoApi.Data;
using PesquisaSatisfacaoApi.Models;

namespace PesquisaSatisfacaoApi.Controllers
{
    [ApiController]
    [Route("api/pesquisa")]
    public class PesquisaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PesquisaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostResposta([FromBody] dynamic payload)
        {
            if (payload == null || payload.q1 == null || payload.q2 == null)
                return BadRequest("Respostas incompletas.");

            var resposta = new PesquisaResposta
            {
                Q1 = payload.q1,
                Q2 = payload.q2,
                Comentario = payload.comentario ?? "",
                Pdv = payload.pdv ?? "Desconhecido"
            };

            _context.Respostas.Add(resposta);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Resposta salva com sucesso." });
        }
    }
}

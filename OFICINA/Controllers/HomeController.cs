using System.Linq;
using OFICINA.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace OFICINA.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly OficinaContext _context;
        public HomeController(ILogger<HomeController> logger, OficinaContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult CadastrarOrcamento(Orcamento novoOrcamento)
        {
            _context.Add(novoOrcamento);
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public IActionResult BuscarOrcamento(int idOrcamento)
        {
            Orcamento orcamento = _context.Orcamentos.Find(idOrcamento);

            if (orcamento == null)
                return NotFound("Orçamento não encontrado");

            return Ok(orcamento);
        }

        [HttpDelete]
        public IActionResult DeletarOrcamento(int codCliente)
        {
            Orcamento servicos_banco = (from S in _context.Orcamentos
                                        where S.CodCliente == codCliente
                                        select S).FirstOrDefault();

            if (servicos_banco != null)
            {
                _context.Orcamentos.Remove(servicos_banco);
                _context.SaveChanges();
            }

            return Ok("Orçamento deletado com sucesso!");
        }

        [HttpPut]
        public IActionResult AlterarOrcamento(AlterarOrcamentoRequest request)
        {
            Orcamento servicosBanco = _context.Orcamentos
                .Find(request.CodCliente);

            if (servicosBanco == null)
            {
                return NotFound("Orçamento não encontrado");
            }

            servicosBanco.NomeCliente = request.NomeCliente;
            servicosBanco.DataOrcamento = request.DataOrcamento;
            servicosBanco.ValorOrcado = request.ValorOrcado;
            servicosBanco.Vendedor = request.Vendedor;
            servicosBanco.DescricaoOrcamento = request.Descricao;

            _context.SaveChanges();

            return Ok("Usuário alterado com sucesso");
        }

        public IActionResult Consulta()
        {
            string sTabela = "";

            List<Orcamento> orcamentos = _context.Orcamentos
                .OrderBy(x => x.NomeCliente)
                .ThenBy(x => x.DataOrcamento)
                .ToList();

            foreach (var trabalho in orcamentos)
            {
                sTabela += "<tr>";
                sTabela += "<td>";
                sTabela += trabalho.NomeCliente;
                sTabela += "</td>";
                sTabela += "<td>";
                sTabela += trabalho.DataOrcamento;
                sTabela += "</td>";
                sTabela += "<td>";
                sTabela += trabalho.Vendedor;
                sTabela += "</td>";
                sTabela += "<td>";
                sTabela += trabalho.DescricaoOrcamento;
                sTabela += "</td>";
                sTabela += "<td>";
                sTabela += trabalho.ValorOrcado;
                sTabela += "</td>";
                sTabela += "<td>";
                sTabela += "<button class='btn btn-warning' onclick='editar(" + trabalho.CodCliente + ")'>Editar</button>";
                sTabela += "</td>";
                sTabela += "<td>";
                sTabela += "<button class='btn btn-danger' onclick='deletar(" + trabalho.CodCliente + ")'>Excluir</button>";
                sTabela += "</td>";
                sTabela += "</tr>";
            }

            ViewBag.orcamentos = sTabela;

            return View();
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        public IActionResult EditarOrcamento(int id)
        {
            Orcamento servicosBanco = _context.Orcamentos.Find(id);

            if (servicosBanco is null) return NotFound();

            return View(servicosBanco);
        }
    }
}

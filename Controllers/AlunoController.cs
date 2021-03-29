using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool2.API.Data;
using SmartSchool2.API.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly SmartContext _context;

        public AlunoController(SmartContext context) 
        {
            _context = context;
        }

        /*
        public List<Aluno> Alunos = new List<Aluno>()
        {   new Aluno{
                Id = 1,
                Nome = "Denis",
                SobreNome = "Ribeiro",
                Telefone = "11223344"
            },
         new Aluno{
                Id = 2,
                Nome = "Vera",
                SobreNome = "Evangelista",
                Telefone = "11223344"
            },
          new Aluno{
                Id = 3,
                Nome = "Denis Fabiano",
                SobreNome = "Filho",
                Telefone = "11223344"
            },
           new Aluno{
                Id = 4,
                Nome = "Isabella",
                SobreNome = "Vitoria",
                Telefone = "11223344"
            }
        };
        */

        [HttpGet]
        public IActionResult Get()
        {
            //return Ok("Alunos: Denis, Vera, Isabella, Denis Filho");
            return Ok(_context.Alunos);
        }

        //[HttpGet("{id:int}")] //http://localhost:37530/api/aluno/2
        [HttpGet("byId")] //http://localhost:37530/api/aluno/byId?id=4
        public IActionResult GetById(int id)
        {
            var aluno = _context.Alunos.Where(a => a.Id == id).FirstOrDefault();

            if (aluno == null) return BadRequest("Aluno não encontrado.");

            return Ok(aluno);
        }

        [HttpGet("{nome}")]  //http://localhost:37530/api/aluno/Denis
        public IActionResult GetByNome(string nome)
        {
            var aluno = _context.Alunos.Where(a => a.Nome.Contains(nome)).FirstOrDefault();

            if (aluno == null) return BadRequest("Aluno não encontrado.");

            return Ok(aluno);
        }

        [HttpGet("byName")] //http://localhost:37530/api/aluno/byName?nome=Denis&sobrenome=Ribeiro
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var aluno = _context.Alunos.Where(a => a.Nome.Contains(nome)  && a.SobreNome.Contains(sobrenome)).FirstOrDefault();

            if (aluno == null) return BadRequest("Aluno não encontrado.");

            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            //return Ok("Alunos: Denis, Vera, Isabella, Denis Filho");
            _context.Add(aluno);
            _context.SaveChanges();

            return Ok(aluno);
        }

        [HttpPut("{Id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            //return Ok("Alunos: Denis, Vera, Isabella, Denis Filho");
            var alu = _context.Alunos.Where(x => x.Id == id).AsNoTracking().FirstOrDefault();

            if (alu == null) return BadRequest("Aluno não encontrado.");

            _context.Update(aluno);
            _context.SaveChanges();

            return Ok(aluno);
        }

        [HttpPatch("{Id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            //return Ok("Alunos: Denis, Vera, Isabella, Denis Filho");

            var alu = _context.Alunos.Where(x => x.Id == id).AsNoTracking().FirstOrDefault();

            if (alu == null) return BadRequest("Aluno não encontrado.");

            _context.Update(aluno);
            _context.SaveChanges();

            return Ok(aluno);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int id)
        {
            //return Ok("Alunos: Denis, Vera, Isabella, Denis Filho");
            var aluno = _context.Alunos.Where(x => x.Id == id).FirstOrDefault();

            if (aluno == null) return BadRequest("Aluno não encontrado.");

            _context.Remove(aluno);
            _context.SaveChanges();

            return Ok();
        }


    }

}

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
    public class ProfessorController : ControllerBase
    {
        private readonly SmartContext _context;

        public ProfessorController(SmartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            //return Ok("Professors: Denis, Vera, Isabella, Denis Filho");
            return Ok(_context.Professores);
        }
        

        //[HttpGet("{id:int}")] //http://localhost:37530/api/Professor/2
        [HttpGet("byId")] //http://localhost:37530/api/Professor/byId?id=4
        public IActionResult GetById(int id)
        {
            var Professor = _context.Professores.Where(a => a.Id == id).FirstOrDefault();

            if (Professor == null) return BadRequest("Professor não encontrado.");

            return Ok(Professor);
        }

        [HttpGet("{nome}")]  //http://localhost:37530/api/Professor/Denis
        public IActionResult GetByNome(string nome)
        {
            var Professor = _context.Professores.Where(a => a.Nome.Contains(nome)).FirstOrDefault();

            if (Professor == null) return BadRequest("Professor não encontrado.");

            return Ok(Professor);
        }

        [HttpGet("byName")] //http://localhost:37530/api/Professor/byName?nome=Denis&sobrenome=Ribeiro
        public IActionResult GetByName(string nome)
        {
            var Professor = _context.Professores.Where(a => a.Nome.Contains(nome) ).FirstOrDefault();

            if (Professor == null) return BadRequest("Professor não encontrado.");

            return Ok(Professor);
        }

        [HttpPost]
        public IActionResult Post(Professor Professor)
        {
            //return Ok("Professors: Denis, Vera, Isabella, Denis Filho");
            _context.Add(Professor);
            _context.SaveChanges();

            return Ok(Professor);
        }

        [HttpPut("{Id}")]
        public IActionResult Put(int id, Professor Professor)
        {
            //return Ok("Professors: Denis, Vera, Isabella, Denis Filho");
            var alu = _context.Professores.Where(x => x.Id == id).AsNoTracking().FirstOrDefault();

            if (alu == null) return BadRequest("Professor não encontrado.");

            _context.Update(Professor);
            _context.SaveChanges();

            return Ok(Professor);
        }

        [HttpPatch("{Id}")]
        public IActionResult Patch(int id, Professor Professor)
        {
            //return Ok("Professors: Denis, Vera, Isabella, Denis Filho");

            var alu = _context.Professores.Where(x => x.Id == id).AsNoTracking().FirstOrDefault();

            if (alu == null) return BadRequest("Professor não encontrado.");

            _context.Update(Professor);
            _context.SaveChanges();

            return Ok(Professor);
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int id)
        {
            //return Ok("Professors: Denis, Vera, Isabella, Denis Filho");
            var Professor = _context.Professores.Where(x => x.Id == id).FirstOrDefault();

            if (Professor == null) return BadRequest("Professor não encontrado.");

            _context.Remove(Professor);
            _context.SaveChanges();

            return Ok();
        }
    }

}

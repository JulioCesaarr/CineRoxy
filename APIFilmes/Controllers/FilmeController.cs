using APIFilmes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using APIFilmes.Data;
using APIFilmes.Data.Dtos;
using AutoMapper;
using APIFilmes.Services;
using FluentResults;
using Microsoft.AspNetCore.Authorization;

namespace APIFilmes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeService _filmeService;

        public FilmeController(FilmeService filmeService)
        {
           _filmeService = filmeService;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmedto)
        {
            ReadFilmeDto readDto = _filmeService.AdicionaFilme(filmedto);

            return CreatedAtAction(nameof(RecuperaFilmePorID), new { Id = readDto.Id }, readDto);
        }
        
       
        [HttpGet]
        //utilizado o IEnumerable para previnir mudanças no codigo!
        public IActionResult RecuperaFilmes([FromQuery] int? ClassificacaoEtaria = null)
        {
            List<ReadFilmeDto> readDto = _filmeService.RecuperaFilmes(ClassificacaoEtaria);
            if(readDto != null) return Ok(readDto);
           
            
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmePorID(int id)
        {
            ReadFilmeDto readDto = _filmeService.RecuperaFilmesPorID(id);
            if(readDto != null) return Ok();
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            Result resultado =  _filmeService.AtualizaFilme(id, filmeDto);
            if(resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilmes(int id)
        {
            Result resultado = _filmeService.DeletaFilmes(id);
            if(resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreApiNoticias.Models;
using NetCoreApiNoticias.Services;

namespace NetCoreApiNoticias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticiaController : ControllerBase
    {
        private readonly NoticiaService _noticiaService;
        public NoticiaController(NoticiaService noticiaService)
        {
            _noticiaService = noticiaService;
        }


        [HttpGet]
        public IActionResult Prueba()
        {
            return Ok("pruebas de las pruebas para las pruebas.");
        }

        [HttpGet]
        [Route("Obtener")]
        public IActionResult Obtener()
        {
            var result = _noticiaService.Obtener();
            return Ok(result);
        }


        [HttpPost]
        [Route("Agregar")]
        public IActionResult Agregar([FromBody] Noticia _noticia)
        {
            try
            {
                var result = _noticiaService.AgregarNoticia(_noticia);
                if(result)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("editar")]
        public IActionResult Editar([FromBody] Noticia _noticia)
        {
            try
            {
                var result = _noticiaService.EditarNoticia(_noticia);
                if (result)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("Eliminar/{noticiaID}")]
        public IActionResult Eliminar( int noticiaID)
        {
            try
            {
                var result = _noticiaService.EliminarNoticia(noticiaID);
                if (result)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    }
}
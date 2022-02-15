using Controladores.Models;
using DTOs.Autores;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Servicios;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Controladores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorService _autorService;
        public AutorController(IAutorService autorService)
        {
            _autorService = autorService;
        }
        // GET: api/<AutorController>
        [HttpGet]
        [Produces("application/json", Type = typeof(IEnumerable<AutorViewModel>))]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _autorService.GetAllAsync();
            return Ok(response.Select(a => new AutorViewModel(a)));
        }

        // POST api/<AutorController>
        [HttpPost]
        [Produces("application/json", Type = typeof(AutorViewModel))]
        public async Task<ActionResult> Post(AutorInputModel autorInput)
        {
            var autor = MapperAutor(autorInput);
            var response = await _autorService.SaveAsync(autor);
            var autorViewModel = new AutorViewModel(response);
            return Ok(autorViewModel);
        }

        private static AutorDTO MapperAutor(AutorInputModel autorInput)
        {
            AutorDTO autor = new AutorDTO()
            {
                Name = autorInput.Name,
                Birthday = autorInput.Birthday,
                CityOfOrigin = autorInput.CityOfOrigin,
                Email = autorInput.Email
            };
            return autor;
        }
    }
}

using Controladores.Models;
using DTOs.Autores;
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
        private readonly AutorService autorService;
        public AutorController(BibliotecaContext context)
        {
            autorService = new AutorService(context);
        }
        // GET: api/<AutorController>
        [HttpGet]
        [Produces("application/json", Type = typeof(IEnumerable<AutorViewModel>))]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await autorService.GetAllAsync();
            if (response.Success == false)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Autores.Select(a => new AutorViewModel(a)));
        }



        // POST api/<AutorController>
        [HttpPost]
        [Produces("application/json", Type = typeof(AutorViewModel))]
        public async Task<ActionResult> Post(AutorInputModel autorInput)
        {
            var autor = MapAutor(autorInput);
            var response = await autorService.SaveAsync(autor);
            if (response.Success == false)
            {
                return BadRequest(response.Message);
            }
            var autorViewModel = new AutorViewModel(response.Autor);
            return Ok(autorViewModel);

        }

        private static AutorDTO MapAutor(AutorInputModel autorInput)
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

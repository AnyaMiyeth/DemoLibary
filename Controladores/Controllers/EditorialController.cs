using Controladores.Models;
using DTOs.Editorals;
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
    public class EditorialController : ControllerBase
    {
        
        private readonly IEditorialService _editorialService;
        public EditorialController(IEditorialService editorialService)
        {
            _editorialService = editorialService;
        }

        [HttpGet]
        [Produces("application/json", Type = typeof(IEnumerable<EditorialViewModel>))]
        public async Task<ActionResult> GetAll()
        {
            var response = await _editorialService.GetAll();
            return Ok(response.Select(e => new EditorialViewModel(e)));
        }

        // POST api/<EditorialController>
        [HttpPost]
        [Produces("application/json", Type = typeof(EditorialViewModel))]
        public async Task <ActionResult> Post(EditorialInputModel editorialInputModel)
        {
            var editorial = MapEditorial(editorialInputModel);
            var response =  await _editorialService.Save(editorial);
            return Ok(new EditorialViewModel(response));
        }

        private static EditorialDTO MapEditorial(EditorialInputModel editorialInputlModel)
        {
            EditorialDTO editorialDTO = new EditorialDTO()
            {
                Name = editorialInputlModel.Name,
                Telephon = editorialInputlModel.Telephon,
                CorrespondenceAddress = editorialInputlModel.CorrespondenceAddress,
                Email = editorialInputlModel.Email,
                MaximumNumberOfBook = editorialInputlModel.MaximumNumberOfBook
            };
            return editorialDTO;
        }
    }
}

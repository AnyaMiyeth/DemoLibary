using Controladores.Models;
using DTOs.Editorals;
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
        private readonly BibliotecaContext _context;
        private readonly EditorialService editorialService;
        public EditorialController(BibliotecaContext context)
        {
            editorialService = new EditorialService(context);
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EditorialViewModel>> GetAll()
        {
            var response = editorialService.GetAll();
            if (response.Success == false)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Editoriales.Select(e => new EditorialViewModel(e)));
        }

        // POST api/<EditorialController>
        [HttpPost]
        public ActionResult<EditorialViewModel> Post(EditorialInputModel editorialInputModel)
        {
            var editorial = MapEditorial(editorialInputModel);
            var response = editorialService.Save(editorial);
            if (response.Success == false)
            {
                return  BadRequest(response.Message);
            }
            return Ok(new EditorialViewModel(response.Editorial));

        }

        private static EditorialDTO MapEditorial(EditorialInputModel editorialInputlModel)
        {
            EditorialDTO editorialDTO = new EditorialDTO()
            {
                Name = editorialInputlModel.Name,
                Telephon = editorialInputlModel.Telephon,
                CorrespondenceAddress = editorialInputlModel.CorrespondenceAddress,
                Email = editorialInputlModel.Email,
                MaximumNumberOfBook = editorialInputlModel.MaximumNumberOfBook,


            };
            return editorialDTO;
        }
    }
}

using DTOs.Editorals;
using System.ComponentModel.DataAnnotations;

namespace Controladores.Models
{
    public class EditorialInputModel
    {

     
      

        [Required(ErrorMessage = "Nombre de la Editorial Requerida")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Direccion de la Editorial Requerido")]
        public string CorrespondenceAddress { get; set; }
        public string Telephon { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail no es valido")]
        public string Email { get; set; }

      
        public int MaximumNumberOfBook { get; set; }
    }

    public class EditorialViewModel : EditorialInputModel
    {
        public int Id { get; set; }
        public EditorialViewModel(EditorialDTO editorial)
        {
            Id = editorial.Id;
            Name = editorial.Name;
            CorrespondenceAddress = editorial.CorrespondenceAddress;
            Telephon = editorial.Telephon;
            Email = editorial.Email;
            MaximumNumberOfBook = editorial.MaximumNumberOfBook;
        }

    }
}

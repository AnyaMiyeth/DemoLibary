using DTOs.Autores;
using System;

namespace Controladores.Models
{
    public class AutorInputModel
    {

        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string CityOfOrigin { get; set; }
        public string Email { get; set; }
    }

    public class AutorViewModel : AutorInputModel
    {
        public int Id { get; set; }
        public AutorViewModel(AutorDTO autor)
        {
            Id = autor.Id;
            Name = autor.Name;
            Birthday = autor.Birthyday;
            CityOfOrigin = autor.CityOfOrigin;
            Email = autor.Email;
        }
    }
}

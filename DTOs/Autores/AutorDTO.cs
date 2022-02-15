using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Autores
{
   public class AutorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthyday { get; set; }
        public string CityOfOrigin { get; set; }
        public string Email { get; set; }
    }
}

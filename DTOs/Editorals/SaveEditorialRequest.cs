using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Editorals
{
    public class SaveEditorialRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CorrespondenceAddress { get; set; }
        public string Telephon { get; set; }
        public string Email { get; set; }
        public int MaximumNumberOfBook { get; set; }

    }
}

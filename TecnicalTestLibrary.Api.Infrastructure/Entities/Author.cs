using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecnicalTestLibrary.Api.Infrastructure.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string CityOrigin { get; set; }
        public string EMail { get; set; }
    }
}

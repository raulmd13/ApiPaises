using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudAppi.Models.DTO
{
    public class CountryApiDTO
    {
        public NameDTO name { get; set; }
        public string cca2 { get; set; }
        public string cca3 { get; set; }
        public List<string> capital { get; set; }
        public string region { get; set; }
        public FlagsDTO flags { get; set; }
    }
}

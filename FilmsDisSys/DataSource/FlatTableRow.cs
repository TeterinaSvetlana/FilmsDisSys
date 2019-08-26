using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsDisSys.DataSource
{
    public sealed class FlatTableRow
    {
        public int ID { get; set; }

        public string NameFilm { get; set; }

        public string NameDirector { get; set; }

        public int Length { get; set; }

        public string Country { get; set; }

        public DateTime ReleaseDate { get; set; }        

        public string NameType { get; set; }

        public string NameGenre { get; set; }
        
        public string NameTag { get; set; }
    }
}

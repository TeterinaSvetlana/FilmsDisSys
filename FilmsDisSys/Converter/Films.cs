using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsDisSys.Converter
{
    public sealed class Films : IEntity
    {
        public int ID { get; set; }

        public override string ToString()
        {
            return ID.ToString();
        }

        public string NameFilm { get; set; }

        public Directors Director { get; set; }

        public int Length { get; set; }

        public string Country { get; set; }

        public DateTime ReleaseDate { get; set; }

        public Typess Type { get; set; }

        public Genres Genre { get; set; }

        //public ISet<Tags> NameTag { get; set; } = new HashSet<Tags>(new TagsComparer());

        //public IList<TagsFilms> TagsFilms { get; set; } = new HashSet<TagsFilms>(new TagsFilmsComparer());
        public IList<TagsFilms> TagsFilms { get; set; } = new List<TagsFilms>();

        public override bool Equals(object obj) => new FilmsComparer().Equals(this, obj as Films);

        public override int GetHashCode() => new FilmsComparer().GetHashCode(this);
    }

    internal sealed class FilmsComparer : IEqualityComparer<Films>
    {
        public bool Equals(Films x, Films y) => x.NameFilm.Equals(y.NameFilm, StringComparison.InvariantCultureIgnoreCase);

        public int GetHashCode(Films obj) => obj.NameFilm.ToLower().GetHashCode();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsDisSys.Converter
{
    public sealed class Genres : IEntity
    {
        public int ID { get; set; }

        public override string ToString()
        {
            return ID.ToString();
        }

        public string NameGenre { get; set; }

        public override bool Equals(object obj) => new GenresComparer().Equals(this, obj as Genres);

        public override int GetHashCode() => new GenresComparer().GetHashCode(this);
    }

    internal sealed class GenresComparer : IEqualityComparer<Genres>
    {
        public bool Equals(Genres x, Genres y) => x.NameGenre.Equals(y.NameGenre, StringComparison.InvariantCultureIgnoreCase);

        public int GetHashCode(Genres obj) => obj.NameGenre.ToLower().GetHashCode();
    }
}

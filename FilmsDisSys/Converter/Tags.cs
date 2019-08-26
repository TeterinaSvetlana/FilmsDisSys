using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsDisSys.Converter
{
    public sealed class Tags : IEntity
    {
        public int ID { get; set; }

        public override string ToString()
        {
            return ID.ToString();
        }

        public string NameTag { get; set; }


        //public ISet<TagsFilms> TagsFilms { get; set; } = new HashSet<TagsFilms>(new TagsFilmsComparer());

        public IList<TagsFilms> TagsFilms { get; set; } = new List<TagsFilms>();

        public override bool Equals(object obj) => new TagsComparer().Equals(this, obj as Tags);

        public override int GetHashCode() => new TagsComparer().GetHashCode(this);
    }

    internal sealed class TagsComparer : IEqualityComparer<Tags>
    {
        public bool Equals(Tags x, Tags y) => x.NameTag.Equals(y.NameTag, StringComparison.InvariantCultureIgnoreCase);

        public int GetHashCode(Tags obj) => obj.NameTag.ToLower().GetHashCode();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsDisSys.Converter
{
    public sealed class TagsFilms : IEntity
    {
        public int ID { get; set; }

        //public override string ToString()
        //{
        //    return ID.ToString();
        //}
        public Films Film { get; set; }

        public Tags Tag { get; set; }

        public override bool Equals(object obj) => new TagsFilmsComparer().Equals(this, obj as TagsFilms);

        public override int GetHashCode() => new TagsFilmsComparer().GetHashCode(this);
    }

    internal sealed class TagsFilmsComparer : IEqualityComparer<TagsFilms>
    {
        public bool Equals(TagsFilms x, TagsFilms y) => x.ID == y.ID;

        public int GetHashCode(TagsFilms obj) => obj.ID;
    }
}

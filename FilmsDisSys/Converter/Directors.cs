using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsDisSys.Converter
{
    public sealed class Directors : IEntity
    {
        public int ID { get; set; }

        public string NameDirector { get; set; }

        public override string ToString()
        {
            return ID.ToString();
        }

        public override bool Equals(object obj) => new DirectorsComparer().Equals(this, obj as Directors);

        public override int GetHashCode() => new DirectorsComparer().GetHashCode(this);
    }

    internal sealed class DirectorsComparer : IEqualityComparer<Directors>
    {
        public bool Equals(Directors x, Directors y) => x.NameDirector.Equals(y.NameDirector, StringComparison.InvariantCultureIgnoreCase);

        public int GetHashCode(Directors obj) => obj.NameDirector.ToLower().GetHashCode();
    }
}

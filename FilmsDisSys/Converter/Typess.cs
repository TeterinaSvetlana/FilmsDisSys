using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsDisSys.Converter
{
    public sealed class Typess : IEntity
    {
        public int ID { get; set; }

        public override string ToString()
        {
            return ID.ToString();
        }

        public string NameType { get; set; }

        public override bool Equals(object obj) => new TypesComparer().Equals(this, obj as Typess);

        public override int GetHashCode() => new TypesComparer().GetHashCode(this);
    }

    internal sealed class TypesComparer : IEqualityComparer<Typess>
    {
        public bool Equals(Typess x, Typess y) => x.NameType.Equals(y.NameType, StringComparison.InvariantCultureIgnoreCase);

        public int GetHashCode(Typess obj) => obj.NameType.ToLower().GetHashCode();
    }
}

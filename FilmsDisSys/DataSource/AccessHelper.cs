using System.Collections.Generic;
using System.Linq;

namespace FilmsDisSys.DataSource
{
    public static class AccessHelper
    {
        public static IEnumerable<FlatTableRow> LoadFlatTableRows()
        {
            using (var context = new AccessContext1())
            {
                return context.FilmsDumb.ToList();
            }
        }

        public static string Test()
        {
            return ("test");
        }
    }
}

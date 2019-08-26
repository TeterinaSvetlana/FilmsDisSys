using Microsoft.EntityFrameworkCore;
using EntityFrameworkCore.Jet;

namespace FilmsDisSys.DataSource
{
    internal sealed class AccessContext1 : DbContext
    {
        internal DbSet<FlatTableRow> FilmsDumb { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseJet(@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=DataSource/FilmsDumb.accdb; Persist Security Info=False;");
        }
    }
}

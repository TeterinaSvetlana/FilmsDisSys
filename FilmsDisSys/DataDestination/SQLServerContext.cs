using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FilmsDisSys.DataDestination
{
    internal sealed class SQLServerContext : DataContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-STF6BUBG;Database=FilmsDB;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}

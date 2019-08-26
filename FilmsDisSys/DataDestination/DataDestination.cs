using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsDisSys.DataDestination
{
    using Converter;
    public static class DataDestination
    {
        public static IDictionary<Type, IEnumerable<IEntity>> SaveToSqlServer(this IDictionary<Type, IEnumerable<IEntity>> entities)
        {
            using (var context = new SQLServerContext())
            {
                DropIds(entities);

                SaveAll(entities, context);
            }

            return entities;
        }

        private static void SaveAll(IDictionary<Type, IEnumerable<IEntity>> entities, DataContext context)
        {
            //entities[typeof(TagsFilms)].Cast<TagsFilms>().ToList().ForEach(x => context.TagsFilms.Add(x));
            
            entities[typeof(Directors)].Cast<Directors>().ToList().ForEach(x => context.Directors.Add(x));
            foreach (var dir in entities[typeof(Directors)].Cast<Directors>().ToList())
            {
                entities[typeof(Films)].Cast<Films>().ToList().ForEach(x => { if (x.Director?.NameDirector == dir.NameDirector) x.Director.ID = dir.ID; });
            }

            entities[typeof(Typess)].Cast<Typess>().ToList().ForEach(x => context.Typess.Add(x));
            foreach (var typ in entities[typeof(Typess)].Cast<Typess>().ToList())
            {
                entities[typeof(Films)].Cast<Films>().ToList().ForEach(x => { if (x.Type?.NameType == typ.NameType) x.Type.ID = typ.ID; });
            }

            entities[typeof(Genres)].Cast<Genres>().ToList().ForEach(x => context.Genres.Add(x));
            foreach (var gen in entities[typeof(Genres)].Cast<Genres>().ToList())
            {
                entities[typeof(Films)].Cast<Films>().ToList().ForEach(x => { if (x.Genre?.NameGenre == gen.NameGenre) x.Genre.ID = gen.ID; });
            }

            entities[typeof(Tags)].Cast<Tags>().ToList().ForEach(x => context.Tags.Add(x));
            entities[typeof(TagsFilms)].Cast<TagsFilms>().ToList().ForEach(x => context.TagsFilms.Add(x));
            entities[typeof(Films)].Cast<Films>().ToList().ForEach(x => context.Films.Add(x));

             

            context.SaveChanges();
        }

        private static void DropIds(IDictionary<Type, IEnumerable<IEntity>> entities)
        {
            entities.Values.ToList().ForEach(x => x.ToList().ForEach(y => y.ID = default));
        }
    }
}

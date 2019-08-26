using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsDisSys.Converter
{
    using DataSource;
    public static class Converter
    {
        private static readonly ISet<Films> Films = new HashSet<Films>();
        private static readonly ISet<Directors> Directors = new HashSet<Directors>();
        private static readonly ISet<Genres> Genres = new HashSet<Genres>();
        private static readonly ISet<Tags> Tags = new HashSet<Tags>();
        private static readonly ISet<Typess> Typess = new HashSet<Typess>();
        private static readonly IList<TagsFilms> TagsFilms = new List<TagsFilms>();

        public static IDictionary<Type, IEnumerable<IEntity>> ConvertToEntities(this IEnumerable<FlatTableRow> flatTableRows)
        {
            foreach (var row in flatTableRows)
            {
                var film = new Films { NameFilm = row.NameFilm,
                    Length = row.Length,
                    Country = row.Country,
                    ReleaseDate = row.ReleaseDate,
                    //if (film.Director != null)
                    Director = row.NameDirector != null ? new Directors() { NameDirector = row.NameDirector } : null,
                    Type = row.NameType != null ? new Typess() { NameType = row.NameType }:null,
                    Genre = row.NameGenre != null ? new Genres() { NameGenre = row.NameGenre} : null
                };
                var director = new Directors { NameDirector = row.NameDirector};
                var genre = new Genres { NameGenre = row.NameGenre};
                var tag = new Tags { NameTag = row.NameTag};
                var type = new Typess { NameType = row.NameType };
                var tagsFilms = new TagsFilms { Tag = tag, Film = film };
                if (row.NameFilm != null)
                Films.Add(film);
                if(row.NameDirector != null)
                Directors.Add(director);
                if (row.NameGenre != null)
                    Genres.Add(genre);
                if (row.NameTag != null)
                    Tags.Add(tag);
                if (row.NameType != null)
                    Typess.Add(type);

                film = Films.SingleOrDefault(x => x.Equals(film));
                director = Directors.SingleOrDefault(x => x.Equals(director));
                genre = Genres.SingleOrDefault(x => x.Equals(genre));
                tag = Tags.SingleOrDefault(x => x.Equals(tag));
                type = Typess.SingleOrDefault(x => x.Equals(type));

                //if (!film.NameTag.Contains(tag, new TagsComparer()))
                //{
                //    film.NameTag.Add(tag);
                //    //tag.Films= film;
                //}

                //if (!tag?.TagsFilms.Contains(tagsFilms)??false)
                //{
                if (tag != null)
                {
                    TagsFilms.Add(tagsFilms);
                    tag.TagsFilms.Add(tagsFilms);
                    film.TagsFilms.Add(tagsFilms);
                    tagsFilms.Tag = tag;
                    tagsFilms.Film = film;
                }
                //}                
            }

            return new Dictionary<Type, IEnumerable<IEntity>>
            {
                [typeof(Films)] = Films,
                [typeof(Directors)] = Directors,
                [typeof(Genres)] = Genres,
                [typeof(Tags)] = Tags,
                [typeof(Typess)] = Typess,
                [typeof(TagsFilms)] = TagsFilms
            };

        }
    }
}

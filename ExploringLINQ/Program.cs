using System;
using System.Collections.Generic;
using System.Linq;
namespace ExploringLINQ
{
    public class Test
    {



        public static void Main(string[] args)
        {
            var format = System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat;

            Movie[] movies = new Movie[]
            {
                new Movie(DateTime.Parse("1/1/2015 20:00", format), DateTime.Parse("1/1/2015 21:30", format)),
                new Movie(DateTime.Parse("1/1/2015 21:30", format), DateTime.Parse("1/1/2015 23:00", format)),
                new Movie(DateTime.Parse("1/1/2015 23:10", format), DateTime.Parse("1/1/2015 23:30", format)),
                new Movie(DateTime.Parse("1/1/2015 23:10", format), DateTime.Parse("1/1/2015 23:30", format)),
                new Movie(DateTime.Parse("1/1/2015 23:10", format), DateTime.Parse("1/1/2015 23:30", format))
            };



            Console.WriteLine(MovieNight.CanViewAll(movies));
        }

        public class Movie
        {
            public DateTime Start { get; private set; }
            public DateTime End { get; private set; }

            public Movie(DateTime start, DateTime end)
            {
                this.Start = start;
                this.End = end;
            }
        }

        public static class MovieNight
        {
            public static bool CanViewAll(IEnumerable<Movie> movies)
            {
                var duplicateStarTime = movies.GroupBy(m => m.Start).All(t => t.Count() > 1);
                if (!duplicateStarTime)
                {
                    var sortedMovies = movies.OrderBy(m => m.End).ToList();

                    for (var i = 0; i < movies.Count() - 2; i++)
                    {
                        if (sortedMovies[i].End >= sortedMovies[i + 1].Start)
                        {
                            return false;
                        }
                    }
                }

                //var sortedMovies = movies.OrderBy(m => m.Start).ToList();
                //for (var i = 0; i < movies.Count() - 2; i++)
                //{

                //    if (sortedMovies[i].End > sortedMovies[i + 1].Start)
                //    {
                //        return false;
                //    }
                //}
                return true;
            }

        }


    }
}

using System;
using System.Collections.Generic;
using System.IO;
using CsvParserApp.CsvModel;
using CsvParserApp.Models;

namespace CsvParserApp
{
    // TODO Download MovieLens latest small dataset from https://grouplens.org/datasets/movielens/, extract csv files and copy them to the current bin folder.
    public class Program
    {
        public static void Main(string[] args)
        {
            // NOTE Open project properties, go on Debug tab and find Command line arguments there.
            var moviesPath = GetFilePath(args, "movies");
            var ratingsPath = GetFilePath(args, "ratings");
            var tagsPath = GetFilePath(args, "tags");

            var moviesDataSet = LoadMovieDataSet(moviesPath, ratingsPath, tagsPath, new MovieDataSetBuilder());

            Console.WriteLine("Movies in data set: {0}", moviesDataSet.Movies.Count);
            Console.WriteLine("Genres in data set: {0}", moviesDataSet.Genres.Count);
            Console.WriteLine("Users in data set: {0}", moviesDataSet.Users.Count);

            Console.WriteLine("\nPress enter key to exit.");
            Console.ReadLine();
        }

        public static string GetFilePath(string[] args, string expectedParameter)
        {
            foreach (var arg in args)
            {
                string[] array;

                // TODO: Replace the line below with your code to get a command line parameter value. Use only System.String type methods here.
                array = new[] { string.Empty, string.Empty };

                string parameterName = array[0];

                if (parameterName == expectedParameter)
                {
                    return array[1];
                }
            }

            throw new Exception(string.Format("expectedParameter {0} is not found.", expectedParameter));
        }

        private static MovieDataSet LoadMovieDataSet(string moviesPath, string ratingsPath, string tagsPath, IMovieDataSetBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (File.Exists(moviesPath) == false)
            {
                throw new Exception(string.Format("file {0} is not exists.", moviesPath));
            }

            if (File.Exists(ratingsPath) == false)
            {
                throw new Exception(string.Format("file {0} is not exists.", ratingsPath));
            }

            if (File.Exists(tagsPath) == false)
            {
                throw new Exception(string.Format("file {0} is not exists.", tagsPath));
            }

            using (var streamReader = new StreamReader(moviesPath))
            {
                builder.AddMovies(LoadMoviesFromFile());
            }

            using (var streamReader = new StreamReader(ratingsPath))
            {
                builder.AddRatings(LoadRatingsFromFile());
            }

            using (var streamReader = new StreamReader(tagsPath))
            {
                // TODO Implement loading tag data from CSV file.
                builder.AddTags(LoadTagsFromFile());
            }

            return builder.Build();
        }

        private static IList<MovieRow> LoadMoviesFromFile()
        {
            // TODO Implement loading movie data from CSV file.
            return new MovieRow[] { };
        }

        private static IList<RatingRow> LoadRatingsFromFile()
        {
            // TODO Implement loading rating data from CSV file.
            return new RatingRow[] { };
        }

        private static IList<TagRow> LoadTagsFromFile()
        {
            return new TagRow[] { };
        }
    }
}

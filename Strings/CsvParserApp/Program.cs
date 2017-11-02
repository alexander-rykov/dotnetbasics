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
            var moviesPath = GetFilePath(args, "movies");
            var ratingsPath = GetFilePath(args, "ratings");
            var tagsPath = GetFilePath(args, "tags");

            var moviesDataSet = LoadMovieDataSet(moviesPath, ratingsPath, tagsPath);

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
                // array = new[] { string.Empty, string.Empty };
                array = arg.TrimStart('-').Split('=');

                string parameterName = array[0];

                if (parameterName == expectedParameter)
                {
                    return array[1];
                }
            }

            throw new Exception(string.Format("expectedParameter {0} is not found.", expectedParameter));
        }

        private static MovieDataSet LoadMovieDataSet(string moviesPath, string ratingsPath, string tagsPath)
        {
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

            IList<MovieRow> movieRows;
            IList<RatingRow> ratingRows;
            IList<TagRow> tagRows;

            using (var streamReader = new StreamReader(moviesPath))
            {
                // TODO Implement loading movie data from CSV file.
                movieRows = LoadMoviesFromFile();
            }

            using (var streamReader = new StreamReader(ratingsPath))
            {
                // TODO Implement loading rating data from CSV file.
                ratingRows = LoadRatingsFromFile();
            }

            using (var streamReader = new StreamReader(tagsPath))
            {
                // TODO Implement loading tag data from CSV file.
                tagRows = LoadTagsFromFile();
            }

            return ConvertToMovieDataSet(movieRows, ratingRows, tagRows);
        }

        private static IList<MovieRow> LoadMoviesFromFile()
        {
            return new MovieRow[] { };
        }

        private static IList<RatingRow> LoadRatingsFromFile()
        {
            return new RatingRow[] { };
        }

        private static IList<TagRow> LoadTagsFromFile()
        {
            return new TagRow[] { };
        }

        private static MovieDataSet ConvertToMovieDataSet(IList<MovieRow> movieRows, IList<RatingRow> ratingRows, IList<TagRow> tagRows)
        {
            if (movieRows == null)
            {
                throw new ArgumentNullException(nameof(movieRows));
            }

            if (ratingRows == null)
            {
                throw new ArgumentNullException(nameof(ratingRows));
            }

            if (tagRows == null)
            {
                throw new ArgumentNullException(nameof(tagRows));
            }

            // TODO Implement functionality to convert raw data into the data set model.
            return new MovieDataSet();
        }
    }
}
